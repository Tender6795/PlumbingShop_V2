using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlumbingShop_V2.Models
{
    public class Basket   //Корзина
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public double Price { get; set; }
        public double SumPrice { get; set; }
        public int Count { get; set; }
        public string BuerName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool isDone { get; set; }
    }
}