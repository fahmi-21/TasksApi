using Tasks_Api.DTOs.Requests;

namespace Tasks_Api.Services.IService
{
    using Tasks_Api.DTOs.Responses;

    public interface ITaskServcie
    {
        Task<TaskResponse> GetAllAsync(int page, int pageSize);

        Task<Tasks_Api.Model.Task?> GetByIdAsync(int id);

        Task<Tasks_Api.Model.Task> CreateAsync(CreatTaskRequest dto);

        Task<Tasks_Api.Model.Task?> UpdateAsync(int id, UpdateTaskRequest dto);

        Task<bool> DeleteAsync(int id);
    }
}
