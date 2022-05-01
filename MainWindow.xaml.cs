using Integrtals.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OxyPlot;
using OxyPlot.Series;

namespace Integrtals
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btCalculate_Click(object sender, RoutedEventArgs e)
        {
            DoCalculate();
        }
        private void btGraph_Click(object sender, RoutedEventArgs e)
        {
            var pm = new PlotModel()
            {
                Title = "32x - log(10x) - 41"
            };
            var lineSeries = new LineSeries();
            bool parallel = false;
            int upLim = Convert.ToInt32(upperLimit.Text);
            int lowLim = Convert.ToInt32(lowerLimit.Text);
            ICalculator calcultGraph = new SimpsonCalculate();

            for (int i = 1; i < 1000; i++)
            {
                double time = 0;
                double result = calcultGraph.Calculate(i, upLim, lowLim, x => x * x, parallel, out time);
                lineSeries.Points.Add(new DataPoint(i, time));
            }

            pm.Series.Add(lineSeries);
            Graph.Model = pm;
        }
        private ICalculator GetCalculator()
        {
            return methods.SelectedIndex switch
            {
                0 => new SimpsonCalculate(),
                1 => new RectangelCalculate(),
                _ => throw new NotImplementedException(),
            };
        }

        private new bool GetType()
        {
            return parallel.SelectedIndex switch
            {
                0 => false,
                1 => true,
                _ => throw new NotImplementedException(),
            };
        }

        private void DoCalculate()
        {
            int splits = Convert.ToInt32(splitCount.Text);
            int upLim = Convert.ToInt32(upperLimit.Text);
            int lowLim = Convert.ToInt32(lowerLimit.Text);
            bool parallel = GetType();
            double time = 0;

            ICalculator calcult = GetCalculator();
            double result = calcult.Calculate(splits, upLim, lowLim, x => x * x, parallel, out time);
            MessageBox.Show($"Результат вычислений = {result.ToString()}");
        }
    }
}
