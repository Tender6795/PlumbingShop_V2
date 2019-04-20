using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlumbingShop_V2.Models
{
    public enum form { Ассиметричная, Круглая, Овальная, Прямоугольная, Угловая,Квадратная,Пятиугольная }//Формаая
    public enum material { Акрил, Кварил, Сталь, Исскуственный_камень,Стекло,Полистирол }//Материал
    public class Bath : Product
    {
        public form Form { get; set; }
        public material Material { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
    }
}