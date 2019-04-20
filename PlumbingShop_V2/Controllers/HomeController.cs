using PlumbingShop_V2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace PlumbingShop_V2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //  MyContext db = new MyContext();
            // ViewBag.Toilets = db.Toilets.Include((Toilet t) => t.Manufacturer);
            //  ViewBag.Bath = db.Bathes.Include((Bath t) => t.Manufacturer);
            // ViewBag.ShowerCubicle = db.ShowerCubicles.Include((ShowerCubicle t) => t.Manufacturer);
            return View();
        }

        public ActionResult QAZXCVB()  //Проверка на админа
        {
            return View();
        }

        [HttpPost]
        public ActionResult QAZXCVB(string login, string password)
        {
            if (login == "login" && password == "password")
            {
                Session["login"] = "login";
                Session["password"] = "password";
                return RedirectToAction("ASDFGHJKL");
            }
            else
            {
                return RedirectToAction("Index");
            }

        }

        public ActionResult ASDFGHJKL()//Кабинет админа
        {
            //if (Session["login"]== "login" && Session["password"] == "password")
            //{
            //    return View();
            //}
            //else
            //{
            //    return RedirectToAction("Index");
            //}
            return View();
        }
        public ActionResult SHPRD()
        {
            return Redirect("/Home/ASDFGHJKL");
        }

        [HttpPost]
        public ActionResult SHPRD(string category)// админский показ категорий
        {
            //if ( Session["login"] == "login" && Session["password"] == "password")
            //{
            ViewBag.category = category;
            MyContext db = new MyContext();
            if (category == "Ванны")
            {
                ViewBag.Prods = db.Bathes;
            }
            else if (category == "Душевые кабинки")
            {
                ViewBag.Prods = db.ShowerCubicles;
            }
            else if (category == "Унитазы")
            {
                ViewBag.Prods = db.Toilets;
            }
            else if (category == "Производители")
            {

                return RedirectToAction("MNFCTRR");
            }
            else if (category == "Выход")
            {
                Session["login"] = "";
                Session["password"] = "";
                return RedirectToAction("Index");
            }
            else if(category== "Заказы" || category == "Выполненые Заказы")
            {
                return Redirect("/Home/BSKTSHW?category=" + category);
                
            }
            
            //}
            else
            {
                return RedirectToAction("Index");
            }
            return View();

        }
        [HttpPost]
        public ActionResult RMV(int id, string category, string btn)//выбор для удаления или редактирования товара
        {
            if (btn == "Удалить")
            {

                MyContext db = new MyContext();
                if (category == "Ванны")
                {
                    var p = db.Bathes.FirstOrDefault(a => a.Id == id);
                    db.Bathes.Remove(p);
                    db.SaveChanges();
                }
                else if (category == "Душевые кабинки")
                {
                    var p = db.ShowerCubicles.FirstOrDefault(a => a.Id == id);
                    db.ShowerCubicles.Remove(p);
                    db.SaveChanges();
                }
                else if (category == "Унитазы")
                {
                    var p = db.Toilets.FirstOrDefault(a => a.Id == id);
                    db.Toilets.Remove(p);
                    db.SaveChanges();
                }
                return Redirect("/Home/SHPRD");

            }
            else if (btn == "Редактировать")
            {
                return Redirect("/Home/RDCT?id=" + id + "&category=" + category);
            }
            else if (btn == "Добавить")
            {
                return Redirect("/Home/CRTPRD?category=" + category);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult RDCT(int id, string category) //Редактирование
        {
            MyContext db = new MyContext();
            ViewBag.category = category;
            ViewBag.Manufacturer = db.Manufacturers.ToList();

            if (id != 0)
            {
                if (category == "Ванны")
                {
                    ViewBag.form = Enum.GetValues(typeof(form));
                    ViewBag.material = Enum.GetValues(typeof(material));
                    var p = db.Bathes.FirstOrDefault(a => a.Id == id);
                    ViewBag.Prods = p;
                }
                else if (category == "Душевые кабинки")
                {
                    ViewBag.form = Enum.GetValues(typeof(form));
                    ViewBag.material = Enum.GetValues(typeof(material));
                    var p = db.ShowerCubicles.FirstOrDefault(a => a.Id == id);
                    ViewBag.Prods = p;
                }
                else if (category == "Унитазы")
                {
                    ViewBag.instalation = Enum.GetValues(typeof(instalation));
                    ViewBag.drain = Enum.GetValues(typeof(drain));
                    var p = db.Toilets.FirstOrDefault(a => a.Id == id);
                    ViewBag.Prods = p;
                }
            }

            return View();
        }


        [HttpPost]
        public ActionResult RDCT(Product p, string category, bool Tank = false, instalation Instalation = instalation.Напольный, drain Drain = drain.Вертикальный, form Form = form.Ассиметричная, material Material = material.Акрил, int Length = 0, int Width = 0, int Pallet_height = 0)
        {
            MyContext db = new MyContext();
            if (category == "Ванны")
            {
                var prod = db.Bathes.FirstOrDefault(a => a.Id == p.Id);
                prod.Form = Form;
                prod.Material = Material;
                prod.Length = Length;
                prod.Width = Width;
                prod.Name = p.Name;
                prod.Description = p.Description;
                prod.Price = p.Price;
                prod.PathPicture = p.PathPicture;
                prod.ManufacturerId = p.ManufacturerId;
                db.SaveChanges();
            }
            else if (category == "Душевые кабинки")
            {
                var prod = db.ShowerCubicles.FirstOrDefault(a => a.Id == p.Id);
                prod.Form = Form;
                prod.Material = Material;
                prod.Length = Length;
                prod.Width = Width;
                prod.Pallet_height = Pallet_height;
                prod.Name = p.Name;
                prod.Description = p.Description;
                prod.Price = p.Price;
                prod.PathPicture = p.PathPicture;
                prod.ManufacturerId = p.ManufacturerId;
                db.SaveChanges();
            }
            else if (category == "Унитазы")
            {
                var prod = db.Toilets.FirstOrDefault(a => a.Id == p.Id);
                prod.Instalation = Instalation;
                prod.Drain = Drain;
                prod.Tank = Tank;
                prod.Name = p.Name;
                prod.Description = p.Description;
                prod.Price = p.Price;
                prod.PathPicture = p.PathPicture;
                prod.ManufacturerId = p.ManufacturerId;
                db.SaveChanges();
            }

            return Redirect("/Home/ASDFGHJKL");
        }
        public ActionResult MNFCTRR()
        {
            MyContext db = new MyContext();
            ViewBag.Manufacturers = db.Manufacturers.Include(a => a.showerCubicles).Include(a => a.toilets).Include(a => a.baches).ToList();
            return View();
        }
        [HttpPost]
        public ActionResult MNFCTRRRMV(Manufacturer m, string btn)
        {
            if (btn == "Удалить")
            {
                MyContext db = new MyContext();
                var t = db.Manufacturers.FirstOrDefault(a => a.Id == m.Id);
                db.Manufacturers.Remove(t);
                db.SaveChanges();
                return Redirect("/Home/MNFCTRR");
            }
            else if (btn == "Редактировать")
            {
                return Redirect("/Home/MNFCTRRRDCT/?id=" + m.Id);
            }
            else if (btn == "Добавить")
            {
                return Redirect("/Home/MNFCTRRRDCT/?id=" + 0);
            }
            return View();
        }
        [HttpGet]
        public ActionResult MNFCTRRRDCT(int id)
        {
            MyContext db = new MyContext();
            if (id != 0)
            {
                ViewBag.Manufacturers = db.Manufacturers.FirstOrDefault(a => a.Id == id);
                ViewBag.redact = 1;
            }
            else
            {
                ViewBag.redact = 0;
            }
            return View();
        }

        [HttpPost]
        public ActionResult MNFCTRRRDCT(Manufacturer m)
        {
            MyContext db = new MyContext();
            if (m.Id != 0)
            {
                var n = db.Manufacturers.FirstOrDefault(a => a.Id == m.Id);
                n.Name = m.Name;
                n.Coutry = m.Coutry;
            }
            else
            {
                Manufacturer n = new Manufacturer();
                n.Name = m.Name;
                n.Coutry = m.Coutry;
                db.Manufacturers.Add(n);
            }
            db.SaveChanges();
            return Redirect("/Home/MNFCTRR");
        }
        [HttpGet]
        public ActionResult CRTPRD(string category)
        {
            MyContext db = new MyContext();
            ViewBag.category = category;
            ViewBag.Manufacturer = db.Manufacturers.ToList();
            if (category == "Ванны")
            {
                ViewBag.form = Enum.GetValues(typeof(form));
                ViewBag.material = Enum.GetValues(typeof(material));
            }
            else if (category == "Душевые кабинки")
            {
                ViewBag.form = Enum.GetValues(typeof(form));
                ViewBag.material = Enum.GetValues(typeof(material));

            }
            else if (category == "Унитазы")
            {
                ViewBag.instalation = Enum.GetValues(typeof(instalation));
                ViewBag.drain = Enum.GetValues(typeof(drain));
            }
            return View();
        }
        [HttpPost]
        public ActionResult CRTPRD(string category, Product p, bool Tank = false, instalation Instalation = instalation.Напольный, drain Drain = drain.Вертикальный, form Form = form.Ассиметричная, material Material = material.Акрил, int Length = 0, int Width = 0, int Pallet_height = 0)
        {
            MyContext db = new MyContext();
            if (category == "Ванны")
            {
                Bath prod = new Bath();
                prod.Form = Form;
                prod.Material = Material;
                prod.Length = Length;
                prod.Width = Width;
                prod.Name = p.Name;
                prod.Description = p.Description;
                prod.Price = p.Price;
                prod.PathPicture = p.PathPicture;
                prod.ManufacturerId = p.ManufacturerId;
                db.Bathes.Add(prod);
                db.SaveChanges();
            }
            else if (category == "Душевые кабинки")
            {
                ShowerCubicle prod = new ShowerCubicle();
                prod.Form = Form;
                prod.Material = Material;
                prod.Length = Length;
                prod.Width = Width;
                prod.Pallet_height = Pallet_height;
                prod.Name = p.Name;
                prod.Description = p.Description;
                prod.Price = p.Price;
                prod.PathPicture = p.PathPicture;
                prod.ManufacturerId = p.ManufacturerId;
                db.ShowerCubicles.Add(prod);
                db.SaveChanges();
            }
            else if (category == "Унитазы")
            {
                Toilet prod = new Toilet();
                prod.Instalation = Instalation;
                prod.Drain = Drain;
                prod.Tank = Tank;
                prod.Name = p.Name;
                prod.Description = p.Description;
                prod.Price = p.Price;
                prod.PathPicture = p.PathPicture;
                prod.ManufacturerId = p.ManufacturerId;
                db.Toilets.Add(prod);
                db.SaveChanges();
            }
            return Redirect("/Home/ASDFGHJKL");
        }

        [HttpGet]
        public ActionResult ShowToilet(string category)
        {
            MyContext db = new MyContext();
            ViewBag.category = category;
            if (category == "Унитазы")
            {
                ViewBag.Prod = db.Toilets.Include((Toilet t) => t.Manufacturer);
            }
            if (category == "Ванны")
            {
                ViewBag.Prod = db.Bathes.Include((Bath t) => t.Manufacturer);
            }
            if (category == "Душевые кабинки")
            {
                ViewBag.Prod = db.ShowerCubicles.Include((ShowerCubicle t) => t.Manufacturer);
            }
           
            return View();
        }

        [HttpGet]
        public ActionResult ShowOneProduct(int id, string category)
        {
            MyContext db = new MyContext();
            if (category == "Ванны")
            {
                ViewBag.Prods = db.Bathes.Include((Bath t) => t.Manufacturer).FirstOrDefault(a => a.Id == id);
                ViewBag.category = "Ванны";
            }
            else if (category == "Душевые кабинки")
            {
                ViewBag.Prods = db.ShowerCubicles.Include((ShowerCubicle t) => t.Manufacturer).FirstOrDefault(a => a.Id == id);
                ViewBag.category = "Душевые кабинки";
            }
            else if (category == "Унитазы")
            {
                ViewBag.Prods = db.Toilets.Include((Toilet t) => t.Manufacturer).FirstOrDefault(a => a.Id == id);
                ViewBag.category = "Унитазы";
            }
            else
            {
                ViewBag.Prod = "";
            }
            return View();
        }
        public ActionResult AddToTmpBasket()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddToTmpBasket(string category, int Id, string Name, double Price, string PathPicture)
        {
            if (Session[Name] == null)
            {
                TmpBasket tmpBasket = new TmpBasket();
                tmpBasket.Id = Id;
                tmpBasket.Category = category;
                tmpBasket.Name = Name;
                tmpBasket.Price = Price;
                tmpBasket.Count = 1;
                tmpBasket.PathPicture = PathPicture;
                Session[Name] = tmpBasket;
            }
            else
            {
                ((TmpBasket)Session[Name]).Count++;
                int count = ((TmpBasket)Session[Name]).Count;
            }
            // ViewBag.ses = Session;
            return View();
        }

        public ActionResult ChangeCount(string Name, double Price,
            string SesName, string btn, int Count)
        {
            if (btn == "+")
            {
                ((TmpBasket)Session[Name]).Count++;
            }
            else if (btn == "-")
            {
                if (((TmpBasket)Session[Name]).Count == 0)
                {
                    ((TmpBasket)Session[Name]).Count = 0;
                }
                else
                {
                    ((TmpBasket)Session[Name]).Count--;
                }
            }
            else if (btn == "Купить" && Session.Count>0)
            {
                return Redirect("/Home/Buy");
            }

            return Redirect("/Home/AddToTmpBasket");
        }

        public ActionResult Buy()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Buy(string BuerName, string Phone, string Email, string btn)
        {
            if (btn =="Сделать заказ")
            {
               
                    for (int i = 0; i < Session.Count; i++)
                    {
                    if (Session[i] != null)
                    {
                        Basket b = new Basket();
                        b.Name = ((TmpBasket)Session[i]).Name;
                        b.Count = ((TmpBasket)Session[i]).Count;
                        b.Price = ((TmpBasket)Session[i]).Price;
                        b.SumPrice = ((TmpBasket)Session[i]).Count * ((TmpBasket)Session[i]).Price;
                        b.Email = Email;
                        b.isDone = false;
                        b.BuerName = BuerName;
                        b.Phone = Phone;
                        MyContext db = new MyContext();
                        db.Baskets.Add(b);
                        db.SaveChanges();
                        Session[i] = null;
                    }
                }
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }

        [HttpGet]
        public ActionResult BSKTSHW(string category)
        {
            MyContext db = new MyContext();
            if (category == "Заказы")
            {
                ViewBag.Basket = db.Baskets.Where(a=>a.isDone==false);
            }
            else
            {
                ViewBag.Basket = db.Baskets.Where(a => a.isDone == true);
            }
            ViewBag.category = category;
            return View();
        }
        [HttpPost]
        ActionResult BSKTSHW(int id,string category)
        {
            MyContext db = new MyContext();
            var b = db.Baskets.FirstOrDefault(a => a.Id == id);
            b.isDone = !b.isDone;
            db.SaveChanges();
            if (category == "Заказы")
            {
                ViewBag.Basket = db.Baskets.Where(a => a.isDone == false);
            }
            else
            {
                ViewBag.Basket = db.Baskets.Where(a => a.isDone == true);
            }
            ViewBag.category = category;
            return View();
        }



    }
}