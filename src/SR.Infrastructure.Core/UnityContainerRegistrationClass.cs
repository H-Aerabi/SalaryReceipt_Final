

//using SR.Application;
//using SR.Application.Contract.User;
//using SR.Domain.UserAgg;
//using SR.Infrastructure.EF.Contexts;
//using SR.Infrastructure.EF.Repositories;
//using System.Web.Mvc;
//using Unity;
//using Unity.AspNet.Mvc;

//namespace SR.Infrastructure.Core
//{
//    public class UnityContainerRegistrationClass
//    {
//        public static IUnityContainer InitialiseContainer()
//        {
//            // Initialize the container
//            var container = new UnityContainer();

//            // Register the dependency
//            container.RegisterType<IUserRepository, UserRepository>();
//            container.RegisterType<IUserApplication, UserApplication>();

//            container.RegisterType<SalaryReceiptContext, SalaryReceiptContext>();
            
//            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
//            return container;
//        }
//    }
//}
