namespace RealEstateApi.Dtos
{
    public class PropertyDto
    {
        public string _id { get; set; } = string.Empty;
        public string idOwner { get; set; } = string.Empty;
        public string name { get; set; } = string.Empty;
        public string addressProperty { get; set; } = string.Empty;
        public decimal priceProperty { get; set; }
        public string image { get; set; }
    }
}
