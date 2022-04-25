using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Integrtals.Classes
{
    public class SimpsonCalculate : ICalculator
    {
        double ICalculator.Calculate(int splitCount, double upLim, double lowLim, Func<double, double> integral, out double time)
        {
            if (splitCount <= 0) throw new ArgumentException();

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            double h = (double)((upLim - lowLim) / splitCount);
            double sum1 = 0.0;
            double sum2 = 0.0;

            Parallel.For(1, splitCount+1, SumArea);

            void SumArea(int k)
            {
                double xk = lowLim + k * h;
                if (k <= splitCount - 1)
                {
                    sum1 += integral(xk);
                }

                double xk_1 = lowLim + (k - 1) * h;
                sum2 += integral((xk + xk_1) / 2);
            };

            /*for (int k = 1; k <= splitCount; k++)
            {
                double xk = lowLim + k * h;
                if (k <= splitCount - 1)
                {
                    sum1 += integral(xk);
                }

                double xk_1 = lowLim + (k - 1) * h;
                sum2 += integral((xk + xk_1) / 2);
            }*/

            double result = h / 3d * (1d / 2d * integral(lowLim) + sum1 + 2 * sum2 + 1d / 2d * integral(upLim));
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            time = ts.TotalMilliseconds;
            return result;
        }
    }
}
