namespace MicroMultiBusiness.DTOLayer.OrderDTOs.OrderingDTOs
{
    public class ResultOrderingByUserIdDTO
    {
        public int OrderingId { get; set; }
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
