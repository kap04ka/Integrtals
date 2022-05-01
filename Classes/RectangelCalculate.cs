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
        double ICalculator.Calculate(int splitCount, double upLim, double lowLim, Func<double, double> integral, bool parallel, out double time)
        {
            if (splitCount <= 0) throw new ArgumentException();

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            double h = (upLim - lowLim) / splitCount;
            double area = 0;
            double sums = 0;

            if (parallel)
            {
                object monitor = new object();

                Parallel.For(1, splitCount, i =>

                {
                    lock (monitor) area += integral(lowLim + h * i);

                });
            }

            else
            {
                for (int i = 1; i < splitCount; i++)
                {
                    area += integral(lowLim + h * i);
                }

            }

            area += (integral(lowLim) + integral(upLim)) / 2;

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            time = ts.TotalMilliseconds;
            return h * area;

        }
    }
}
