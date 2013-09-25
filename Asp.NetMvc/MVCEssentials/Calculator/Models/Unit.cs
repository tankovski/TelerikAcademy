using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Calculator.Models
{
    public class Unit
    {
        public string Name { get; set; }
        public double Value { get; set; }

        public Unit(string name)
        {
            this.Name = name;
        }
    }
}