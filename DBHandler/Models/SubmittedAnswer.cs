using DBHandler.Model;
using MessagePack;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBHandler.Models
{
    [Table("SubmittedAnswer")]
    public class SubmittedAnswer : DomainModel
    {
        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int BranchId { get; set; }
        public int CategoryId { get; set; }
        public int ItemId { get; set; }
        public string? Name { get; set; }
        public string? Comment { get; set; }
        public string? IdOrPhoneNumber { get; set; }
    }
}
