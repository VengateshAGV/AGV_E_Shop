
using Microsoft.AspNetCore.Mvc;
using Shop.ModelArea.Models;
using Application.ApplicationContexts;
using Microsoft.AspNetCore.Authorization;
using Application.Contract.Presistence;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Shop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = CustemRole.MasterAdmin + "," + CustemRole.Admin)]
    public class BrandTypeController : Controller
    {
        private readonly IUnitOfWork _context;

        public BrandTypeController(IUnitOfWork context)
        {
            _context = context;
        }

        // GET: Admin/BrandType
        public async Task<IActionResult> Index()
        {
            return View(await _context.BrandType.GetAllAsync());
        }

        // GET: Admin/BrandType/Details/5
        public async Task<IActionResult> Details(Guid id)
        {


            var brandType = await _context.BrandType.GetByIdAsync(id);
                
            if (brandType == null)
            {
                return NotFound();
            }

            return View(brandType);
        }

        // GET: Admin/BrandType/Create
        public IActionResult Create()
        {
            

            return View();
        }

        // POST: Admin/BrandType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BrandType brandType)
        {
            if (ModelState.IsValid)
            {
                await _context.BrandType.Create(brandType);
                await _context.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(brandType);
        }

        // GET: Admin/BrandType/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            

            var brandType = await _context.BrandType.GetByIdAsync(id);
            if (brandType == null)
            {
                return NotFound();
            }
            return View(brandType);
        }

        // POST: Admin/BrandType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit( BrandType brandType)
        {
            

            if (ModelState.IsValid)
            {
                
                   await _context.BrandType.Update(brandType);
                    await _context.SaveAsync();
                
                
                return RedirectToAction(nameof(Index));
            }
            return View(brandType);
        }

        // GET: Admin/BrandType/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            

            var brandType = await _context.BrandType.GetByIdAsync(id);
                
            if (brandType == null)
            {
                return NotFound();
            }

            return View(brandType);
        }

        // POST: Admin/BrandType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var brandType = await _context.BrandType.GetByIdAsync(id);
            if (brandType != null)
            {
               await _context.BrandType.Delete(brandType);
            }

            await _context.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        
    }
}
