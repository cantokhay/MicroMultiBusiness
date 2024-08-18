namespace MicroMultiBusiness.DTOLayer.CatalogDTOs.ContactDTOs
{
    public class CreateContactDTO
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
        public DateTime SentDate { get; set; }
    }
}
