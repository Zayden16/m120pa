﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjectNeptune.Model
{
    public class Car
    {
        public int CarId { get; set; }
        public string Marke { get; set; }
        public string Model { get; set; }
        public string FIN {
            get => FIN;
            set
            {
                if (Regex.IsMatch(value, @"^[0-9]{17}$"))
                {
                    FIN = value;
                }
            }
        }
        public string Kennzeichen { get; set; }
    }
}
