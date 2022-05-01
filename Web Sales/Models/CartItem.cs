﻿using Model.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Sales.Models
{
    [Serializable]
    public class CartItem
    {
        public Product Product { set; get; }
        public int Quantity { set; get; }
    }
}