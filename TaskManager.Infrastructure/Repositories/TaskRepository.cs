using TaskManager.Domain.Entities;
using TaskManager.Application.Interfaces;
using TaskManager.Infrastructure.Data;
using TaskManager.Infrastructure.Models;

using Microsoft.EntityFrameworkCore;


namespace TaskManager.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _context;

        public TaskRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Activity>> GetAllAsync()
        {
            var entities = await _context.Tasks.ToListAsync();
            return entities.Select(t => new Activity
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                IsCompleted = t.IsCompleted
            });
        }

        public async Task<Activity?> GetByIdAsync(int id)
        {
            var t = await _context.Tasks.FindAsync(id);
            return t == null ? null : new Activity
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                IsCompleted = t.IsCompleted
            };
        }

        public async Task<Activity> CreateAsync(Activity item)
        {
            var entity = new TaskModel
            {
                Title = item.Title,
                Description = item.Description,
                IsCompleted = item.IsCompleted
            };

            _context.Tasks.Add(entity);
            await _context.SaveChangesAsync();

            item.Id = entity.Id;
            return item;
        }

        public async Task<bool> UpdateAsync(int id, Activity item)
        {
            var entity = await _context.Tasks.FindAsync(id);
            if (entity == null) return false;

            entity.Title = item.Title;
            entity.Description = item.Description;
            entity.IsCompleted = item.IsCompleted;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Tasks.FindAsync(id);
            if (entity == null) return false;

            _context.Tasks.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
