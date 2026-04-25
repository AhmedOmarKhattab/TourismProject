using Microsoft.AspNetCore.Mvc;
using OnlineShop.Data;
using OnlineShop.Dtos;
using OnlineShop.Helpers;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace toursm.Controllers
{
    public class adminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public adminController(ApplicationDbContext context)
        {
            this._context = context;
        }
        // GET: admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult bookList()
        {
            return View(_context.bookings.ToList());
        }
      
        public ActionResult addtrip()
        {
            return View();
        }
        public ActionResult tripList()
        {
            return View(_context.Trips.ToList());
        }
        public ActionResult guidList()
        {
            return View(_context.guids.ToList());
        }
        public ActionResult Deletetrip(int tripid)
        {
               var m = _context.Trips.Where(x => x.Id == tripid).FirstOrDefault();
                _context.Trips.Remove(m);
                _context.SaveChanges();
                return RedirectToAction("tripList");
            
        }
        public ActionResult Deleteguid(int idguid)
        {
                var m = _context.guids.Where(x => x.Id == idguid).FirstOrDefault();
                _context.guids.Remove(m);
                _context.SaveChanges();
                return RedirectToAction("guidList");
            
        }
        public ActionResult Deletebook(int i_contextook)
        {
                var m = _context.bookings.Where(x => x.Id == i_contextook).FirstOrDefault();
                _context.bookings.Remove(m);
                _context.SaveChanges();
                return RedirectToAction("bookList");

        }
        public ActionResult userlist()
        {
            return View(_context.customers.ToList());
        }
        [HttpPost]
        public ActionResult addtrip(Trip trip, IFormFile imgfile)
        {
            string img = DocumentSettings.UploadImage(imgfile, "images");
            Trip b = new Trip();
            b.tripplace = trip.tripplace;
            b.travelmethod = trip.travelmethod;
            b.traveldes = trip.traveldes;
            b.hotel = trip.hotel;
            b.travelmethod = trip.travelmethod;
            b.time = trip.time;
            b.godate = trip.godate;
            //b.childprice = trip.childprice;
            //b.adultchild = trip.adultchild;
            b.image = img;
            //b.availableadultno = trip.availableadultno;
            //b.availablekideno = trip.availablekideno;

            b.comingdate = trip.comingdate;
            b.city = trip.city;
            _context.Trips.Add(b);
            _context.SaveChanges();
            return RedirectToAction("addtrip");
        }
        public ActionResult addguids()
        {
            return View();
        }
        [HttpPost]
        public  ActionResult addguide(guid guids, IFormFile imgfile)
        {
            guid b = new guid();
            b.name = guids.name;
            b.language = guids.language;
            b.image =  DocumentSettings.UploadImage(imgfile, "images");
            _context.guids.Add(b);
            _context.SaveChanges();
            return RedirectToAction("addguids");
        }
        //public string uploadimgfile(HttpPostedFileBase file)
        //{
        //    Random r = new Random();
        //    string path = "-1";
        //    int random = r.Next();

        //    string extension = Path.GetExtension(file.FileName);


        //    path = Path.Combine(Server.MapPath("~/img"), random + Path.GetFileName(file.FileName));
        //    file.SaveAs(path);
        //    path = "~/img/" + random + Path.GetFileName(file.FileName);

        //    return path;
        //}

        public IActionResult HotelIndex()
        {
            var hotels = _context.Hotels.ToList();
            return View(hotels);
        }
        public IActionResult CreateHotel()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateHotel(HotelDto hotelDto)
        {
            var hotel = new Hotel()
            {
                Name = hotelDto.Name,
                Description = hotelDto.Description,
                ImageUrl = DocumentSettings.UploadImage(hotelDto.ImageUrl, "images")
            };
            _context.Add(hotel);
            _context.SaveChanges();
            return RedirectToAction("HotelIndex");
        }

        public IActionResult DeleteHotel(int id)
        {
            var hotel= _context.Hotels.FirstOrDefault(h => h.Id == id);

            _context.Remove(hotel);
            _context.SaveChanges();

            return RedirectToAction("HotelIndex");

        }

        public IActionResult TransportationIndex()
        {
            var transports = _context.Transportaions.ToList();
            return View(transports);
        }
        public IActionResult CreateTransport()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateTransport(TransportDto hotelDto)
        {
            var transport = new Transportaion()
            {
                Name = hotelDto.Name,
                Description = hotelDto.Description,
                ImageUrl = DocumentSettings.UploadImage(hotelDto.ImageUrl, "images")
            };
            _context.Add(transport);
            _context.SaveChanges();
            return RedirectToAction("HotelIndex");
        }

        public IActionResult DeleteTransport(int id)
        {
            var hotel = _context.Hotels.FirstOrDefault(h => h.Id == id);

            _context.Remove(hotel);
            _context.SaveChanges();

            return RedirectToAction("HotelIndex");

        }


    }
}