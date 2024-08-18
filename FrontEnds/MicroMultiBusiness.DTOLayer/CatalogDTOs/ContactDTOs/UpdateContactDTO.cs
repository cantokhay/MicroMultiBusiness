namespace MicroMultiBusiness.DTOLayer.CatalogDTOs.CategoryDTOs
{
    public class UpdateContactDTO
    {
        public string ContactId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
        public DateTime SentDate { get; set; }
    }
}
