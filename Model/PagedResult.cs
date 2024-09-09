namespace BE_Shopdunk.Model
{
    public class PagedResult<T, T2>
    {
        public int TotalCount { get; set; }
        public List<T2>? Items { get; set; }
    }
}