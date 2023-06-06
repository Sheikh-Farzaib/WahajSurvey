using DBHandler.Model;
using DBHandler.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DBHandler.Models
{
    [Table("Item")]
    public class Item : DomainModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemNameAR { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }




    }
}
