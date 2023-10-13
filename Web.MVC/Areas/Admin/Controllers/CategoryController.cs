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
    public class CategoryController : Controller
    {
        private readonly IMapper _mapper;
        private readonly CategoryDto _categoryDto;

        public CategoryController(IMapper mapper, CategoryDto categoryDto)
        {
            _mapper = mapper;
            _categoryDto = categoryDto;
        }

        // GET: Admin/Category
        public async Task<ActionResult> Index()
        {
            var categoryList = await _categoryDto.GetAll();

            var categoryListViewModel =
                _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(categoryList);

            return await Task.FromResult(View(categoryListViewModel));
        }

        [HttpGet]
        public async Task<ActionResult> Create()
            => await Task.FromResult(View());

        [HttpPost]
        public async Task<ActionResult> Create(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var createCategory = _mapper.Map<Category>(model);
                ContextStatus createStatus = await _categoryDto.Create(createCategory);
                if (createStatus == ContextStatus.Created)
                {
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("", @"Lỗi thêm mới");

                return View(model);
            }

            ModelState.AddModelError("", @"Dữ liệu vào không hợp lệ");

            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> Update(int id)
        {
            var category = await _categoryDto.GetById(id);
            var categoryViewModel = _mapper.Map<CategoryViewModel>(category);
            return await Task.FromResult(View(categoryViewModel));
        }

        [HttpPost]
        public async Task<ActionResult> Update(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var createCategory = _mapper.Map<Category>(model);
                ContextStatus createStatus = await _categoryDto.Update(createCategory);
                if (createStatus == ContextStatus.Updated)
                {
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("", @"Lỗi cập nhật");

                return View(model);
            }

            ModelState.AddModelError("", @"Dữ liệu vào không hợp lệ");

            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var category = await _categoryDto.GetById(id);
            var categoryViewModel = _mapper.Map<CategoryViewModel>(category);
            return await Task.FromResult(View(categoryViewModel));
        }

        [HttpPost]
        public async Task<ActionResult> Delete(CategoryViewModel model)
        {

            ContextStatus createStatus = await _categoryDto.Delete(model.Id);
            if (createStatus == ContextStatus.Deleted)
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", @"Lỗi xóa");

            return View(model);

        }
    }
}