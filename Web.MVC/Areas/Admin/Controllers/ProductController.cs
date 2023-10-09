using AutoMapper;
using DataModels.DTO;
using DataModels.EF;
using DataModels.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Web.MVC.Areas.Admin.Models;

namespace Web.MVC.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly IMapper _mapper;

        public ProductController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ActionResult> Index()
            => await Task.FromResult<ActionResult>(RedirectToAction("Info"));

        [HttpGet]
        public async Task<ActionResult> Info()
        {
            var productDto = new ProductDto();
            var productList = await productDto.GetAll();
            var productListViewModels = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(productList);
            return View(productListViewModels);
        }

        [HttpGet]
        public async Task<ActionResult> Add()
            => await Task.FromResult<ActionResult>(View());
        [HttpPost]
        public async Task<ActionResult> Add(ProductViewModel model)
        {
            var uploadImage = Request.Files[nameof(model.ImageUrl)];
            model.ImageUrl = HandleFile(uploadImage);
            if (ModelState.IsValid)
            {
                var productDto = new ProductDto();
                var product = _mapper.Map<Product>(model);
                ProductStatus insertResult = await productDto.Create(product);
                if (insertResult == ProductStatus.Created)
                {
                    return RedirectToAction("Info");
                }
            }
            ModelState.AddModelError("", @"Lỗi thêm mới");
            return View();
        }

        private string HandleFile(HttpPostedFileBase uploadImage)
        {
            if (uploadImage != null && uploadImage.ContentLength > 0)
            {
                var folderPath = Server.MapPath("~/Uploads/Images");
                uploadImage.SaveAs(Path.Combine(folderPath, uploadImage.FileName));
                return "\\" + Path.Combine("Uploads", "Images", uploadImage.FileName);
            }
            return String.Empty;
        }
    }
}