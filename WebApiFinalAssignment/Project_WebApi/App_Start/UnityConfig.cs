using BAL;
using BAL.Helper;
using BAL.Interface;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace Project_WebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IHotelDetail, HotelDetail>();
            container.RegisterType<IRoomDetail, RoomDetail>();
            container.RegisterType<IBookingDetail, BookingDetail>();

            container.AddNewExtension<UnityRepositoryHelper>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}