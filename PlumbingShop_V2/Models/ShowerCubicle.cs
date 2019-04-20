using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlumbingShop_V2.Models
{
    public class ShowerCubicle:Product
    {
        public form Form { get; set; }
        public material Material { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public int Pallet_height { get; set; } //Высота поддона
    }
}