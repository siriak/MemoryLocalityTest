using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MemoryLocalityTest
{
    internal static class TaskRunner
    {
        private static readonly SortedDictionary<long, List<(long, Task)>> tasks = new SortedDictionary<long, List<(long, Task)>>();
        private static readonly Stopwatch stopwatch = new Stopwatch();

        public static bool ShouldStop { get; private set; }
        public static bool Stopped { get; private set; }
        public static int TaskCount { get; private set; }
        public static TimeSpan TimeInStateEstimate { get; private set; }
        public static TimeSpan TimeInStatePassed => stopwatch.Elapsed;

        public static async Task Run()
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
                    await Task.Delay(TimeSpan.FromSeconds(1)).ConfigureAwait(false);
                    continue;
                }

                TaskCount = tasks.SelectMany(t => t.Value).Count();

                var enumerator = tasks.GetEnumerator();
                enumerator.MoveNext();

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

                stopwatch.Restart();
                task.Start();
                await task.ConfigureAwait(false);
                stopwatch.Restart();
            }
        }

        public static void AddTask(long priority, long minTime, Task task)
        {
            if (tasks.ContainsKey(priority))
            {
                tasks[priority].Add((minTime, task));
            }
            else
            {
                tasks.Add(priority, new List<(long, Task)>(1)
                {
                    (minTime, task),
                });
            }
        }

        public static void RequestStop() => ShouldStop = true;
    }
}
