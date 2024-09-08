
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;

//using Shop.ModelArea.Models;
//using Application.Contract.Presistence;

//using Shop.ModelArea.Models.Enums;
//using Shop.ModelArea.Models.VModel;
//using Application.ApplicationContexts;
//using Microsoft.AspNetCore.Authorization;
//using Application.Contract.Services.InterFace;

//namespace Shop.Web.Areas.Admin.Controllers
//{
//    [Area("Admin")]
//    [Authorize(Roles = CustemRole.MasterAdmin + "," + CustemRole.Admin)]
//    public class BrandPostController : Controller
//    {
//        private readonly IUnitOfWork _context;
//        private readonly IUserNameService _userNameService;

//        public BrandPostController(IUnitOfWork context, IUserNameService userNameService)
//        {
//            _context = context;
//            _userNameService = userNameService;
//        }

//        // GET: Admin/BrandPost
//        public async Task<IActionResult> Index()
//        {
//            List<BrandPost> brandPosts = await _context.Post.GetAllBrandPosts();

//            return View(brandPosts);
//        }

//        // GET: Admin/BrandPost/Details/5
//        public async Task<IActionResult> Details(Guid id)
//        {


//            var brandPost = await _context.Post.GetBrandPostById(id);

//            brandPost.CreatedBy = await _userNameService.GetUserName(brandPost.CreatedBy);
//            brandPost.ModifiBy = await _userNameService.GetUserName(brandPost.ModifiBy);

//            if (brandPost == null)
//            {
//                return NotFound();
//            }

//            return View(brandPost);
//        }

//        // GET: Admin/BrandPost/Create
//        public IActionResult Create()
//        {
//            IEnumerable<SelectListItem> brandList = _context.Brand.Query().Select(x => new SelectListItem
//            {
//                Text = x.BrandName.ToUpper(),
//                Value = x.Id.ToString(),

//            });
//            IEnumerable<SelectListItem> brandTypeList = _context.BrandType.Query().Select(x => new SelectListItem
//            {
//                Text = x.Name.ToUpper(),
//                Value = x.Id.ToString(),

//            });
//IEnumerable<SelectListItem> discoutList = Enum.GetValues(typeof(DisCount))
//    .Cast<DisCount>()
//    .Select(x => new SelectListItem
//    {
//        Text = x.ToString().ToUpper(),
//        Value = x.ToString()
//    });
//            BrandPostVM brandPostVM = new BrandPostVM
//            {
//                BrandPost = new BrandPost(),
//                BrandList = brandList,
//                BrandTypeList = brandTypeList,
//                DiscoutList = discoutList

//            };


//            return View(brandPostVM);
//        }

//        // POST: Admin/BrandPost/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]

//        public async Task<IActionResult> Create(BrandPostVM brandPostVm)
//        {
//            if (ModelState.IsValid)
//            {
//                await _context.Post.Create(brandPostVm.BrandPost);
//                await _context.SaveAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View();
//        }

//        // GET: Admin/BrandPost/Edit/5
//        public async Task<IActionResult> Edit(Guid id)
//        {
//            var post = await _context.Post.GetBrandPostById(id);
//            if (post == null)
//            {
//                return NotFound();
//            }
//            IEnumerable<SelectListItem> brandList = _context.Brand.Query().Select(x => new SelectListItem
//            {
//                Text = x.BrandName.ToUpper(),
//                Value = x.Id.ToString(),

//            });
//            IEnumerable<SelectListItem> brandTypeList = _context.BrandType.Query().Select(x => new SelectListItem
//            {
//                Text = x.Name.ToUpper(),
//                Value = x.Id.ToString(),

//            });
//            IEnumerable<SelectListItem> discoutList = Enum.GetValues(typeof(DisCount))
//                .Cast<DisCount>()
//                .Select(x => new SelectListItem
//                {
//                    Text = x.ToString().ToUpper(),
//                    Value = x.ToString()
//                });
//            BrandPostVM brandPostVM = new BrandPostVM
//            {
//                BrandPost = post,
//                BrandList = brandList,
//                BrandTypeList = brandTypeList,
//                DiscoutList = discoutList

//            };


//            return View(brandPostVM);
//        }

//        // POST: Admin/BrandPost/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit( BrandPostVM brandPostVm)
//        {


//            if (ModelState.IsValid)
//            {
//                await _context.Post.Update(brandPostVm.BrandPost);
//                await _context.SaveAsync();

//                return RedirectToAction(nameof(Index));
//            }
//            return View();

//        }

//        // GET: Admin/BrandPost/Delete/5
//        public async Task<IActionResult> Delete(Guid id)
//        {
//            var post = await _context.Post.GetBrandPostById(id);

//            if (post == null)
//            {
//                return NotFound();
//            }



//            IEnumerable<SelectListItem> brandList = _context.Brand.Query().Select(x => new SelectListItem
//            {
//                Text = x.BrandName.ToUpper(),
//                Value = x.Id.ToString(),

//            });
//            IEnumerable<SelectListItem> brandTypeList = _context.BrandType.Query().Select(x => new SelectListItem
//            {
//                Text = x.Name.ToUpper(),
//                Value = x.Id.ToString(),

//            });
//            IEnumerable<SelectListItem> discoutList = Enum.GetValues(typeof(DisCount))
//                .Cast<DisCount>()
//                .Select(x => new SelectListItem
//                {
//                    Text = x.ToString().ToUpper(),
//                    Value = x.ToString()
//                });
//            BrandPostVM brandPostVM = new BrandPostVM
//            {
//                BrandPost = post,
//                BrandList = brandList,
//                BrandTypeList = brandTypeList,
//                DiscoutList = discoutList

//            };


//            return View(brandPostVM);
//        }

//        // POST: Admin/BrandPost/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(BrandPostVM brandPostVM)
//        {
//            var brandPost = await _context.Post.GetByIdAsync(brandPostVM.BrandPost.Id);
//            if (brandPost != null)
//            {
//                await _context.Post.Delete(brandPostVM.BrandPost);
//            }

//            await _context.SaveAsync();
//            return RedirectToAction(nameof(Index));
//        }
//    }
//}
