namespace InventoryManagement.Helpers
{ 
    public class AppSettings
    {
        public string Secret { get; set; }
        public string MinimumSupportedVersion { get; set; }
        public string BaseUrl { get; set; } 
        public bool EnableRedemption { get; set; }
        public string RedemptionMessage { get; set; }
    }
}
