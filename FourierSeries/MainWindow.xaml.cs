using org.mariuszgromada.math.mxparser;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Expression = org.mariuszgromada.math.mxparser.Expression;

namespace FourierSeries
{
    public partial class MainWindow : Window
    {
        List<Point> res = new List<Point>();
        Expression IntExpression;
        Expression intAexpresstion;
        Expression intBexpresstion;

        public double a=-5;
        public double b=5;

        public int n;

        public MainWindow()
        {
            InitializeComponent();
        }


        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            labelResult.Content = "";

            a = Convert.ToInt32(textBoxA.Text);
            b = Convert.ToInt32(textBoxB.Text);
            n = Convert.ToInt32(textBoxN.Text);

            Argument nInt = new Argument("n", n);

            IntExpression = new Expression("int(" + textBox3.Text + ", x, -3.14, 3.14)");
            intAexpresstion = new Expression("int((" + textBox3.Text + ")*(cos(n*x)), x, -3.14, 3.14)", nInt);
            intBexpresstion = new Expression("int((" + textBox3.Text + ")*(sin(n*x)), x, -3.14, 3.14)", nInt);

            res.Clear();


            FourierSeries fourier = Fourier(n);

            for (double x = a; x < b; x += 0.1)
            {
                double fx = 0;

                fx += fourier.a0 / 2;

                for (int i = 0; i < fourier.a.Count; i++)
                {
                    fx += (fourier.a[i] * Math.Cos((i + 1) * x))
                        + (fourier.b[i] * Math.Sin((i + 1) * x));
                }

                res.Add(new Point(x, fx));
            }

            CreateBigGraph("Ряд Фурье");
        }

        public FourierSeries Fourier(int nCount)
        {
            FourierSeries fourier = new FourierSeries();
            fourier.a = new List<double>();
            fourier.b = new List<double>();

            fourier.a0 = (1 / a) * IntExpression.calculate();

            for (int n = 1; n < nCount + 1; n++)
            {
                fourier.a.Add((1 / Math.PI) * Integral(intAexpresstion, n));
                fourier.b.Add((1 / Math.PI) * Integral(intBexpresstion, n));
            }

            return fourier;
        }

        public struct FourierSeries
        {
            public double a0;
            public List<double> a;
            public List<double> b;
        }

        private double Integral(Expression exp, double n)
        {
            exp.setArgumentValue("n", n);
            return exp.calculate();
        }

        private void CreateBigGraph(string name)
        {
            (this.DataContext as MainViewModel).SetPoints(res);
            (this.DataContext as MainViewModel).MyModel.Title = name;
        }
    }
}
