
using Microsoft.AspNetCore.Mvc;
using Shop.ModelArea.Models;
using Application.Contract.Presistence;
using Microsoft.AspNetCore.Authorization;
using Application.ApplicationContexts;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shop.ModelArea.Models.Enums;
using Shop.ModelArea.Models.VModel;

namespace Shop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = CustemRole.MasterAdmin + "," + CustemRole.Admin)]
    public class BrandController : Controller
    {
        private readonly IUnitOfWork _context;

        private readonly IWebHostEnvironment _webHost;

        public BrandController(IUnitOfWork context, IWebHostEnvironment webHost)
        {
            _context = context;
            _webHost = webHost;
        }

        // GET: Admin/Brand
        public async Task<IActionResult> Index()
        {
            List<Brand> brand = await _context.Brand.GetAllBrand();
            return View(brand);
        }

        // GET: Admin/Brand/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            

            var brand = await _context.Brand.GetByIdAsync(id);
                
            if (brand == null)
            {
                return NotFound();
            }

            return View(brand);
        }

        // GET: Admin/Brand/Create
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> cunteryList = Enum.GetValues(typeof(Cuntry))
             .Cast<Cuntry>()
             .Select(x => new SelectListItem
             {
                 Text = x.ToString().ToUpper(),
                 Value = x.ToString()
             });
            BrandVM brand = new BrandVM
            {
                
                CunteryList = cunteryList,
            };
            return View(brand);
        }

        // POST: Admin/Brand/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BrandVM brandVM)
        {
            string rootPath = _webHost.WebRootPath;
            var file = HttpContext.Request.Form.Files;

            if (file.Count > 0)
            {
                string newfile = Guid.NewGuid().ToString();

                var upload = Path.Combine(rootPath, @"image\brand");

                var extension = Path.GetExtension(file[0].FileName);

                using (var fileStream = new FileStream(Path.Combine(upload, newfile + extension), FileMode.Create))
                {
                    file[0].CopyTo(fileStream);
                }
                brandVM.Brand.BrandLogo = @"\image\brand\" + newfile + extension;
            }

            if (ModelState.IsValid)
            {
                await _context.Brand.Create(brandVM.Brand);
                await _context.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Admin/Brand/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            

            var brand = await _context.Brand.GetByIdAsync(id);
            if (brand == null)
            {
                return NotFound();
            }
            return View(brand);
        }

        // POST: Admin/Brand/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("BrandName,BrandLogo,Street,City,State,Country,PhoneNumber,PostalCode,Id,CreatedOn,ModifiOn,ModifiBy")] Brand brand)
        {
            if (id != brand.Id)
            {
                return NotFound();
            }

            string rootPath = _webHost.WebRootPath;
            var file = HttpContext.Request.Form.Files;

            if (file.Count > 0)
            {
                string newfile = Guid.NewGuid().ToString();

                var upload = Path.Combine(rootPath, @"image\brand");

                var extension = Path.GetExtension(file[0].FileName);

                var objFromDb = await _context.Brand.GetByIdAsync(brand.Id);

                if (objFromDb.BrandLogo != null)
                {
                    var oldimgPath = Path.Combine(rootPath, objFromDb.BrandLogo.Trim('\\'));

                    if (System.IO.File.Exists(oldimgPath))
                    {
                        System.IO.File.Delete(oldimgPath);
                    }
                }

                using (var fileStream = new FileStream(Path.Combine(upload, newfile + extension), FileMode.Create))
                {
                    file[0].CopyTo(fileStream);
                }
                brand.BrandLogo = @"\image\brand\" + newfile + extension;
            }

            if (ModelState.IsValid)
            {
                await _context.Brand.Update(brand);
                await _context.SaveAsync();
                
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Admin/Brand/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {


            var brand = await _context.Brand.GetByIdAsync(id);
                
            if (brand == null)
            {
                return NotFound();
            }

            return View(brand);
        }

        // POST: Admin/Brand/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Brand brand)
        {
            string rootPath = _webHost.WebRootPath;

            if (!string.IsNullOrEmpty(brand.BrandLogo))
            {
                var objFromPath = await _context.Brand.GetByIdAsync(brand.Id);

                if (objFromPath.BrandLogo != null)
                {
                    var oldImagPath = Path.Combine(rootPath, objFromPath.BrandLogo.Trim('\\'));
                    if (System.IO.File.Exists(oldImagPath))
                    {
                        System.IO.File.Delete(oldImagPath);
                    }
                }
            }

            
            if (brand != null)
            {
               await _context.Brand.Delete(brand);
            }

            await _context.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        
    }
}
