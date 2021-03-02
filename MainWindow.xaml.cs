using org.mariuszgromada.math.mxparser;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Wpf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Expression = org.mariuszgromada.math.mxparser.Expression;

namespace Simpson
{
    public partial class MainWindow : Window
    {
        List<Point> res = new List<Point>();
        Expression IntExpression;
        Expression intAexpresstion;
        Expression intBexpresstion;

        public double a;
        public double b;
        public int n;

        public MainWindow()
        {
            InitializeComponent();
        }


        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            labelResult.Content = "";

            a = -Math.PI;
            b = Math.PI;

            Argument aInt = new Argument("a", a);
            Argument bInt = new Argument("b", b);
            n = Convert.ToInt32(textBoxN.Text);
            Argument nInt = new Argument("n", n);

            aInt.setArgumentValue(a);
            bInt.setArgumentValue(b);

            IntExpression = new Expression("int("+ textBox3.Text+",x,a,b)", aInt, bInt);
            intAexpresstion = new Expression("int((" + textBox3.Text + ")*(cos(n*x)), x, -3.14, 3.14)",  nInt);
            intBexpresstion = new Expression("int((" + textBox3.Text + ")*(sin(n*x)), x, -3.14, 3.14)",  nInt);

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

            fourier.a0 = (1 / Math.PI) * fIntegral();

            for (int n = 1; n < nCount+1; n++)
            {
                fourier.a.Add((1 / Math.PI) * Aintegral(n));
                fourier.b.Add((1 / Math.PI) * Bintegral(n));
            }

            return fourier;
        }


        public struct FourierSeries
        {
            public double a0;
            public List<double> a;
            public List<double> b;
        }


        private double fIntegral()
        {
            return IntExpression.calculate();
        }

        private double Aintegral(double n)
        {
            intAexpresstion.setArgumentValue("n", n);
            return intAexpresstion.calculate();
        }

        private double Bintegral(double n)
        {
            intBexpresstion.setArgumentValue("n", n);
            return intBexpresstion.calculate();
        }


        private void CreateBigGraph(string name)
        {
            (this.DataContext as MainViewModel).SetPoints(res);
            (this.DataContext as MainViewModel).MyModel.Title = name;
        }


    }
}
