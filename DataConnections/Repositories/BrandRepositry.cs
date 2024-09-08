using Application.Contract.Presistence;
using DataConnections.Data;
using Microsoft.EntityFrameworkCore;
using Shop.ModelArea.Models;

namespace DataConnections.Repositories
{
    internal class BrandRepositry : GenaricRepositry<Brand>, IBrandRepositry
    {
        public BrandRepositry(ApplicationContext context) : base(context) { }

        public async Task<List<Brand>> GetAllBrand()
        {
            
            return await _context.Brands.ToListAsync();
            
        }

        public Task<Brand> GetBrandById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Brand brand)
        {
            var objFrom = await _context.Brands.FirstOrDefaultAsync(x => x.Id == brand.Id);

            if (objFrom != null)
            {
                objFrom.BrandName = brand.BrandName;
                objFrom.PhoneNumber = brand.PhoneNumber;
                objFrom.Cuntry = brand.Cuntry;
                objFrom.Street = brand.Street;
                objFrom.State = brand.State;
                objFrom.City = brand.City;
                objFrom.PostalCode = brand.PostalCode;
                if (brand.BrandLogo != null)
                {
                    objFrom.BrandLogo = brand.BrandLogo;
                }
                _context.Update(objFrom);

            }
        }
        
    }
}
