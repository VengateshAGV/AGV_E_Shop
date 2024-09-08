using Application.Contract.Presistence;
using DataConnections.Data;
using Microsoft.EntityFrameworkCore;
using Shop.ModelArea.Models;


namespace DataConnections.Repositories
{
    public class BrandModelRepositry : GenaricRepositry<BrandModel>, IBrandModelRepositry
    {
        public BrandModelRepositry(ApplicationContext context) : base(context)
        {
        }

        public async Task<List<BrandModel>> GetAllBrandModels()
        {
            return await _context.Models.Include(x => x.Brand).Include(x => x.ModelType).ToListAsync();
        }

        public async Task<List<BrandModel>> GetAllModels(Guid? SkipRecord, Guid? brandId)
        {
            var query = _context.Models.Include(x => x.Brand).Include(x => x.ModelType).OrderByDescending(x => x.ModifiOn);

            if (brandId == Guid.Empty)
            {
                return await query.ToListAsync();
            }
            if (brandId != Guid.Empty)
            {
                query = (IOrderedQueryable<BrandModel>)query.Where(x => x.BrandId == brandId);

            }
            var post = await query.ToListAsync();

            if (SkipRecord.HasValue)
            {
                var recordToRemove = post.FirstOrDefault(x => x.Id == SkipRecord.Value);
                if (recordToRemove != null)
                {
                    post.Remove(recordToRemove);
                }
            }
            return post;
        }

        public async Task<List<BrandModel>> GetAllModels(string searchName, Guid? brandId, Guid? modelTypeId)
        {
            var query = _context.Models.Include(x => x.Brand).Include(x => x.ModelType).OrderByDescending(x => x.ModifiOn);

            if (searchName == string.Empty && brandId == Guid.Empty && modelTypeId == Guid.Empty)
            {
                return await query.ToListAsync();
            }

            if (brandId != Guid.Empty)
            {
                query = (IOrderedQueryable<BrandModel>)query.Where(x => x.BrandId == brandId);
            }
            if (modelTypeId != Guid.Empty)
            {
                query = (IOrderedQueryable<BrandModel>)query.Where(x => x.ModelTypeId == modelTypeId);
            }
            if (!string.IsNullOrEmpty(searchName))
            {
                query = (IOrderedQueryable<BrandModel>)query.Where(x => x.Name.Contains(searchName));
            }
            return await query.ToListAsync();
        }

        public async Task<BrandModel> GetBrandPostById(Guid id)
        {
            return await _context.Models.Include(x => x.Brand).Include(x => x.ModelType).FirstOrDefaultAsync(x => x.Id == id);
                
        }

        public async Task Update(BrandModel brandModel)
        {
            var objfrom = await _context.Models.FirstOrDefaultAsync(x => x.Id == brandModel.Id);

            if (objfrom != null)
            {
                objfrom.Name = brandModel.Name;
                objfrom.LounchDate = brandModel.LounchDate;
                objfrom.Image = brandModel.Image;
                objfrom.Height=brandModel.Height;
                objfrom.Width=brandModel.Width;
                objfrom.Wight=brandModel.Wight;
                objfrom.Count=brandModel.Count;
                objfrom.Color=brandModel.Color;
                objfrom.DisCount=brandModel.DisCount;
                objfrom.Price=brandModel.Price;
                objfrom.Price1=brandModel.Price1;
                objfrom.Rattings=brandModel.Rattings;
                objfrom.Size=   brandModel.Size;

            }
            _context.Update(objfrom);

        }
    }
}
