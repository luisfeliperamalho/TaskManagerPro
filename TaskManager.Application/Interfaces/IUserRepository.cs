using TaskManager.Domain.Entities;

namespace TaskManager.Application.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(int id);
    Task<User?> GetByCpfAsync(string cpf);
    Task<User> CreateAsync(User user);
    Task AddAsync(User user);
}
