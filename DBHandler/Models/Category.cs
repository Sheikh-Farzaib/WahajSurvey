using DBHandler.Model;
using MessagePack;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHandler.Models
{
    [Table("Category")]
    public class Category : DomainModel
    {
        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryNameAR { get; set; }
        public int BranchId { get; set; }
        public Branch Branch { get; set; }

    }
}
