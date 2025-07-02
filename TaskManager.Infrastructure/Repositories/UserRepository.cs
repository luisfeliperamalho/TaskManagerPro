using Microsoft.EntityFrameworkCore;
using TaskManager.Application.Interfaces;
using TaskManager.Domain.Entities;
using TaskManager.Infrastructure.Data;
using TaskManager.Infrastructure.Models;

namespace TaskManager.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{

    private readonly AppDbContext _context;


    public UserRepository(AppDbContext context)
    {
        _context = context;
    }


    public async Task AddAsync(User user)
    {
        var userModel = new UserModel
        {
            Username = user.Username,
            PasswordHash = user.PasswordHash,
            Cpf = user.Cpf
        };

        _context.Users.Add(userModel);
        await _context.SaveChangesAsync();
    }

    public async Task<User> CreateAsync(User user)
    {
        var userModel = new UserModel
        {
            Username = user.Username,
            PasswordHash = user.PasswordHash,
            Cpf = user.Cpf
        };

        _context.Users.Add(userModel);
        await _context.SaveChangesAsync();

        return new User(userModel.Username, userModel.PasswordHash, userModel.Cpf);
    }

    public async Task<User?> GetByCpfAsync(string cpf)
    {
        var userModel = await _context.Users
            .FirstOrDefaultAsync(u => u.Cpf == cpf);

        if (userModel == null) return null;

        return new User(userModel.Username, userModel.PasswordHash, userModel.Cpf);
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        var userModel = await _context.Users
            .FirstOrDefaultAsync(u => u.Id == id);

        if (userModel == null) return null;

        return new User(userModel.Username, userModel.PasswordHash, userModel.Cpf);
    }
}