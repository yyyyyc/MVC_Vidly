﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Country
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int  Area { get; set; }
        public int Population { get; set; }
    }
}