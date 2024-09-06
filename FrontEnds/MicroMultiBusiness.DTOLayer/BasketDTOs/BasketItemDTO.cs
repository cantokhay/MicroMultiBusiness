namespace MicroMultiBusiness.DTOLayer.BasketDTOs
{
    public class BasketItemDTO
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImageURL { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

    }
}
