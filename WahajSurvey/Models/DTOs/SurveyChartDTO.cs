namespace WahajSurvey.Models.DTOs
{
    public class SurveyChartDTO
    {
        public int? CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public List<ItemList> Items { get; set; }
    }
    public class ItemList
    {
        public int ItemId { get; set; }
        public string? ItemName { get; set; }
        public int ItemCount { get; set; }


    }
}
