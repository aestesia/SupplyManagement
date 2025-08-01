using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Status
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }

        public virtual ICollection<Company> Companies { get; set; }
        public virtual ICollection<Vendor> Vendors { get; set; }
        
    }
}
