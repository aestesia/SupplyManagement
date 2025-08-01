using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Vendor
    {
        [Key]
        [ForeignKey("Company")]
        public int Id { get; set; }
        public string BusinessField { get; set; }
        public string BusinessType { get; set; }
        [ForeignKey("Status")]
        public int StatusId { get; set; }
        public DateTime SubmissionDate { get; set; }

        public virtual Company Company { get; set; }
        public virtual Status Status { get; set; }

    }
}
