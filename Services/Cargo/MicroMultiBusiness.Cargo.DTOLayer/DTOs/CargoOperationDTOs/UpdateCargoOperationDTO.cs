namespace MicroMultiBusiness.Cargo.DTOLayer.DTOs.CargoOperationDTOs
{
    public class UpdateCargoOperationDTO
    {
        public int CargoOperationId { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public DateTime OperationDate { get; set; }
    }
}
