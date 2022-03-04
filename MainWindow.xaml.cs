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
            int splits = Convert.ToInt32(splitCount.Text);
            int upLim = Convert.ToInt32(upperLimit.Text);
            int lowLim = Convert.ToInt32(lowerLimit.Text);
            MessageBox.Show($"Количество разбиений = {splits}\nВерхний предел = {upLim}\nНижний предел = {lowLim}");
        }
    }
}
