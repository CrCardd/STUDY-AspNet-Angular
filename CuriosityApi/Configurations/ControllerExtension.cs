using System.Security.Claims;

namespace CuriosityApi.Configurations;

public static class ControllerExtension {
    public static Guid? Id(this ClaimsPrincipal User)
    {
        var claim = User.FindFirst(ClaimTypes.NameIdentifier);
        if(claim is null)
            return null;
        if(!Guid.TryParse(claim.Value, out var id))
            return null;
        return id;
    }
}