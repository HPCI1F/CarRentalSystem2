using CarRentalSystem2;

public class RegisteredUser : AbstractUser
{
    public int UserId { get; private set; }
    public string Email { get; private set; }
    private string passwordHash;

    private RegisteredUser() : base("", "", "") { }

    public RegisteredUser(int userId, string name, string email, string address, string phoneNumber, string password)
        : base(name, address, phoneNumber)
    {
        UserId = userId;
        Email = email;
        SetPassword(password);
    }

    public void SetPassword(string password)
    {
        passwordHash = HashPassword(password);
    }

    private string HashPassword(string password)
    {
        return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
    }

    public bool VerifyPassword(string password)
    {
        return passwordHash == HashPassword(password);
    }
}
