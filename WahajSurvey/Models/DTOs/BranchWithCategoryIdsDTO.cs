namespace WahajSurvey.Models.DTOs
{
    public class BranchWithCategoryIdsDTO
    {
        public int BranchId { get; set; }
        public string Branch { get; set; }
        public List<int>? CategoryIds { get; set; }
    }
}
