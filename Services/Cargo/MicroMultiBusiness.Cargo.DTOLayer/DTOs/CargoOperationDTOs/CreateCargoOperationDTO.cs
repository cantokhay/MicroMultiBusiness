namespace MicroMultiBusiness.Cargo.DTOLayer.DTOs.CargoOperationDTOs
{
    public class CreateCargoOperationDTO
    {
        public string Barcode { get; set; }
        public string Description { get; set; }
        public DateTime OperationDate { get; set; }
    }
}
