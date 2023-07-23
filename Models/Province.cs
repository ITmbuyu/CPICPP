namespace CPICPP.Models
{
    public class Province
    {
        public int ProvinceId { get; set; }
        public string ProvinceName { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }

    }
}