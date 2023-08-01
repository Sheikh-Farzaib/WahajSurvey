namespace WahajSurvey.Models.DTOs
{
    public class BranchIdWithDateFilterDTO
    {
        public int BranchId { get; set; }
        public DateTime? FromDate{ get; set; }
        public DateTime? ToDate{ get; set; }
    }
}
