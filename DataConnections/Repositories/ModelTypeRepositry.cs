

using Application.Contract.Presistence;
using DataConnections.Data;
using Microsoft.EntityFrameworkCore;
using Shop.ModelArea.Models;

namespace DataConnections.Repositories
{
    public class ModelTypeRepositry : GenaricRepositry<ModelType>, IModelTypeRepositry
    {
        public ModelTypeRepositry(ApplicationContext context) : base(context) { }

        public async Task<List<ModelType>> GetAllModelsType()
        {
            return await _context.ModelTypes.Include(x => x.BrandType).ToListAsync();
        }

        public async Task<ModelType> GetModelTypeById(Guid id)
        {
            return await _context.ModelTypes.Include(x => x.BrandType).FirstOrDefaultAsync(x=>x.Id == id);
        }

        public async Task Update(ModelType modelType)
        {
            var objFrom = await _context.ModelTypes.FirstOrDefaultAsync(x => x.Id == modelType.Id);

            if (objFrom != null)
            {
                objFrom.Name = modelType.Name;
            }
            _context.Update(objFrom);
        }
    }
}
