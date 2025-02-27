using CuriosityApi.Entities;

namespace CuriosityApi.Services.Token;

public interface IJwtService
{
    public string Generate(ApplicationUser user);
}