namespace FINSHARK.Helper
{
    public class QueryObject
    {
        public string? CompanyName { get; set; } = null;
        public decimal? Purchase { get; set; } = null;
        public string? SortBy { get; set; } = null;
        public bool IsDecsending { get; set; } = false;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
