using Application.ApplicationContexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Shop.ModelArea.Models;

namespace DataConnections.Data
{
    public class SeedData
    {
        public static async Task SeedRole(IServiceProvider serviceProvider)
        {
            var scope = serviceProvider.CreateScope();

            var roleManage = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var roles = new List<IdentityRole>
            {
                new IdentityRole {Name = CustemRole.MasterAdmin,NormalizedName= CustemRole.MasterAdmin},
                new IdentityRole {Name = CustemRole.Admin,NormalizedName= CustemRole.Admin},
                new IdentityRole {Name = CustemRole.User,NormalizedName= CustemRole.User},
            };

            foreach (var role in roles)
            {
                if (!await roleManage.RoleExistsAsync(role.Name))
                {
                    await roleManage.CreateAsync(role);
                }
            }
        }

        public static async Task SeedDataAsync(ApplicationContext context)
        {
            if(!context.BrandTypes.Any()) {

                await context.BrandTypes.AddRangeAsync(
                    
                    new BrandType
                    {
                        Name = "Home"
                    },
                    new BrandType
                    {
                        Name = "Eloctronic"
                    },
                    new BrandType
                    {
                        Name = "Electrical"
                    },
                    new BrandType
                    {
                        Name = "Dress"
                    },
                    new BrandType
                    {
                        Name = "Food"
                    },
                    new BrandType
                    {
                        Name = "Toys"
                    },
                    new BrandType
                    {
                        Name = "Tools"
                    }


                    );
                await context.SaveChangesAsync();
            }
        }


    }
}
