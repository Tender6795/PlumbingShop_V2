using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlumbingShop_V2.Models
{
    public class TmpBasket
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public string PathPicture { get; set; }
    }
}