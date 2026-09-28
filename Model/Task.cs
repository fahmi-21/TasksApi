namespace Tasks_Api.Model
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { set; get; } 
        public bool IsCompleted { get; set; }
    }
}
