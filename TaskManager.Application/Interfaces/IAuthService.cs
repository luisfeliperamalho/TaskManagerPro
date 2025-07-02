using TaskManager.Application.DTOs;

namespace TaskManager.Application.Interfaces;

public interface IAuthService
{
    Task<bool> RegisterAsync(UserDTO dto);

    Task<string?> LoginAsync(LoginDTO dto);
}