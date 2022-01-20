﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Basket : BaseEntity
    {
        public string BuyerId { get; set; }
        public ICollection<BasketItem> Items { get; set; } = new HashSet<BasketItem>(); 
    }
}
