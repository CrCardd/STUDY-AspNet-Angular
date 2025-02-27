using Microsoft.EntityFrameworkCore;

namespace CuriosityApi.Entities;


public class CuriosityDbContext(DbContextOptions<CuriosityDbContext> options) : DbContext(options)
{
    public DbSet<ApplicationUser> Users {get;set;}
    public DbSet<ApplicationChat> Chats {get;set;}
    public DbSet<ApplicationMessage> Messages {get;set;}
    public DbSet<ApplicationCart> Carts {get;set;}
    public DbSet<ApplicationProduct> Products {get;set;}


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<ApplicationUser>()
            .HasMany(e => e.Followers)
            .WithOne(e => e.Followed)
            .HasForeignKey(e => e.FollowedId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Entity<ApplicationUser>()
            .HasMany(e => e.Following)
            .WithOne(e => e.Follower)
            .HasForeignKey(e => e.FollowerId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Entity<ApplicationFollow>()
            .HasOne(e => e.Follower)
            .WithMany(e => e.Following)
            .HasForeignKey(e => e.FollowerId)
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.Entity<ApplicationFollow>()
            .HasOne(e => e.Followed)
            .WithMany(e => e.Followers)
            .HasForeignKey(e => e.FollowedId)
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.Entity<ApplicationUser>()
            .HasMany(e => e.Carts)
            .WithOne(e => e.User)
            .HasForeignKey(e => e.IdUser);
        
        builder.Entity<ApplicationProduct>()
            .HasOne(e => e.Owner)
            .WithMany(e => e.Products)
            .HasForeignKey(e => e.OwnerId);
        
        builder.Entity<ApplicationCart>()
            .HasMany(e => e.Products)
            .WithOne();
            
        builder.Entity<ApplicationProduct>()
            .HasMany(e => e.Chat)
            .WithOne(e => e.Product)
            .HasForeignKey(e => e.IdProduct);
        
        builder.Entity<ApplicationChat>()
            .HasMany(e => e.Messages)
            .WithOne(e => e.Chat)
            .HasForeignKey(e => e.ChatId)
            .OnDelete(DeleteBehavior.NoAction); ///////////////////////////
        
        builder.Entity<ApplicationChat>()
            .HasOne(e => e.UserA)
            .WithOne()
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<ApplicationChat>()
            .HasOne(e => e.UserB)
            .WithOne()
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<ApplicationMessage>()
            .HasOne(e => e.Sender)
            .WithOne()
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<ApplicationMessage>()
            .HasOne(e => e.Receiver)
            .WithOne()
            .OnDelete(DeleteBehavior.NoAction);
    }
}