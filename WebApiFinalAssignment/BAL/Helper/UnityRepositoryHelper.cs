using DAL;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Extension;

namespace BAL.Helper
{
    public class UnityRepositoryHelper : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IHotelRepository,HotelRepository>();
            Container.RegisterType<IBookingRepository,BookingRepository>();
            Container.RegisterType<IRoomRepository, RoomRepository>();
        }
    }
}
