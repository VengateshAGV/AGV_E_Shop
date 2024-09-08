

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shop.ModelArea.Models;

namespace DataConnections.Data
{
    public class ApplicationContext :IdentityDbContext<UserID>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext>options) : base(options) { }

        
        public DbSet<Brand> Brands {  get; set; }
        public DbSet<BrandType> BrandTypes { get; set; }
        public DbSet<BrandModel> Models { get; set; }
        public DbSet<ModelType> ModelTypes { get; set; }
        public DbSet<ShopingCard> ShopingCards { get; set; }

    }
}
