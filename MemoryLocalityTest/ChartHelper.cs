using System;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MemoryLocalityTest
{
    internal static class ChartHelper
    {
        public static Series GetSeries(Chart chart, string seriesName)
        {
            var series = new Series(seriesName)
            {
                ChartType = SeriesChartType.Line,
                BorderWidth = 3,
            };
            chart.Series.Add(series);
            return series;
        }

        public static void UpdatePoint(Chart chart, Series series, int xValue, long yValue, string label) => chart.Invoke(new MethodInvoker(delegate
        {
            var enumerator = series.Points.GetEnumerator();
            while (enumerator.MoveNext() && enumerator.Current.XValue != xValue)
            {
                enumerator.Current.Label = string.Empty;
            }

            if (enumerator.Current is null)
            {
                series.Points.Add(new DataPoint(xValue, yValue) { Label = label });
                SortSeries(chart);
                return;
            }

            var displayedValue = (long)Math.Min(yValue, enumerator.Current.YValues[0]);
            enumerator.Current.YValues = new double[] { displayedValue };

            SortSeries(chart);
        }));

        public static void SortSeries(Chart chart)
        {
            var series = chart.Series.ToList();
            chart.Series.Clear();

            var nonEmptySeries = series.Where(s => s.Points.Any());
            var emptySeries = series.Where(s => !s.Points.Any());
            series = nonEmptySeries.OrderByDescending(s => s.Points.Count).ThenBy(s => s.Points.Last().YValues.First()).Concat(emptySeries).ToList();

            foreach (var s in series)
            {
                chart.Series.Add(s);
            }
        }

        public static void ClearSeries(Chart chart) => chart.Series.Clear();
    }
}
