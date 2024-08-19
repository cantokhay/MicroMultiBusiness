namespace MicroMultiBusiness.WebUI.Settings
{
    public class ClientSettings
    {
        public Client MicroMultiBusinessVisitorClient { get; set; }
        public Client MicroMultiBusinessAdminClient { get; set; }
        public Client MicroMultiBusinessManagerClient { get; set; }
    }

    public class Client
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
