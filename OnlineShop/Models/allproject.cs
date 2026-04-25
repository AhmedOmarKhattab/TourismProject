using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class allproject
    {
        public string email { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string nationality { get; set; }
        public string phone { get; set; }
        public string transport { get; set; }
        public List<triplist> triplists { get; set; }
        public List<booklist> booklists { get; set; }
        public List<guidList> guidLists { get; set; }
        public Nullable<int> travelerNo { get; set; }
        public List<opin> opins { get; set; }

        public int Id { get; set; }
        public string tripplace { get; set; }
        public string time { get; set; }

        public string godate { get; set; }
        public string comingdate { get; set; }
        public string travelmethod { get; set; }
        public string traveldes { get; set; }
        public string tiketprice { get; set; }
        public string hotel { get; set; }
        public string city { get; set; }
        public string image { get; set; }
        public string type { get; set; }
        public string opin1 { get; set; }

    }
}