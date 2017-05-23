﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.Enums;
namespace Zoo.Interfaces
{
    interface IAnimal
    {
        AnimalState State { get; }
        int Health { get; }
    }
}
