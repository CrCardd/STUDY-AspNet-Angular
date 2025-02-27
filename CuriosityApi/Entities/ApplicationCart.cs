namespace CuriosityApi.Entities;

public class ApplicationCart
{
    public Guid Id {get;set;} = Guid.NewGuid();
    public required Guid IdUser {get;set;}
    public required ApplicationUser User {get;set;}
    public ICollection<ApplicationProduct> Products {get;set;} = [];
    public bool Activate {get;set;} = true;
}