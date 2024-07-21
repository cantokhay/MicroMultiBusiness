namespace MicroMultiBusiness.Cargo.DTOLayer.DTOs.CargoDetailDTOs
{
    public class CreateCargoDetailDTO
    {
        public string SenderCustomer { get; set; }
        public string ReceiverCustomer { get; set; }
        public int Barcode { get; set; }
        public int CargoCompanyId { get; set; }
    }
}
