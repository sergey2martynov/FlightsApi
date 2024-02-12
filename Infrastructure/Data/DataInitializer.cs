using Domain.Constants;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Data
{
    public class DataInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DataInitializer(ApplicationDbContext context,
            UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task SeedAsync()
        {
            var administratorRole = new IdentityRole(Roles.Moderator);
            var clientRole = new IdentityRole(Roles.Client);

            if (_roleManager.Roles.All(r => r.Name != administratorRole.Name) && _roleManager.Roles.All(r => r.Name != clientRole.Name))
            {
                await _roleManager.CreateAsync(administratorRole);
                await _roleManager.CreateAsync(clientRole);
            }

            var administrator = new User { UserName = "admin@dev", Email = "admin@dev" };
            var client = new User { UserName = "client@dev", Email = "client@dev" };

            if (_userManager.Users.All(u => u.UserName != administrator.UserName) 
                && _userManager.Users.All(u => u.UserName != administrator.UserName))
            {
                await _userManager.CreateAsync(administrator, "12345678");
                await _userManager.CreateAsync(client, "12345678");

                await _userManager.AddToRolesAsync(administrator, new[] { administratorRole.Name, clientRole.Name });
                await _userManager.AddToRolesAsync(client, new[] { clientRole.Name });
            }

            await _context.SaveChangesAsync();
        }
    }
}
