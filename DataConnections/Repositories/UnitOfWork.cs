

using Application.Contract.Presistence;
using DataConnections.Common;
using DataConnections.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Shop.ModelArea.Models;

namespace DataConnections.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly ApplicationContext _context;
        private readonly UserManager<UserID> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UnitOfWork(ApplicationContext context, UserManager<UserID> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor= httpContextAccessor;
            Brand = new BrandRepositry(_context);
            BrandType = new BrandTypeRepositry(_context);
            Models = new BrandModelRepositry(_context);
            ModelType = new ModelTypeRepositry(_context);
            //Post = new BrandPostRepositry(_context);
        }

        public IBrandRepositry Brand { get; private set; }

        public IBrandTypeRepositry BrandType {  get; private set; }

        

        public IBrandModelRepositry Models {  get; private set; }

        public IModelTypeRepositry ModelType {  get; private set; }
        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task SaveAsync()
        {
            _context.saveCommonFields(_userManager,_httpContextAccessor);
            await _context.SaveChangesAsync();
        }
    }
}
