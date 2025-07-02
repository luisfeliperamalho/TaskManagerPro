using System.Security.Cryptography;
using TaskManager.Application.Interfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;


namespace TaskManager.Infrastructure.Services;

public class PasswordHasherService : IPasswordHasherService
{
    public string Hash(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
            throw new ArgumentException("Password cannot be null or empty.", nameof(password));

        // 1. Gera salt aleatório de 16 bytes
        byte[] salt = RandomNumberGenerator.GetBytes(16);

        // 2. Deriva a senha com PBKDF2
        byte[] hash = KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 10000,
            numBytesRequested: 32 // 256 bits
        );

        // 3. Combina salt + hash
        byte[] combinedBytes = new byte[16 + 32];
        Buffer.BlockCopy(salt, 0, combinedBytes, 0, 16);
        Buffer.BlockCopy(hash, 0, combinedBytes, 16, 32);

        // 4. Retorna como base64 para armazenar no banco
        return Convert.ToBase64String(combinedBytes);
    }

    public bool Verify(string password, string passwordHash)
    {
        byte[] combinedBytes;

        try
        {
            combinedBytes = Convert.FromBase64String(passwordHash);
        }
        catch
        {
            return false; // caso o formato esteja inválido
        }

        if (combinedBytes.Length != 48) // 16 (salt) + 32 (hash)
            return false;

        byte[] salt = new byte[16];
        byte[] storedHash = new byte[32];

        Buffer.BlockCopy(combinedBytes, 0, salt, 0, 16);
        Buffer.BlockCopy(combinedBytes, 16, storedHash, 0, 32);

        byte[] computedHash = KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 10000,
            numBytesRequested: 32
        );

        return CryptographicOperations.FixedTimeEquals(computedHash, storedHash);
    }
}

