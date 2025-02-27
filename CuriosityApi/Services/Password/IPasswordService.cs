namespace CuriosityApi.Services.Password;

public interface IPasswordService
{
    public string Hash(string password);
    public bool Compare(string password, string hashedPassword);
    
}