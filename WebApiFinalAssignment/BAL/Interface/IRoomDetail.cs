﻿using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interface
{
    public interface IRoomDetail
    {    
        string AddRoomDetail(Room model);

        bool GetRoomAvailability(int id,DateTime date);

        List<Room> GetroomDetailByParam(string city,int? pincode,int? price ,string category);
    }
}
