using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

public class ApplicationUserManager : UserManager<IdentityUser>
{
    public ApplicationUserManager(IUserStore<IdentityUser> store) : base(store)
    {
    }

    public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
    {
        var manager = new ApplicationUserManager(new UserStore<IdentityUser>(context.Get<ApplicationDbContext>()));

        // Configure validation logic for usernames and passwords here
        manager.UserValidator = new UserValidator<IdentityUser>(manager)
        {
            AllowOnlyAlphanumericUserNames = false,
            RequireUniqueEmail = true
        };

        manager.PasswordValidator = new PasswordValidator
        {
            RequiredLength = 6,
            RequireNonLetterOrDigit = false,
            RequireDigit = false,
            RequireLowercase = false,
            RequireUppercase = false,
        };

        return manager;
    }
}
