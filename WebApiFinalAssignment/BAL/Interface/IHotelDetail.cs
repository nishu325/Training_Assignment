using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Models;

namespace BAL.Interface
{
    public interface IHotelDetail
    {
        List<Hotel> GetAllHotelDetail();

        string AddHotelDetail(Hotel model);

    }
}
