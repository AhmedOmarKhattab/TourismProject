using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class bookModel
    {
        public int Id { get; set; }
        public string tripplace { get; set; }
        public string godate { get; set; }
        public string comingdate { get; set; }
        public string travelmethod { get; set; }
        public string traveldes { get; set; }
        public string childprice { get; set; }
        public string adultchild { get; set; }
        public string hotel { get; set; }
        public string city { get; set; }
        public string email { get; set; }
        public string mess { get; set; }
        public Nullable<int> travelerNo { get; set; }
        public string name { get; set; }
        public string transport { get; set; }
        public Nullable<int> adultage { get; set; }
        public Nullable<int> kideage { get; set; }
        public Nullable<int> availableadultno { get; set; }
        public Nullable<int> availablekideno { get; set; }

        public string idcard { get; set; }
        public Nullable<int> tripid { get; set; }
        public string phone { get; set; }
    }
}