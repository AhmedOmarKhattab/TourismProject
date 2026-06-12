using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tourism_Project.Models
{
    public class booklist
    {
        public int Id { get; set; }
        public string name { get; set; }
        public Nullable<int> adultage { get; set; }
        public Nullable<int> kideage { get; set; }
        public string idcard { get; set; }
        public Nullable<int> tripid { get; set; }
        public Nullable<int> travelNo { get; set; }

        public string phone { get; set; }
    }
}