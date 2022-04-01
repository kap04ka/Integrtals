using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace Integrtals.Classes
{
    public class RectangelCalculate : ICalculator
    {
        double ICalculator.Calculate(double splitCount, double upLim, double lowLim, Func<double, double> integral, out double time)
        {
            if (splitCount <= 0) throw new ArgumentException();

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            double h = (upLim - lowLim) / splitCount;
            double area = 0;
            for (int i = 1; i < splitCount; i++)
            {
                double currentX = lowLim + h * i;
                area += integral(currentX);
            }

            area += (integral(lowLim) + integral(upLim)) / 2;

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            time = ts.TotalMilliseconds;
            return h * area;

        }
    }
}
