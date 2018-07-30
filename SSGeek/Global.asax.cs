using Ninject;
using Ninject.Web.Common.WebHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Configuration;
using SSGeek.DAL;

namespace SSGeek
{
    public class MvcApplication : NinjectHttpApplication
    {
        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
        
        // Configure the dependency injection container.
        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            //Binding for Forum Post
            string connectionString = ConfigurationManager.ConnectionStrings["SSGeek"].ConnectionString;
            //kernel.Bind<IForumPostDAL>().To<MockForumPostSqlDAL>().WithConstructorArgument("connectionString", connectionString);
            kernel.Bind<IForumPostDAL>().To<ForumPostSqlDAL>().WithConstructorArgument("connectionString", connectionString);
            // Set up the bindings
            //kernel.Bind<IInterface>.To<Class>();
            kernel.Bind<IProductDAL>().To<ProductSqlDAL>().WithConstructorArgument("connectionString", connectionString);
            //kernel.Bind<IProductDAL>().To<MockProductSqlDAL>().WithConstructorArgument("connectionString", connectionString);

            return kernel;
        }
    }
}
