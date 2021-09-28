using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AuctionSystem.Entities;
using Microsoft.Owin;
using Microsoft.Owin.Security;

namespace AuctionSystem.Services
{
    public class AuctionSystemSignInManager : SignInManager<AuctionSystemUser, string>
    {
        public AuctionSystemSignInManager(AuctionSystemUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(AuctionSystemUser user)
        {
            return user.GenerateUserIdentityAsync((AuctionSystemUserManager)UserManager);
        }

        public static AuctionSystemSignInManager Create(IdentityFactoryOptions<AuctionSystemSignInManager> options, IOwinContext context)
        {
            return new AuctionSystemSignInManager(context.GetUserManager<AuctionSystemUserManager>(), context.Authentication);
        }
    }
}
