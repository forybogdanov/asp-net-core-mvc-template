using ExamApplication.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ExamApplication.Web.Seed
{
    public static class DatabaseSeedUtilities
    {
        public static void SeedRoles(this WebApplication app)
        {
            using (var serviceScope = app.Services.CreateScope())
            {
                using (var ExamApplicationDbContext = serviceScope.ServiceProvider.GetRequiredService<ExamApplicationDbContext>())
                {
                    ExamApplicationDbContext.Database.Migrate();

                    if (ExamApplicationDbContext.Roles.ToList().Count == 0)
                    {
                        IdentityRole adminRole = new IdentityRole();
                        adminRole.Name = "Admin";
                        adminRole.NormalizedName = adminRole.Name.ToUpper();

                        IdentityRole userRole = new IdentityRole();
                        userRole.Name = "User";
                        userRole.NormalizedName = userRole.Name.ToUpper();

                        ExamApplicationDbContext.Add(adminRole);
                        ExamApplicationDbContext.Add(userRole);

                        ExamApplicationDbContext.SaveChanges();
                    }
                }
            }
        }
    }
}
