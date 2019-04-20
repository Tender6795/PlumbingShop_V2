using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlumbingShop_V2.Models
{
    interface IProduct
    {
         int Id { get; set; }
         string Name { get; set; }
         string Description { get; set; }
         double Price { get; set; }
         string PathPicture { get; set; }
         int ManufacturerId { get; set; }
         Manufacturer Manufacturer { get; set; }
    }
}
