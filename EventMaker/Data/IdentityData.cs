using EventMaker.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace EventMaker.Data
{
    public static class IdentityData
    {
        private const string OrganizerRoleName = "Organizer";
        private const string ModeratorRoleName = "Moderator";
        private const string MemberRoleName = "Member";

        private const int NumberId = 101;
        private const string UserPassword = "12345Zz*111";
        public static void AddRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync(OrganizerRoleName).Result)
            {
                IdentityRole role = new IdentityRole(OrganizerRoleName);
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
            if (!roleManager.RoleExistsAsync(ModeratorRoleName).Result)
            {
                IdentityRole role = new IdentityRole(ModeratorRoleName);
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
            if (!roleManager.RoleExistsAsync(MemberRoleName).Result)
            {
                IdentityRole role = new IdentityRole(MemberRoleName);
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
        }
        public static void AddOrganizer(UserManager<User> userManager)
        {
            if (userManager.FindByNameAsync(NumberId.ToString()).Result == null)
            {
                User user = new User();
                user.FirstName = "Иван";
                user.LastName = "Иванов";
                user.LastLogin = DateTime.Now;
                user.UserName = NumberId.ToString();
                user.Email = "Random@gmail.com";
                user.Gender = Enums.Gender.Male;

                IdentityResult result = userManager.CreateAsync(user, UserPassword).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, OrganizerRoleName).Wait();
                }
            }
        }
    }
}
