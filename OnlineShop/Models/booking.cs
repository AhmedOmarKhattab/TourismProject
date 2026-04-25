namespace OnlineShop.Models
{
    public class booking
    {
        public int Id { get; set; }
        public string name { get; set; }
        public Nullable<int> travelerNo { get; set; }
        public string idcard { get; set; }
        public Nullable<int> tripid { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string hotel { get; set; } = string.Empty;
        public Nullable<System.DateTime> date { get; set; }
        public string transport { get; set; }


    }
}
