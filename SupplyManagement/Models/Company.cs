using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Company
    {
        [Key]
        [ForeignKey("User")]
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyPhone { get; set; }
        public string? Photo { get; set; }
        [ForeignKey("Status")]
        public int StatusId { get; set; }
        public DateTime RegistrationTime { get; set; }

        public virtual User User { get; set; }
        public virtual Status Status { get; set; }
        public virtual Vendor? Vendor { get; set; }
        


    }
}
