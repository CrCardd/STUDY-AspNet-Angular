namespace CuriosityApi.Entities;

public class ApplicationProduct 
{
    public Guid Id {get;set;} = Guid.NewGuid();
    public required string Name {get;set;}
    public required string Description {get;set;}
    public required float Price {get;set;}

    public required Guid OwnerId {get;set;}
    public required ApplicationUser Owner {get;set;}
    public ICollection<ApplicationChat> Chat {get;set;} = [];

}