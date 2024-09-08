
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shop.ModelArea.Models;
using Application.Contract.Presistence;
using Application.Contract.ExtensionsMethods;
using Shop.ModelArea.Models.VModel;

namespace Shop.Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _context;

        public HomeController(IUnitOfWork context)
        {
            _context = context;
        }

        // GET: Customer/Home
        public async Task<IActionResult> Index(int? page, bool reseFilter = false)
        {
            IEnumerable<SelectListItem> brandList = _context.Brand.Query().Select(x => new SelectListItem
            {
                Text = x.BrandName.ToUpper(),
                Value = x.Id.ToString(),

            });

            IEnumerable<SelectListItem> brandTypeList = _context.BrandType.Query().Select(x => new SelectListItem
            {
                Text = x.Name.ToUpper(),
                Value = x.Id.ToString(),

            });

            IEnumerable<SelectListItem> modelTypeList = _context.ModelType.Query().Select(x => new SelectListItem
            {
                Text = x.Name.ToUpper(),
                Value = x.Id.ToString(),

            });
            List<BrandModel> brandPosts;
            if (reseFilter)
            {
                TempData.Remove("FiteredModel");
                TempData.Remove("SelectedBrandId");
                TempData.Remove("SelectedBrandTypeId");
            }
            if (TempData.ContainsKey("FiteredPost"))
            {
                brandPosts = TempData.Get<List<BrandModel>>("FiteredModel");
                TempData.Keep("FiteredModel");

            }
            else
            {
                brandPosts = await _context.Models.GetAllBrandModels();
            }
            int pageSize = 10;
            int pageNumber = page ?? 1;
            int totalItems = brandPosts.Count;
            int totalPage = (int)Math.Ceiling((double)totalItems / pageSize);
            var pagePosts = brandPosts.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            HomePostVM homePostVM = new HomePostVM()
            {
                BrandModel = pagePosts,
                BrandList = brandList,
                ModelTypeList = modelTypeList,
                BrandId = (Guid?)TempData["SelectBrandId"],
                BrandTypeId = (Guid?)TempData["SelectBrandTypeId"],
            };

            List<BrandModel> brandModel = await _context.Models.GetAllBrandModels();
            return View(homePostVM);
        }

        [HttpPost]
        public async Task<IActionResult> Index(HomePostVM homePostVM)
        {
            var posts = await _context.Models.GetAllModels(
                homePostVM.SearchBox,
                homePostVM.BrandId,
                homePostVM.BrandTypeId);


            TempData.Put("FiteredModel", posts);
            TempData["FiteredBrandId"] = homePostVM.BrandId;
            TempData["FiteredBrandTypeId"] = homePostVM.BrandTypeId;

            return RedirectToAction("Index", new { page = 1, resetFilter = false });

        }


        // GET: Customer/Home/Details/5
        public async Task<IActionResult> Details(Guid id, int? page)
        {
            BrandModel post = await _context.Models.GetBrandPostById(id);
            List<BrandModel> brandPosts = new List<BrandModel>();

            //if (post != null)
            //{
            //    post = await _context.Post.GetAllPosts(post.Id, post.BrandId);
            //}

            //ViewBag.CurrentPage = page;

            //CustomerDe

            var brandPost = await _context.Models.GetBrandPostById(id);



            if (brandPost == null)
            {
                return NotFound();
            }

            return View(brandPost);

        }

        //public async Task<IActionResult> Brands(Guid id)
        //{
        //    return ();
        //}


    }
}
