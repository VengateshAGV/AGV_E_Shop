
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataConnections.Data;
using Shop.ModelArea.Models;
using Application.Contract.Presistence;
using Shop.ModelArea.Models.VModel;
using Application.ApplicationContexts;
using Microsoft.AspNetCore.Authorization;

namespace Shop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = CustemRole.MasterAdmin + "," + CustemRole.Admin)]
    public class ModelTypeController : Controller
    {
        private readonly IUnitOfWork _context;

        public ModelTypeController(IUnitOfWork context)
        {
            _context = context;
        }

        // GET: Admin/ModelType
        public async Task<IActionResult> Index()
        {
            var applicationContext = await _context.ModelType.GetAllModelsType();
            return View(applicationContext);
        }

        // GET: Admin/ModelType/Details/5
        public async Task<IActionResult> Details(Guid id)
        {


            var modelType = await _context.ModelType.GetModelTypeById(id);
                
            if (modelType == null)
            {
                return NotFound();
            }

            return View(modelType);
        }

        // GET: Admin/ModelType/Create
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> brandTypeList = _context.BrandType.Query().Select(x => new SelectListItem
            {
                Text = x.Name.ToUpper(),
                Value = x.Id.ToString(),
            });
            ModelTypeVM modeltype = new ModelTypeVM
            {
                BrandTypeList = brandTypeList,
            };

            return View(modeltype);
        }

        // POST: Admin/ModelType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( ModelTypeVM modelTypeVM)
        {
            if (ModelState.IsValid)
            {
                await _context.ModelType.Create(modelTypeVM.ModelType);
                await _context.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View();
        }

        // GET: Admin/ModelType/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            

            var modelType = await _context.ModelType.GetModelTypeById(id);
            if (modelType == null)
            {
                return NotFound();
            }
            IEnumerable<SelectListItem> brandTypeList = _context.BrandType.Query().Select(x => new SelectListItem
            {
                Text = x.Name.ToUpper(),
                Value = x.Id.ToString(),
            });
            ModelTypeVM modeltypeVM = new ModelTypeVM
            {
                BrandTypeList = brandTypeList,
            };

            return View(modeltypeVM);
        }

        // POST: Admin/ModelType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ModelTypeVM modelTypeVM)
        {
           

            if (ModelState.IsValid)
            {
               
                    await _context.ModelType.Update(modelTypeVM.ModelType);
                    await _context.SaveAsync();
                
                return RedirectToAction(nameof(Index));
            }
            
            return View();
        }

        // GET: Admin/ModelType/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {


            var modelType = await _context.ModelType.GetModelTypeById(id);
                
            if (modelType == null)
            {
                return NotFound();
            }

            IEnumerable<SelectListItem> brandTypeList = _context.BrandType.Query().Select(x => new SelectListItem
            {
                Text = x.Name.ToUpper(),
                Value = x.Id.ToString(),
            });
            ModelTypeVM modeltypeVM = new ModelTypeVM
            {
                BrandTypeList = brandTypeList,
            };

            return View(modeltypeVM);
        }

        // POST: Admin/ModelType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(ModelTypeVM modelTypeVM)
        {
            
            if (modelTypeVM != null)
            {
               await _context.ModelType.Delete(modelTypeVM.ModelType);
            }

            await _context.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

       
    }
}
