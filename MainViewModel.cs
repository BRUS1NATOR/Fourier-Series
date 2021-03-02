using System.Collections.Generic;
using System.Windows;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace Simpson
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            Create();
        }

        public void SetPoints(List<Point> points)
        {
            Points.Clear();
            foreach (Point p in points)
            {
                this.Points.Add(new DataPoint(p.X, p.Y));
            }
            this.MyModel.ResetAllAxes();
            this.MyModel.InvalidatePlot(true);

        }

        private void Create()
        {
            this.MyModel = new PlotModel { Title= "Ряд Фурье", PlotType = PlotType.Cartesian };
            this.Points = new List<DataPoint>();
            MyModel.Series.Add(new LineSeries()
            {
                Color = OxyColors.Green,
                ItemsSource = Points,
                LineStyle = LineStyle.Solid,
                StrokeThickness = 1f
            });
        }

        public IList<DataPoint> Points{ get; private set; }

        public PlotModel MyModel { get; private set; }
    }
}
