namespace CuriosityApi.Entities;

public class ApplicationUser
{
    public Guid Id {get;set;} = Guid.NewGuid();
    public required string Username {get;set;}
    public required string Email {get;set;}
    public required string Password {get;set;}
    public ICollection<ApplicationFollow> Followers {get;set;} = [];
    public ICollection<ApplicationFollow> Following {get;set;} = [];
    public ICollection<ApplicationProduct> Products {get;set;} = [];
    public ICollection<ApplicationCart> Carts {get;set;} = [];
    public ICollection<ApplicationChat> Chats {get;set;} = [];
}