using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static MemoryLocalityTest.MatrixHelper;
using static MemoryLocalityTest.ChartHelper;
using static MemoryLocalityTest.TaskRunner;
using static MemoryLocalityTest.FileHelper;

namespace MemoryLocalityTest
{
    public partial class MainForm : Form
    {
        public MainForm() => InitializeComponent();

        int START_COUNT;
        int MAX_COUNT;
        int TEST_TIMES;
        double INCREMENT;

        int activeTaskN;
        string activeTaskLabel;
        int maxNReached;

        private void Form1_Load(object sender, EventArgs e)
        {
            Run();
            RunGUI();
        }

        async void RunGUI()
        {
            var timeInStatePassedLine = GetSeries(chart_Main, "Time Passed");
            var timeInStateEstimateLine = GetSeries(chart_Main, "Time Estimate");

            while (true)
            {
                TopLevelControl.Text = Stopped
                    ? $"Tasks: {TaskCount}, stopped for: {FormatTime(TimeInStatePassed)}"
                    : $"Tasks: {TaskCount}, {activeTaskLabel}, n = {activeTaskN}, runs for: {FormatTime(TimeInStatePassed)}";

                if (Stopped)
                {
                    await Task.Delay(TimeSpan.FromSeconds(1));
                    continue;
                }

                if (!chart_Main.Series.Contains(timeInStatePassedLine))
                {
                    timeInStatePassedLine = GetSeries(chart_Main, "Time Passed");
                }

                timeInStatePassedLine.Points.Clear();
                timeInStatePassedLine.Points.AddXY(START_COUNT, TimeInStatePassed.TotalMilliseconds);
                timeInStatePassedLine.Points.AddXY(maxNReached, TimeInStatePassed.TotalMilliseconds);

                if (!chart_Main.Series.Contains(timeInStateEstimateLine))
                {
                    timeInStateEstimateLine = GetSeries(chart_Main, "Time Estimate");
                }

                timeInStateEstimateLine.Points.Clear();
                timeInStateEstimateLine.Points.AddXY(START_COUNT, TimeInStateEstimate.TotalMilliseconds);
                timeInStateEstimateLine.Points.AddXY(maxNReached, TimeInStateEstimate.TotalMilliseconds);

                await Task.Delay(TimeSpan.FromSeconds(1));
            }
        }

        Task Test(Action<int> toTest, Func<int, int> increment, string label, int n, Series series, bool newPoint)
        {
            return new Task(() =>
            {
                activeTaskN = n;
                activeTaskLabel = label;
                maxNReached = Math.Max(maxNReached, n);

                var fname = label + "_" + n + ".txt";
                var all = LoadFilteredHistoricalData(fname);
                var minTime = all.Any() ? all.Min() : long.MaxValue;
                if (all.Length >= TEST_TIMES)
                {
                    UpdatePoint(chart_Main, series, n, minTime, label);
                    AddNext();
                    return;
                }

                if (newPoint && all.Length == 0 || !newPoint)
                {
                    var stopwatch = new Stopwatch();
                    stopwatch.Start();
                    toTest(n);
                    stopwatch.Stop();

                    File.AppendAllLines(fname, new string[] { stopwatch.ElapsedMilliseconds.ToString() });

                    minTime = Math.Min(stopwatch.ElapsedMilliseconds, minTime);
                }

                UpdatePoint(chart_Main, series, n, minTime, label);
                AddNext();
                AddCurrent();

                void AddNext()
                {
                    var newValue = increment(n);
                    if (newPoint && newValue <= MAX_COUNT)
                    {
                        var timeEstimate = GetTimeEstimate(minTime, n, newValue);
                        AddTask(timeEstimate, (timeEstimate, Test(toTest, increment, label, newValue, series, true)));
                    }
                }

                void AddCurrent()
                {
                    var timesLeft = TEST_TIMES - all.Length;
                    if (timesLeft > 0)
                    {
                        AddTask((all.Length + 1) * minTime, (minTime, Test(toTest, increment, label, n, series, false)));
                    }

                }
            });
        }

        private void Button_Start_Click(object sender, EventArgs e)
        {
            if (ShouldStop)
            {
                MessageBox.Show("Waiting for process to stop");
                return;
            }

            if (!Stopped)
            {
                MessageBox.Show("Stop first");
                return;
            }

            if (!int.TryParse(textBox_StartMatrixSize.Text, out START_COUNT))
            {
                textBox_StartMatrixSize.BackColor = Color.Red;
            }
            textBox_StartMatrixSize.BackColor = Color.White;

            if (!int.TryParse(textBox_MaxMatrixSize.Text, out MAX_COUNT))
            {
                textBox_MaxMatrixSize.BackColor = Color.Red;
            }
            textBox_MaxMatrixSize.BackColor = Color.White;

            if (!int.TryParse(textBox_TestTimes.Text, out TEST_TIMES))
            {
                textBox_TestTimes.BackColor = Color.Red;
            }
            textBox_TestTimes.BackColor = Color.White;

            if (!double.TryParse(textBox_NIncrement.Text, out INCREMENT))
            {
                textBox_NIncrement.BackColor = Color.Red;
            }
            textBox_NIncrement.BackColor = Color.White;

            if (!int.TryParse(textBox_BlockSizeToTest.Text, out var bToTest))
            {
                textBox_NIncrement.BackColor = Color.Red;
            }
            textBox_NIncrement.BackColor = Color.White;

            var increment = radioButton_Add.Checked ? (Func<int, int>)AddIncrement : MultiplyIncrement;
            ClearSeries(chart_Main);
            maxNReached = 0;

            var tsks = new List<(long, Task)>();
            var series_1 = GetSeries(chart_Main, "Naive");
            AddTask(0, (0, Test(size => NaiveMultiplication(GetSquareMatrix(size), GetSquareMatrix(size), GetSquareMatrix(size)), increment, "N", START_COUNT, series_1, true)));

            var series_2 = GetSeries(chart_Main, "Optimized");
            AddTask(0, (0, Test(size => OptimizedMultiplication(GetSquareMatrix(size), GetSquareMatrix(size), GetSquareMatrix(size)), increment, "O", START_COUNT, series_2, true)));

            var blockSize = bToTest;
            var series_3 = GetSeries(chart_Main, $"Blocked {blockSize}");
            AddTask(0, (0, Test(size => OptimizedBlockedMultiplication(GetSquareMatrix(size), GetSquareMatrix(size), GetSquareMatrix(size), blockSize), increment, $"B{blockSize}", START_COUNT, series_3, true)));

            if (checkBox_UseReferences.Checked)
            {
                var used = new HashSet<int>
                {
                    blockSize
                };

                var step = 50;
                for (blockSize = step; blockSize <= 1000; blockSize += step)
                {
                    if (!used.Contains(blockSize))
                    {
                        used.Add(blockSize);
                        series_3 = GetSeries(chart_Main, $"Blocked {blockSize}");
                        AddTask(0, (0, Test(size => OptimizedBlockedMultiplication(GetSquareMatrix(size), GetSquareMatrix(size), GetSquareMatrix(size), blockSize), increment, $"B{blockSize}", START_COUNT, series_3, true)));
                    }
                }
            }
        }

        private string FormatTime(TimeSpan span) => $"{span.Hours}h {span.Minutes}m {span.Seconds}s";

        private void Button_Stop_Click(object sender, EventArgs e) => RequestStop();

        private int AddIncrement(int n) => (int)(n + INCREMENT);

        private int MultiplyIncrement(int n) => (int)(n * INCREMENT);
    }
}
