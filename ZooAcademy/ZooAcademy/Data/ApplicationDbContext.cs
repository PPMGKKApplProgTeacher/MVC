using Microsoft.AspNet.Identity.EntityFramework;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext() : base("DefaultConnection") // Ensure this matches your connection string
    {
    }

    public static ApplicationDbContext Create()
    {
        return new ApplicationDbContext();
    }
}
