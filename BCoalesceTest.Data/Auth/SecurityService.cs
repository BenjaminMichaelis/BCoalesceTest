
namespace BCoalesceTest.Data.Auth;

[Coalesce, Service]
public class SecurityService()
{
    [Coalesce, Execute(HttpMethod = HttpMethod.Get)]
    public UserInfo WhoAmI(ClaimsPrincipal user)
    {
        return new UserInfo
        {
            Id = user.FindFirstValue(ClaimTypes.NameIdentifier),
            UserName = user.Identity?.Name,
        };
    }
}
