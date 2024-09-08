using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataConnections.Data;
using Shop.ModelArea.Models;
using Application.Contract.Presistence;
using Shop.ModelArea.Models.VModel;
using Shop.ModelArea.Models.Enums;
using System.Drawing.Drawing2D;
using Application.ApplicationContexts;
using Microsoft.AspNetCore.Authorization;

namespace Shop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = CustemRole.MasterAdmin + "," + CustemRole.Admin)]
    public class ModelController : Controller
    {
        private readonly IUnitOfWork _context;

        private readonly IWebHostEnvironment _webHost;

        public ModelController(IUnitOfWork context, IWebHostEnvironment webHost)
        {
            _context = context;
            _webHost = webHost;
        }

        // GET: Admin/Model
        public async Task<IActionResult> Index()
        {
            List<BrandModel> brandModel  = await _context.Models.GetAllBrandModels();
            return View( brandModel);
        }

        // GET: Admin/Model/Details/5
        public async Task<IActionResult> Details(Guid id)
        {


            var brandModel = await _context.Models.GetBrandPostById(id);
               
            if (brandModel == null)
            {
                return NotFound();
            }

            return View(brandModel);
        }

        // GET: Admin/Model/Create
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> brandList = _context.Brand.Query().Select(x => new SelectListItem
            {
                Text = x.BrandName.ToUpper(),
                Value = x.Id.ToString(),
            });
            IEnumerable<SelectListItem> modelTypeList = _context.ModelType.Query().Select(x => new SelectListItem
            {
                Text = x.Name.ToUpper(),
                Value = x.Id.ToString(),
            });
            IEnumerable<SelectListItem> discoutList = Enum.GetValues(typeof(DisCount))
             .Cast<DisCount>()
             .Select(x => new SelectListItem
                {
                    Text = x.ToString().ToUpper(),
                    Value = x.ToString()
                });

            BrandModelVM modelType = new BrandModelVM
            {
                BrandList = brandList,
                ModelTypeList = modelTypeList,
                DisCountList = discoutList,
            };

            return View(modelType);
        }

        // POST: Admin/Model/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( BrandModelVM brandModelVM)
        {

            string rootPath = _webHost.WebRootPath;
            var file = HttpContext.Request.Form.Files;

            if (file.Count > 0)
            {
                string newfile = Guid.NewGuid().ToString();

                var upload = Path.Combine(rootPath, @"image\model");

                var extension = Path.GetExtension(file[0].FileName);

                using (var fileStream = new FileStream(Path.Combine(upload, newfile + extension), FileMode.Create))
                {
                    file[0].CopyTo(fileStream);
                }
                brandModelVM.BrandModel.Image = @"\image\model\" + newfile + extension;
            }

            if (ModelState.IsValid)
            {
               await _context.Models.Create(brandModelVM.BrandModel); 
               
                await _context.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View();
        }

        // GET: Admin/Model/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            

            var brandModel = await _context.Models.GetByIdAsync(id);
            if (brandModel == null)
            {
                return NotFound();
            }
            
            return View(brandModel);
        }

        // POST: Admin/Model/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Image,LounchDate,ModelVersion,BrandId,ModelTypeId,Size,Wight,Height,Width,Material,Color,Description,Price,Price1,Discount,Rattings,Count,Id,CreatedOn,CreatedBy,ModifiOn,ModifiBy")] BrandModel brandModel)
        {
            if (id != brandModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   await _context.Models.Update(brandModel);
                    await _context.SaveAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    
                }
                return RedirectToAction(nameof(Index));
            }
            
            return View(brandModel);
        }

        // GET: Admin/Model/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            

            var brandModel = await _context.Models.GetByIdAsync(id);
                
            if (brandModel == null)
            {
                return NotFound();
            }

            return View(brandModel);
        }

        // POST: Admin/Model/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var brandModel = await _context.Models.GetByIdAsync(id);
            if (brandModel != null)
            {
               await _context.Models.Delete(brandModel);
            }

            await _context.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        
    }
}
