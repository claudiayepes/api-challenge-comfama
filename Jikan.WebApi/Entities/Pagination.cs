namespace Jikan.WebApi.Entities
{
    public class Pagination
    {
        public int last_visible_page { get; set; }
        public bool has_next_page { get; set; }
        public int current_page { get; set; }
        public Item items { get; set; }
    }
}
