using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class triplist
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
        public string image { get; set; }

    }
}