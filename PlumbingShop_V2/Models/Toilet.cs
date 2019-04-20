using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlumbingShop_V2.Models
{
   public enum instalation {Напольный,Подвесной,Угловой } //Тип установки
    public enum drain { Вертикальный, Горизонтальный, Косой,Универсальный }//Тип слива
    public class Toilet : Product
    {
        public instalation Instalation { get; set; }
        public drain Drain { get; set; }
        public bool Tank { get; set; }//Бачок есть или нет

    }
}