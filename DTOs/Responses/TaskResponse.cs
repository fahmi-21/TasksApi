namespace Tasks_Api.DTOs.Responses
{
    public class TaskResponse
    {
        public List<Tasks_Api.Model.Task> Tasks { get; set; } = new List<Tasks_Api.Model.Task>();
        public double TotalPages { get; set; }
        public int CurrentPage { get; set; }
    }
}
