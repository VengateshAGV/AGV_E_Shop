using Application.Contract.Presistence;
using DataConnections.Data;
using Microsoft.EntityFrameworkCore;
using Shop.ModelArea.Models;

namespace DataConnections.Repositories
{
    public class BrandTypeRepositry : GenaricRepositry<BrandType>, IBrandTypeRepositry
    {
        public BrandTypeRepositry(ApplicationContext context) : base(context) { }

        public async Task Update(BrandType brandType)
        {
           var objFrom = await _context.BrandTypes.FirstOrDefaultAsync(x => x.Id == brandType.Id);

            if (objFrom != null)
            {
                objFrom.Name = brandType.Name;
            }
            _context.Update(objFrom);
        }
    }
}
