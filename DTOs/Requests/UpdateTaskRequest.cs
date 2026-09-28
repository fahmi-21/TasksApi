using System.ComponentModel.DataAnnotations;

namespace Tasks_Api.DTOs.Requests
{
    public class UpdateTaskRequest
    {
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public bool IsCompleted { get; set; }
    }
}
