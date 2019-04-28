using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MemoryLocalityTest
{
    static class TaskRunner
    {
        private static readonly SortedDictionary<long, List<(long, Task)>> tasks = new SortedDictionary<long, List<(long, Task)>>();
        private static readonly Stopwatch stopwatch = new Stopwatch();

        public static bool ShouldStop { get; private set; }
        public static bool Stopped { get; private set; }
        public static int TaskCount { get; private set; }
        public static TimeSpan TimeInStateEstimate { get; private set; }
        public static TimeSpan TimeInStatePassed => stopwatch.Elapsed;

        public static async void Run()
        {
            stopwatch.Start();
            while (true)
            {
                if (tasks.Any())
                {
                    Stopped = false;
                }

                if (ShouldStop || tasks.Count == 0)
                {
                    Stopped = true;
                    ShouldStop = false;
                    tasks.Clear();
                    TaskCount = 0;
                    TimeInStateEstimate = default;
                    await Task.Delay(TimeSpan.FromSeconds(1));
                    continue;
                }

                TaskCount = tasks.SelectMany(t => t.Value).Count();

                var enumerator = tasks.GetEnumerator();
                enumerator.MoveNext();

                var time = enumerator.Current.Key;
                var taskList = enumerator.Current.Value;
                var (minTime, task) = taskList[0];
                if (taskList.Count == 1)
                {
                    tasks.Remove(enumerator.Current.Key);
                }
                else
                {
                    taskList.RemoveAt(0);
                }

                TimeInStateEstimate = TimeSpan.FromMilliseconds(minTime);
                task.Start();
                await task;
                stopwatch.Restart();
            }
        }

        public static void AddTask(long priority, (long minTime, Task task) task)
        {
            if (tasks.ContainsKey(priority))
            {
                tasks[priority].Add(task);
            }
            else
            {
                tasks.Add(priority, new List<(long, Task)>(1)
                {
                    task,
                });
            }
        }

        public static void RequestStop() => ShouldStop = true;
    }
}
