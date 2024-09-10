namespace BE_Shopdunk.Model
{
    public class PagedResult<T, T2>
    {
        public int TotalCount { get; set; }

        public string? CategoryName { get; set; }

        public string? CategoryId { set; get; }

        public List<T2>? Items { get; set; }
    }
}