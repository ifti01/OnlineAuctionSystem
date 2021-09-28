using AuctionSystem.Entities;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuctionSystem.Database;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace AuctionSystem.Services
{
    
        public class AuctionSystemUserManager : UserManager<AuctionSystemUser>
        {
            public AuctionSystemUserManager(IUserStore<AuctionSystemUser> store)
                : base(store)
            {
            }

            public static AuctionSystemUserManager Create(IdentityFactoryOptions<AuctionSystemUserManager> options, IOwinContext context)
            {
                var manager = new AuctionSystemUserManager(new UserStore<AuctionSystemUser>(context.Get<AuctionSystemContext>()));
                // Configure validation logic for usernames
                manager.UserValidator = new UserValidator<AuctionSystemUser>(manager)
                {
                    AllowOnlyAlphanumericUserNames = false,
                    RequireUniqueEmail = true
                };

                // Configure validation logic for passwords
                manager.PasswordValidator = new PasswordValidator
                {
                    RequiredLength = 6,
                    RequireNonLetterOrDigit = true,
                    RequireDigit = true,
                    RequireLowercase = true,
                    RequireUppercase = true,
                };

                // Configure user lockout defaults
                manager.UserLockoutEnabledByDefault = true;
                manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
                manager.MaxFailedAccessAttemptsBeforeLockout = 5;

                // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
                // You can write your own provider and plug it in here.
                manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<AuctionSystemUser>
                {
                    MessageFormat = "Your security code is {0}"
                });
                manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<AuctionSystemUser>
                {
                    Subject = "Security Code",
                    BodyFormat = "Your security code is {0}"
                });
                //manager.EmailService = new EmailService();
                //manager.SmsService = new SmsService();
                var dataProtectionProvider = options.DataProtectionProvider;
                if (dataProtectionProvider != null)
                {
                    manager.UserTokenProvider =
                        new DataProtectorTokenProvider<AuctionSystemUser>(dataProtectionProvider.Create("ASP.NET Identity"));
                }
                return manager;
            }
        }
    }

