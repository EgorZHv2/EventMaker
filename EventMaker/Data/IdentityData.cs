using EventMaker.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace EventMaker.Data
{
    public static class IdentityData
    {
        private const string OrganizerRoleName = "Organizer";
        private const string ModeratorRoleName = "Moderator";
        private const string MemberRoleName = "Member";

        private const int IdNumber = 101;
        private const int IdNumbe = 102;
        private const int IdNumb = 103;
        private const int IdNum = 104;
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
            if (userManager.FindByNameAsync(IdNumber.ToString()).Result == null)
            {
                User user = new User();
                user.FirstName = "Иван";
                user.LastName = "Иванов";
                user.LastLogin = DateTime.Now;
                user.UserName = IdNumber.ToString();
                user.Email = "Random@gmail.com";
                user.Gender = Enums.Gender.Male;

                IdentityResult result = userManager.CreateAsync(user, UserPassword).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, OrganizerRoleName).Wait();
                }
            }
        }
        public static void AddModerators(UserManager<User> userManager)
        {
            if (userManager.FindByNameAsync(IdNumbe.ToString()).Result == null)
            {
                User user = new User();
                user.FirstName = "Моня1";
                user.LastName = "Иванов";
                user.LastLogin = DateTime.Now;
                user.UserName = IdNumbe.ToString();
                user.Email = "Randoom@gmail.com";
                user.Gender = Enums.Gender.Male;

                IdentityResult result = userManager.CreateAsync(user, UserPassword).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, ModeratorRoleName).Wait();
                }
            }
            if (userManager.FindByNameAsync(IdNumb.ToString()).Result == null)
            {
                User user = new User();
                user.FirstName = "Моня2";
                user.LastName = "Егоров";
                user.LastLogin = DateTime.Now;
                user.UserName = IdNumb.ToString();
                user.Email = "Randooom@gmail.com";
                user.Gender = Enums.Gender.Male;

                IdentityResult result = userManager.CreateAsync(user, UserPassword).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, ModeratorRoleName).Wait();
                }
            }
            if (userManager.FindByNameAsync(IdNum.ToString()).Result == null)
            {
                User user = new User();
                user.FirstName = "Моня3";
                user.LastName = "Олегов";
                user.LastLogin = DateTime.Now;
                user.UserName = IdNum.ToString();
                user.Email = "Randoooom@gmail.com";
                user.Gender = Enums.Gender.Male;

                IdentityResult result = userManager.CreateAsync(user, UserPassword).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, ModeratorRoleName).Wait();
                }
            }
        }
    }
}
