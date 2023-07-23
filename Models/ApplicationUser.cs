using Microsoft.AspNetCore.Identity;

namespace CPICPP.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string Country { get; set; } = "Unknown";
        public string HomeAddress { get; set; } = "Unknown";
        public string HomeCity { get; set; } = "Unknown";
        public string PostalCode { get; set; } = "Unknown";
        public string Province { get; set; } = "Unknown";
        public string Role { get; set; } = "Unknown";
        public string SchoolCity { get; set; } = "Unknown";
        public string SchoolCountry { get; set; } = "Unknown";
        public string SchoolName { get; set; } = "Unknown";
        public string SchoolPostalCode { get; set; } = "Unknown";
        public string SchoolProvince { get; set; } = "Unknown";

    }
}
