namespace WahajSurvey.Models.DTOs
{
    public class SubmittedDataDTO
    {
        public int Id { get; set; }
        public int BranchId { get; set; }
        public List<string> ItemsWithCat { get; set; }
        public string? Name { get; set; }
        public string? Comment { get; set; }
        public string? IdOrPhoneNumber { get; set; }
    }
}
