
using TaskManager.Application.DTOs;
using TaskManager.Application.Interfaces;
using TaskManager.Application.Validations;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasherService _passwordHasher;
    private readonly ITokenService _tokenService;

    public AuthService(
        IUserRepository userRepository,
        IPasswordHasherService passwordHasher,
        ITokenService tokenService)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _tokenService = tokenService;
    }

    public async Task<bool> RegisterAsync(UserDTO dto)
    {
        if (!CpfValidator.IsValid(dto.Cpf))
            throw new ArgumentException("CPF inválido");

        var existingUser = await _userRepository.GetByCpfAsync(dto.Cpf);
        if (existingUser != null)
            return false;

        var hashedPassword = _passwordHasher.Hash(dto.Password);
        var user = new User(dto.Username, hashedPassword, dto.Cpf);

        await _userRepository.AddAsync(user);
        return true;
    }

    public async Task<string?> LoginAsync(LoginDTO dto)
    {
        var user = await _userRepository.GetByCpfAsync(dto.Cpf);
        if (user == null || !_passwordHasher.Verify(dto.Password, user.PasswordHash))
            throw new UnauthorizedAccessException("Usuário ou senha inválidos");

        return _tokenService.GenerateToken(user);
    }
}
