using AutoMapper;
using DataModels.DTO;
using DataModels.EF;
using DataModels.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Web.MVC.Areas.Admin.Models;

namespace Web.MVC.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ProductDto _productDto;

        public ProductController(IMapper mapper, ProductDto productDto)
        {
            _mapper = mapper;
            _productDto = productDto;
        }
        [HttpGet]
        public async Task<ActionResult> Index()
            => await Task.FromResult<ActionResult>(RedirectToAction("Info"));

        [HttpGet]
        public async Task<ActionResult> Info(string searchString = "", int searchCategoryId = 0)
        {
            var customList = new List<CategoryViewModel>
            {
                new CategoryViewModel()
                {
                    Id = 0,
                    Name = "All",
                    VietnameseName = "Tất cả"
                }
            };
            customList.AddRange(await LoadCategoryList());
            ViewBag.categoryListViewModel = customList;
            ViewBag.searchString = searchString;
            ViewBag.searchCategoryId = searchCategoryId;


            var productList = await _productDto.GetAll(searchString, searchCategoryId);
            var productListViewModel = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(productList);
            return View(productListViewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Add()
        {
            ViewBag.categoryListViewModel = await LoadCategoryList();
            return await Task.FromResult<ActionResult>(View());
        }
        [HttpPost]
        public async Task<ActionResult> Add(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var productDto = new ProductDto();
                var product = _mapper.Map<Product>(model);
                ContextStatus insertResult = await productDto.Create(product);
                if (insertResult == ContextStatus.Created)
                {
                    return RedirectToAction("Info");
                }
            }
            ViewBag.categoryListViewModel = await LoadCategoryList();
            ModelState.AddModelError("", @"Lỗi thêm mới");
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Update(int id)
        {
            ViewBag.categoryListViewModel = await LoadCategoryList();
            var product = await _productDto.GetProductById(id);
            var productViewModel = _mapper.Map<ProductViewModel>(product);
            return await Task.FromResult<ActionResult>(View(productViewModel));
        }
        [HttpPost]
        public async Task<ActionResult> Update(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var productDto = new ProductDto();
                var product = _mapper.Map<Product>(model);
                ContextStatus insertResult = await productDto.Update(product);
                if (insertResult == ContextStatus.Updated)
                {
                    return RedirectToAction("Info");
                }
            }
            ModelState.AddModelError("", @"Lỗi cập nhật");
            ViewBag.categoryListViewModel = await LoadCategoryList();

            return RedirectToAction("Update", model.Id);
        }
        public async Task<ActionResult> Delete(int id)
        {
            var product = await _productDto.GetProductById(id);
            var productViewModel = _mapper.Map<ProductViewModel>(product);
            return await Task.FromResult(View(productViewModel));
        }

        [HttpPost]
        public async Task<ActionResult> Delete(CategoryViewModel model)
        {

            ContextStatus createStatus = await _productDto.Delete(model.Id);
            if (createStatus == ContextStatus.Deleted)
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", @"Lỗi xóa");

            return View();

        }








        private async Task<IEnumerable<CategoryViewModel>> LoadCategoryList()
        {
            var categoryDto = new CategoryDto();
            var categoryList = await categoryDto.GetAll();

            var categoryListViewModel =
                _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(categoryList);

            return categoryListViewModel ?? new List<CategoryViewModel>();
        }
    }
}