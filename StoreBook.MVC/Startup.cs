using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using StoreBook.Models.Identity;

[assembly: OwinStartupAttribute(typeof(StoreBook.Startup))]
namespace StoreBook
{
    public partial class Startup
    {
        public ApplicationDbContext db = new ApplicationDbContext();
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            InitRole();
            InitUser();
        }

        public void InitRole()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            IdentityRole admin = new IdentityRole("Admins");
            IdentityRole user = new IdentityRole("Users");
            if (!roleManager.RoleExists(admin.Name))
                roleManager.Create(admin);
            if (!roleManager.RoleExists(user.Name))
                roleManager.Create(user);

        }
        public void InitUser()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var ADMIN = new ApplicationUser();

            ADMIN.Email = "abdoali204@hotmaiil.com";
            ADMIN.UserName = "Master";

            userManager.Create(ADMIN, "Lordboter2$");
            var exist = userManager.FindByEmail("abdoali204@hotmaiil.com");
            if (exist == null)
            {
                userManager.Create(ADMIN);
                if (!roleManager.RoleExists("Admins"))
                {
                    roleManager.Create(new IdentityRole("Admins"));
                }
                userManager.AddToRole(ADMIN.Id, "Admins");

            }
        }
    }
}
