namespace CuriosityApi.Entities;

public class ApplicationFollow
{
    public Guid Id {get;set;} = Guid.NewGuid();
    public required Guid FollowedId {get;set;}
    public required ApplicationUser Followed {get;set;}
    public required Guid FollowerId {get;set;}
    public required ApplicationUser Follower {get;set;}
}