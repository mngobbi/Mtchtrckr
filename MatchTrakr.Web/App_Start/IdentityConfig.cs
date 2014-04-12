using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using MatchTrakr.Data;
using MatchTrakr.Data.Entities;

namespace MatchTrakr.Web
{
    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.

    public class UsuarioManager : UserManager<Usuario>
    {
        public UsuarioManager(IUserStore<Usuario> store)
            : base(store)
        {
        }

        public static UsuarioManager Create(IdentityFactoryOptions<UsuarioManager> options, IOwinContext context)
        {
            var manager = new UsuarioManager(new UserStore<Usuario>(context.Get<MatchTrakrContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<Usuario>(manager)
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
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<Usuario>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }
}
