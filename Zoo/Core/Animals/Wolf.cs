﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.Interfaces;
namespace Zoo.Core.Animals
{
    public class Wolf : Animal
    {
        public Wolf(string name, IStrategy strategy) : base(name, 4, strategy)
        {

        }
    }
}