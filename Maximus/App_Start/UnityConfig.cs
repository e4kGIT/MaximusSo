using Maximus.Data;
using Maximus.Data.Interface.Concrete;
using Maximus.Data.InterFace;
using Maximus.Services;
using Maximus.Services.Interface;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace Maximus
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IHome, HomeService>();
            container.RegisterType<IUser, UserService>();
            container.RegisterType<IBasket, BasketService>();
            container.RegisterType<ISettings, SettingsService>();
            container.RegisterType<IEmployee, EmployeeService>();
            container.RegisterType<IOrderDisplay, OrderDisplayService>();
            container.RegisterType<IReturn, ReturnService>();
            container.RegisterType<IImportExport, ImportExportService>();
            container.RegisterType<IPointsAdjustment, PointsAdjustmentService>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}