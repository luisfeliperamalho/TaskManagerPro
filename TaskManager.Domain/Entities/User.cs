namespace TaskManager.Domain.Entities;

public class User
{
    public int Id { get; private set; }
    public string Username { get; private set; }
    public string PasswordHash { get; private set; }
    public string Cpf { get; private set; }

    public User(string username, string passwordHash, string cpf)
    {
        Username = username;
        PasswordHash = passwordHash;
        Cpf = cpf;
    }

    private User() { }
}
