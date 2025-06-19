using Microsoft.AspNetCore.Identity;
namespace Ctenarak.Data
{
    public class Role
    {
        public static async Task SeedAsync(
        RoleManager<IdentityRole> roleMgr,
        UserManager<IdentityUser> userMgr)
        {
            foreach (var r in new[] { "Admin", "Creator"})
            if (!await roleMgr.RoleExistsAsync(r))
            await roleMgr.CreateAsync(new IdentityRole(r));
            const string adminEmail = "admin@knihovna-DK.com";
            const string adminPwd = "W3llH3llo!";

            var admin = await userMgr.FindByEmailAsync(adminEmail);
            if (admin == null)
            {
                admin = new IdentityUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };
                var createResult = await userMgr.CreateAsync(admin, adminPwd);
                if (!createResult.Succeeded)
                {
                    var errs = string.Join("; ", createResult.Errors.Select(e => e.Description));
                    throw new Exception("Admin user creation failed: " + errs);
                }
            }
            if (!await userMgr.IsInRoleAsync(admin, "Admin"))
                await userMgr.AddToRoleAsync(admin, "Admin");

            const string creatorEmail = "Adam@knihovna-DK.com";
            const string creatorPwd = "H0w4reU?";

            var creator = await userMgr.FindByEmailAsync(creatorEmail);
            if (creator == null)
            {
                creator = new IdentityUser
                {
                    UserName = creatorEmail,
                    Email = creatorEmail,
                    EmailConfirmed = true
                };
                var crResult = await userMgr.CreateAsync(creator, creatorPwd);
                if (!crResult.Succeeded)
                    throw new Exception("Creator creation failed: " +
                      string.Join("; ", crResult.Errors.Select(e => e.Description)));
            }
            if (!await userMgr.IsInRoleAsync(creator, "Creator"))
                await userMgr.AddToRoleAsync(creator, "Creator");
        }
    }
}