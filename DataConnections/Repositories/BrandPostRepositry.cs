

//using Application.Contract.Presistence;
//using DataConnections.Data;
//using Microsoft.EntityFrameworkCore;
//using Shop.ModelArea.Models;

//namespace DataConnections.Repositories
//{
//    public class BrandPostRepositry : GenaricRepositry<BrandPost>, IBrandPostRepositry
//    {
//        public BrandPostRepositry(ApplicationContext context) : base(context) { }

        

//        public async Task Update(BrandPost brandPost)
//        {
//            var objFrom = await _context.BrandPosts.FirstOrDefaultAsync(x => x.Id == brandPost.Id);
//            if (objFrom != null)
//            {
//                objFrom.BrandId = brandPost.BrandId;
//                objFrom.BrandTypeId = brandPost.BrandTypeId;
//                objFrom.DisCount = brandPost.DisCount;
//                objFrom.Rattings = brandPost.Rattings;
//                objFrom.Price = brandPost.Price;

//            }
//            _context.Update(objFrom);
//        }
//        public async Task<List<BrandPost>> GetAllBrandPosts()
//        {
//            return await _context.BrandPosts.Include(x => x.Brand).Include(x => x.BrandType).ToListAsync();
//        }

//        public async Task<BrandPost> GetBrandPostById(Guid id)
//        {
//            return await _context.BrandPosts.Include(x => x.Brand).Include(x => x.BrandType).FirstOrDefaultAsync
//                (x => x.Id == id);
//        }

//        public async Task<List<BrandPost>> GetAllPosts(Guid? SkipRecord, Guid? brandId)
//        {
//            var query = _context.BrandPosts.Include(x => x.Brand).Include(x => x.BrandType).OrderByDescending(x => x.ModifiOn);

//            if(brandId == Guid.Empty)
//            {
//                return await query.ToListAsync();
//            }
//            if (brandId != Guid.Empty)
//            {
//                query = (IOrderedQueryable<BrandPost>)query.Where(x => x.BrandId == brandId);

//            }
//            var post = await query.ToListAsync();

//            if (SkipRecord.HasValue)
//            {
//                var recordToRemove = post.FirstOrDefault(x=>x.Id == SkipRecord.Value);
//                if (recordToRemove != null)
//                {
//                    post.Remove(recordToRemove);
//                }
//            }
//            return post;
//        }

//        public async Task<List<BrandPost>> GetAllPosts(string searchName, Guid? brandId, Guid? brandTypeId)
//        {
//            var query = _context.BrandPosts.Include(x => x.Brand).Include(x => x.BrandType).OrderByDescending(x => x.ModifiOn);

//            if (searchName == string.Empty && brandId == Guid.Empty && brandTypeId == Guid.Empty)
//            {
//                return await query.ToListAsync();
//            }

//            if(brandId != Guid.Empty )
//            {
//                query = (IOrderedQueryable<BrandPost>)query.Where(x => x.BrandId == brandId);
//            }
//            if (brandTypeId != Guid.Empty)
//            {
//                query = (IOrderedQueryable<BrandPost>)query.Where(x=>x.BrandTypeId == brandTypeId);
//            }
//            //if (!string.IsNullOrEmpty(searchName))
//            //{
//            //    query = (IQueryable<BrandPost>)query.Where(x => x.Name.Contains(searchName));
//            //}
//            return await query.ToListAsync();
//        }
//    }
//}
