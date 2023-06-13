namespace Vision.Model
{
    public class ToDo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Done { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int BoardId { get; set; }
        public Board Board { get; set; }
    }
}
