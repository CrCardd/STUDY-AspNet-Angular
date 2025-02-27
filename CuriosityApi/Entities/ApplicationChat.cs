namespace CuriosityApi.Entities;

public class ApplicationChat
{
    public Guid Id {get;set;} = Guid.NewGuid();
    public required ApplicationUser UserA {get;set;}
    public required Guid UserAId {get;set;}
    public required ApplicationUser UserB {get;set;}
    public required Guid UserBId {get;set;}
    public ICollection<ApplicationMessage> Messages {get;set;} = [];
    
    public required Guid IdProduct {get;set;}
    public required ApplicationProduct Product {get;set;}

}