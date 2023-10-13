using AutoMapper;
using DataModels.EF;
using Web.MVC.Areas.Admin.Models;

namespace Web.MVC.Assets.Common.Library.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static IMapper Configure()
        {
            var config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<Product, ProductViewModel>();
                    cfg.CreateMap<ProductViewModel, Product>();
                    cfg.CreateMap<Category, CategoryViewModel>();
                    cfg.CreateMap<CategoryViewModel, Category>();
                }

            );
            return config.CreateMapper();
        }
    }
}