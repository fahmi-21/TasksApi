using Tasks_Api.DTOs.Requests;
using Tasks_Api.DTOs.Responses;

namespace Tasks_Api.Services
{
    public class TaskService
    {
        private readonly IRepository<Tasks_Api.Model.Task> _repository;

        public TaskService(IRepository<Tasks_Api.Model.Task> repository)
        {
            _repository = repository;
        }
        public async Task<Tasks_Api.Model.Task> CreateAsync(CreatTaskRequest dto)
        {
            var task = new Tasks_Api.Model.Task
            {
                Title = dto.Title,
                Description = dto.Description,
                IsCompleted = false
            };

            await _repository.CreateAsync(task);
            await _repository.CommitAsync();

            return task;
        }
        public async Task<TaskResponse> GetAllAsync( int page, int pageSize)
        {
            if (page <= 0)
                page = 1;

            if (pageSize <= 0)
                pageSize = 5;

            var query = await _repository.GetAsync( tracked: false);

            int totalCount = query.Count();
            int curentpage = page;
            double totalPages = Math.Ceiling((double)totalCount / 5.0);
            var tasks = query.Skip((curentpage - 1) * 5)
                             .Take(pageSize)
                             .ToList();
    

            return new TaskResponse
            {
                Tasks = tasks,
                TotalPages = totalPages,
                CurrentPage = page
            };
        }

        public async Task<Tasks_Api.Model.Task?> GetByIdAsync(int id)
        {
            var task = await _repository.GetOneAsync(e => e.Id == id , tracked: false);

            return task;
        }
        

        public async Task<Tasks_Api.Model.Task?> UpdateAsync(int id, UpdateTaskRequest dto)
        {
            var task = await _repository.GetOneAsync( e => e.Id == id);

            if (task is null)
                return null;

            task.Title = dto.Title;
            task.Description = dto.Description;
            task.IsCompleted = dto.IsCompleted;

            _repository.Edit(task);
            await _repository.CommitAsync();

            return task;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var task = await _repository.GetOneAsync( e => e.Id == id );

            if (task is null)
                return false;

            _repository.Delete(task);
            await _repository.CommitAsync();

            return true;
        }
    }
}
