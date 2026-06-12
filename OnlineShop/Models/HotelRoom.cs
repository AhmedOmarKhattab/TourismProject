using Tourism_Project.Models;

namespace Tourism_Project.Models
{
    public class HotelRoom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int HotelId { get; set; }
        public Hotel? Hotel { set; get; }
    }
}
