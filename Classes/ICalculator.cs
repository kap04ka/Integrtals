﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrtals.Classes
{
    public interface ICalculator
    {
        double Calculate(int splitCount, double upLim, double lowLim, Func<double, double> integral, bool parallel, out double time);

    }
}
