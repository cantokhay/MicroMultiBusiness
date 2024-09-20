namespace MicroMultiBusiness.DTOLayer.MessageDTOs
{
    public class GetByIdMessageDTO
    {
        public int UserMessageId { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public string MessageDetail { get; set; }
        public string Subject { get; set; }
        public DateTime MessageSentDate { get; set; }
        public bool IsRead { get; set; }
    }
}
