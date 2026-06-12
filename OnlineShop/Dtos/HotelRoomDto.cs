namespace Tourism_Project.Dtos
{
    public class HotelRoomDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public IFormFile ImageUrl { get; set; }
        public int HotelId { get; set; }
    }
}
