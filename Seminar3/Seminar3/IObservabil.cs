﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar3
{
    public interface IObservabil
    {
        void Cupleaza(IObservator observator);
        void Decupleaza(IObservator observator);
    }
}