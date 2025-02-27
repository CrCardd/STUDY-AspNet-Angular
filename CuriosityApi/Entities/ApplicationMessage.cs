namespace CuriosityApi.Entities;

public class ApplicationMessage 
{
    public Guid Id {get;set;} = Guid.NewGuid();

    public required Guid ChatId {get;set;}
    public required ApplicationChat Chat {get;set;}

    public required Guid SenderId {get;set;}
    public required ApplicationUser Sender {get;set;}

    public required Guid ReceiverId {get;set;}
    public required ApplicationUser Receiver {get;set;}

    public required string Description {get;set;}
}