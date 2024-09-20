namespace MicroMultiBusiness.WebUI.Settings
{
    public class ServiceAPISettings
    {
        public string OcelotURL { get; set; }
        public string IdentityServerURL { get; set; }
        public ServiceAPI Basket { get; set; }
        public ServiceAPI Cargo { get; set; }
        public ServiceAPI Catalog { get; set; }
        public ServiceAPI Comment { get; set; }
        public ServiceAPI Discount { get; set; }
        public ServiceAPI Image { get; set; }
        public ServiceAPI Order { get; set; }
        public ServiceAPI Payment { get; set; }
        public ServiceAPI Message { get; set; }
    }
    public class ServiceAPI
    {
        public string Path { get; set; }
    }
}
