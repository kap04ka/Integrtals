using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrtals.Classes
{
    class RectangelCalculate : ICalculator
    {
        double ICalculator.Calculate(double splitCount, double upLim, double lowLim, Func<double, double> integral, out double time)
        {
            double h = (upLim - lowLim) / splitCount;
            double sum = 0.0;

            for (int i = 0; i < splitCount; i++)
            {
                sum += integral(lowLim + h * i);
            }
            time = 0;
            return h * sum;
        }
    }
}
