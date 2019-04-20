using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlumbingShop_V2.Models
{
    public class Manufacturer  //Производитель
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Coutry { get; set; }
        //public ICollection<Product> products { get; set; }
        public virtual ICollection<Bath> baches { get; set; }
        public virtual ICollection<Toilet> toilets { get; set; }
        public virtual ICollection<ShowerCubicle> showerCubicles { get; set; }
        public Manufacturer()
        {
           // this.products = new List<Product>();
            //this.toilets = new List<Toilet>();
            //this.baches = new List<Bath>();
            //this.showerCubicles = new List<ShowerCubicle>();
        }
    }
}