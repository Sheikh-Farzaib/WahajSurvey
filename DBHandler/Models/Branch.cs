using DBHandler.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHandler.Model {
    [Table("Branch")]
    public class Branch : DomainModel {

        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int BranchId { get; set; }
        public string? BranchName { get; set; }
        public string? BranchNameAR { get; set; }
        public string? BranchCode { get; set; }
     
    }
}
