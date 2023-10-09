using AutoMapper;
using Ninject;
using Ninject.Web.Common.WebHost;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;
using Web.MVC.Assets.Common.Library.AutoMapper;

namespace Web.MVC
{
    public class MvcApplication : NinjectHttpApplication
    {
        //protected void Application_Start()
        //{
        //    AreaRegistration.RegisterAllAreas();
        //    RouteConfig.RegisterRoutes(RouteTable.Routes);
        //}

        protected override void OnApplicationStarted()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            RegisterServices(kernel);
            return kernel;
        }

        private void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IMapper>().ToConstant(AutoMapperConfiguration.Configure());
        }
    }
}
