using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Models;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace toursm.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            this._context = context;
        }
        public ActionResult Index(string email="")
        {
                 allproject ad = new allproject();
                if (email != "")
                {
                    var cus = _context.customers.Where(x => x.email == email).SingleOrDefault();
                    ad.email = cus.email;
                    ad.name = cus.name;
                }
                ad.triplists = _context.Trips.Select(s => new triplist
                {
                    tripplace = s.tripplace,
                    godate = s.godate,
                    comingdate = s.comingdate,
                    Id = s.Id,
                    image = s.image

                }).ToList();


                return View(ad);
            
        }
        public ActionResult alltrips(string email = "",string triptype="")
        {
            allproject ad = new allproject();
            if (email != "")
            {
                var cus = _context.customers.Where(x => x.email == email).SingleOrDefault();
                ad.email = cus.email;
                ad.name = cus.name;
            }
            if (triptype == "")
            {
                ad.triplists = _context.Trips.Select(s => new triplist
                {
                    tripplace = s.tripplace,
                    godate = s.godate,
                    comingdate = s.comingdate,
                    Id = s.Id,
                    city=s.city,
                    image = s.image

                }).ToList();
            }
            else
            {
                ad.triplists = _context.Trips.Where(x=>x.type==triptype).Select(s => new triplist
                {
                    tripplace = s.tripplace,
                    godate = s.godate,
                    comingdate = s.comingdate,
                    Id = s.Id,
                    city = s.city,

                    image = s.image

                }).ToList();
            }
          


            return View(ad);
        }
        public ActionResult login()
        {

            return View();
        }

        public ActionResult deletebooking(int bookid,string email="")
        {
                var m = _context.bookings.Where(x => x.Id == bookid).FirstOrDefault();
               _context.bookings.Remove(m);
               _context.SaveChanges();
                return RedirectToAction("bookingList",new { email=email});
           

        }
       
        [HttpPost]
        ////public ActionResult login(customer h)
        ////{
        ////    try
        ////    {

        ////        customer userloginin = _context.customers.Where(x => x.email == h.email && x.password == h.password).SingleOrDefault();
        ////        if (userloginin != null)
        ////        {

        ////            Session["ad_id"] = h.email.ToString();
        ////            return RedirectToAction("Index", new { email = Session["ad_id"] });

        ////        }
        ////        else
        ////        {
        ////            ViewBag.error = "Invalid username or password";
        ////            return RedirectToAction("login");


        ////        }
        ////    }
        ////    catch
        ////    {
        ////        Response.Write("<script>alert('خطأ فى كلمة المرور'); </script>");
        ////        return RedirectToAction("login");
        ////    }

        ////}
        ///

        [HttpPost]
        public async Task<IActionResult> Login(customer model)
        {
          
            var user = await _context.customers
                .FirstOrDefaultAsync(x => x.email == model.email && x.password == model.password);

            if (user != null)
            {
                // Store session (must be enabled in Startup)
                HttpContext.Session.SetString("ad_id", user.email);
                return RedirectToAction("Index", new { email =user.email });

            }

            ViewBag.Error = "Invalid username or password";
            return View(model);
        }
        public ActionResult signup()
        {

            return View();
        }
        [HttpPost]
        public ActionResult signup(customer n)
        {
            try
            {
                customer m = new customer();
                m.email = n.email;
                m.name = n.name;
                m.adress = n.adress;
                m.password = n.password;
                m.phone = n.phone;
                _context.customers.Add(m);
                _context.SaveChanges();
                return RedirectToAction("login");
            }
            catch
            {
                return View();

            }

        }
        public ActionResult Guids(string email="")
        {
            allproject ad = new allproject();
            if (email != "")
            {
                var cus = _context.customers.Where(x => x.email == email).SingleOrDefault();
                ad.email = cus.email;
                ad.name = cus.name;
            }
            ad.guidLists = _context.guids.Select(s => new guidList
            {
                name = s.name,
                image = s.image,
                language = s.language,
                Id = s.Id

            }).ToList();


            return View(ad);
        }
        public ActionResult Service(string email="")
        {
            allproject ad = new allproject();
            if (email != "")
            {
                var cus = _context.customers.Where(x => x.email == email).SingleOrDefault();
                ad.email = cus.email;
                ad.name = cus.name;
            }
            return View(ad);
        }
      
        public ActionResult tripdetials(int tripid,string mess="",string email="")
        {
            allproject b = new allproject();
            if (email != "")
            {
                var cus = _context.customers.Where(x => x.email == email).SingleOrDefault();
                b.email = cus.email;
                b.name = cus.name;
            }
            var v = _context.Trips.Where(x => x.Id == tripid).SingleOrDefault();
            b.Id = v.Id;
            b.tripplace = v.tripplace;
            b.godate = v.godate;
            //b.availableadultno = v.availableadultno;
            //b.availablekideno = v.availablekideno;
            b.comingdate = v.comingdate;
            b.travelmethod = v.travelmethod;
            b.traveldes = v.traveldes;
            //b.childprice = v.childprice;
            //b.adultchild = v.adultchild;
            b.hotel = v.hotel;
            b.image = v.image;
            b.city = v.city;
            b.tiketprice = v.tiketprice;
            b.time = v.time;

            //b.mess = mess;
            return View(b);
        }
        public ActionResult booking(int tripid, string mess = "",
            string email = "",string hotel="",string transport="")
        {
            allproject b = new allproject();
            if (email != "")
            {
                var cus = _context.customers.Where(x => x.email == email).SingleOrDefault();
                b.email = cus.email;
                b.name = cus.name;
            }
            var v = _context.Trips.Where(x => x.Id == tripid).SingleOrDefault();
            b.Id = v.Id;
            b.tripplace = v.tripplace;
            b.godate = v.godate;
            b.comingdate = v.comingdate;
            b.travelmethod = v.travelmethod;
            b.traveldes = v.traveldes;
            b.hotel = hotel;
            b.image = v.image;
            b.city = v.city;
            b.tiketprice = v.tiketprice;
            b.transport=transport;
            

            return View(b);
        }
        [HttpPost]
        public ActionResult addbook(bookModel bookModel)
        {
            booking b = new booking();
            b.name = bookModel.name; 
            b.phone = bookModel.phone;
            b.idcard = bookModel.idcard;
            b.tripid = bookModel.Id;
            b.date = DateTime.Now;
            b.hotel= bookModel.hotel;
            b.travelerNo = bookModel.travelerNo;
            b.transport = bookModel.transport;
           if(_context.customers.Where(x=>x.email==bookModel.email).SingleOrDefault()==null)
            {
                return RedirectToAction("booking", new { mess="الايميل الذى ادخلته غير صحيح", tripid = bookModel.Id,email=bookModel.email });

            }
            else
            {
                b.email = bookModel.email;
                _context.bookings.Add(b);
                _context.SaveChanges();
                return RedirectToAction("bookingList", new { mess = "تم الحجز بنجاح",email = bookModel.email }); ;

            }
           
        }
        public ActionResult bookingList(string email = "")
        {
            allproject ad = new allproject();
            if (email != "")
            {
                var cus = _context.customers.Where(x => x.email == email).SingleOrDefault();
                ad.email = cus.email;
                ad.name = cus.name;
            }
            ad.booklists = _context.bookings.Where(x=>x.email==email).Select(s => new booklist
            {
                name = s.name,
                //adultage = s.adultage,
                //kideage = s.kideage,
                idcard=s.idcard,
                tripid=s.tripid,
                phone=s.phone,
                Id = s.Id,
                travelNo=s.travelerNo

            }).ToList();
            return View(ad);
        }
        public ActionResult opin(string email = "")
        {
            allproject ad = new allproject();
            if (email != "")
            {
                var cus = _context.customers.Where(x => x.email == email).SingleOrDefault();
                ad.email = cus.email;
                ad.name = cus.name;
            }
           
            return View(ad);
        }
        [HttpPost]
        public ActionResult addopin(allproject allproject)
        {
            opin n = new opin();
            n.name = allproject.name;
            n.opin1 = allproject.opin1;
            _context.opins.Add(n);
            _context.SaveChanges();
            return RedirectToAction("opinList", new { email=allproject.email });

        }
        public ActionResult opinList(string email = "")
        {
            allproject n = new allproject();
            n.opins = _context.opins.ToList();
            return View(n);
        }
        public IActionResult Hotels (int tripid, string mess = "", string email = "")
        {
            ViewBag.tripid = tripid;
            ViewBag.email = email;
            var hotels = _context.Hotels.ToList();
            return View(hotels);
        }

        public IActionResult Transports(int tripid, string mess = ""
            , string email = "",string hotel="")
        {
            ViewBag.tripid = tripid;
            ViewBag.email = email;
            ViewBag.hotel = hotel;

            var hotels = _context.Transportaions.ToList();
            return View(hotels);
        }

    }
}