
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;

//using Application.Contract.Presistence;
//using Shop.ModelArea.Models;
//using Shop.ModelArea.Models.VModel;
//using Application.Contract.ExtensionsMethods;

//namespace Shop.Web.Areas.Customer.Controllers
//{
//    [Area("Customer")]
//    public class BrandPostController : Controller
//    {
//        private readonly IUnitOfWork _context;

//        public BrandPostController(IUnitOfWork context)
//        {
//            _context = context;
//        }

//        // GET: Customer/BrandPost
//        public async Task<IActionResult> Index(int? page, bool reseFilter = false )
//        {
//IEnumerable<SelectListItem> brandList = _context.Brand.Query().Select(x => new SelectListItem
//{
//    Text = x.BrandName.ToUpper(),
//    Value = x.Id.ToString(),

//});
//IEnumerable<SelectListItem> brandTypeList = _context.BrandType.Query().Select(x => new SelectListItem
//{
//    Text = x.Name.ToUpper(),
//    Value = x.Id.ToString(),

//});
//List<BrandPost> brandPosts;
//if (reseFilter)
//{
//    TempData.Remove("FiteredPost");
//    TempData.Remove("SelectedBrandId");
//    TempData.Remove("SelectedBrandTypeId");
//}
//if (TempData.ContainsKey("FiteredPost"))
//{
//    brandPosts = TempData.Get<List<BrandPost>>("FiteredPost");
//    TempData.Keep("FiteredPost");

//}
//else
//{
//    brandPosts = await _context.Post.GetAllBrandPosts();
//}
//int pageSize = 3;
//int pageNumber = page ?? 1;
//int totalItems = brandPosts.Count;
//int totalPage = (int)Math.Ceiling((double)totalItems / pageSize);
//var pagePosts = brandPosts.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

//HomePostVM homePostVM = new HomePostVM()
//{
//    BrandPosts = pagePosts,
//    BrandList = brandList,
//    BrandTypeList = brandTypeList,
//    BrandId = (Guid?)TempData["SelectBrandId"],
//    BrandTypeId = (Guid?)TempData["SelectBrandTypeId"],
//};

//var applicationContext = await _context.Post.GetAllBrandPosts();
//return View(homePostVM);
//        }

//        [HttpPost]
//        public async Task<IActionResult> Index(HomePostVM homePostVM)
//        {
//            var posts = await _context.Post.GetAllPosts(
//                homePostVM.SearchBox,
//                homePostVM.BrandId,
//                homePostVM.BrandTypeId);


//            TempData.Put("FiteredPost",posts);
//            TempData["FiteredBrandId"] = homePostVM.BrandId;
//            TempData["FiteredBrandTypeId"] = homePostVM.BrandTypeId;

//            return RedirectToAction("Index", new {page =1, resetFilter = false});
            
//        }

//        // GET: Customer/BrandPost/Details/5
//        public async Task<IActionResult> Details(Guid id,int? page)
//        {
//            BrandPost post = await _context.Post.GetBrandPostById(id);
//            List<BrandPost> brandPosts = new List<BrandPost>();

//            //if (post != null)
//            //{
//            //    post = await _context.Post.GetAllPosts(post.Id, post.BrandId);
//            //}

//            //ViewBag.CurrentPage = page;

//            //CustomerDe

//            var brandPost = await _context.Post.GetBrandPostById(id);


             
//            if (brandPost == null)
//            {
//                return NotFound();
//            }

//            return View(brandPost);
//        }

       

       
//    }
//}
