using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHandler.Models.DTOs
{
    public class SurveyChartDTO
    {
        public List<int> BranchId { get; set; }
        public List<int> CategoryId { get; set; }
        public List<int> ItemId { get; set; }
        public string branchName { get; set; }
        public string CategoryName { get; set; }
        public string ItemName { get; set; }
        public int ItemCount { get; set; }
    }
}
