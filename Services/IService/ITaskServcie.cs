using Tasks_Api.DTOs.Requests;

namespace Tasks_Api.Services.IService
{
    public interface ITaskServcie
    {
        Task<(List<Tasks_Api.Model.Task> Tasks, int TotalCount)> GetAllAsync( int page, int pageSize);

        Task<Tasks_Api.Model.Task?> GetByIdAsync(int id);

        Task<Tasks_Api.Model.Task> CreateAsync(CreatTaskRequest dto);

        Task<Tasks_Api.Model.Task?> UpdateAsync(int id, UpdateTaskRequest dto);

        Task<bool> DeleteAsync(int id);
    }
}
