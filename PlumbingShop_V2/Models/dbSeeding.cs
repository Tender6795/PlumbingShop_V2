using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PlumbingShop_V2.Models
{
    public class dbSeeding : DropCreateDatabaseAlways<MyContext>
    {
        protected override void Seed(MyContext db)
        {
            //Производители
            db.Manufacturers.Add(new Manufacturer { Id = 1, Name = "Azzurra", Coutry = "Италия" });
            db.Manufacturers.Add(new Manufacturer { Id = 2, Name = "CERASTYLE", Coutry = "Турция" });
            db.Manufacturers.Add(new Manufacturer { Id = 3, Name = "VILLEROY and BOCH", Coutry = "Германия" });
            db.Manufacturers.Add(new Manufacturer { Id = 4, Name = "KOLO", Coutry = "Украина" });
            db.Manufacturers.Add(new Manufacturer { Id = 5, Name = "Radaway", Coutry = "Польша" });
            db.Manufacturers.Add(new Manufacturer { Id = 6, Name = "Serena", Coutry = "Китай" });
            db.Manufacturers.Add(new Manufacturer { Id = 7, Name = "Тест", Coutry = "Тест" });
            db.Toilets.Add(new Toilet
            {
                Id = 1,
                Name = "Pratica",
                Description = "Рассчитан под сиденье с крышкой PRA 1800 или PRA 1800/F от Azzurra",
                Price = 3630,
                Instalation = instalation.Напольный,
                Drain = drain.Горизонтальный,
                Tank = false,
                PathPicture = "https://i2.rozetka.ua/goods/3653687/copy_azzurra_glaze_glz110b1mbp_5ab21ae23e417_images_3653687591.jpg",
                ManufacturerId = 1
            });

            db.Toilets.Add(new Toilet
            {
                Id = 2,
                Name = "Noura",
                Description = "Рассчитан под сиденье с крышкой PRA 1800 или PRA 1800/F от Azzurra",
                Price = 6700,
                Instalation = instalation.Угловой,
                Drain = drain.Вертикальный,
                Tank = true,
                PathPicture = "https://i2.rozetka.ua/goods/2882492/copy_cera_style_018200_5a7869cc753cd_images_2882492943.jpg",
                ManufacturerId = 2
            });



            db.Bathes.Add(new Bath
            {
                Id = 3,
                Name = "Oberon",
                Description = "Описание",
                Price = 13500,
                PathPicture = "https://i1.rozetka.ua/goods/1670421/3903793_images_1670421925.jpg",
                ManufacturerId = 3,
                Form=form.Прямоугольная,
                Material=material.Кварил,
                Length= 170,
                Width=75
            });

            db.Bathes.Add(new Bath
            {
                Id = 4,
                Name = "COMFORT",
                Description = "Описание",
                Price = 5000,
                PathPicture = "https://i2.rozetka.ua/goods/1704482/kolo-comfort-170_images_1704482322.jpg",
                ManufacturerId = 4,
                Form = form.Угловая,
                Material = material.Акрил,
                Length = 180,
                Width = 85
            });


            db.ShowerCubicles.Add(new ShowerCubicle
            {
                Id = 5,
                Name = "Classic",
                Description = "Описание",
                Price = 6700,
                PathPicture = "https://i1.rozetka.ua/goods/1465375/radaway-30011-01-01_images_1465375924.jpg",
                ManufacturerId = 5,
                Form=form.Угловая,
                Material=material.Стекло,
                Length=170,
                Width=80,
                Pallet_height=0
            });


            db.ShowerCubicles.Add(new ShowerCubicle
            {
                Id = 6,
                Name = "8610 EW",
                Description = "Описание",
                Price = 8400,
                PathPicture = "https://i1.rozetka.ua/goods/5847952/serena_8610_ew_g_100_images_5847952920.jpg",
                ManufacturerId = 6,
                Form = form.Угловая,
                Material = material.Стекло,
                Length = 215,
                Width = 100,
                Pallet_height = 48
            });




        }
    }
}