﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProducerConsumer
{
    class Product
    {
        public string Name { get; set; }
        
        public Product(string name)
        {
            Name = name;
        }
    }
}
