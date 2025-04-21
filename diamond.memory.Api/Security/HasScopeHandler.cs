using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace diamond.memory.Api.Security
{
    public class HasScopeHandler : AuthorizationHandler<HasScopeRequirements>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HasScopeRequirements requirement)
        {
            if (!content.User.HasClaim(c => c.Type == "scope" && c.Issuer == requirement.Issuer))
                return Task.CompletedTask;
            
            var scopes = context.User.FindFirst(c => c.Type == "scope" && c.Issuer == requirement.Issuer).Value.Split(' ');
            if (scopes.Any(s => s == requirement.Scope))
                context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}