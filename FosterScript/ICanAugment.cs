﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FosterScriptLib
{
    internal interface ICanAugment
    {
        public List<ICanSupplement> Inputs { get; set; }
    }
}