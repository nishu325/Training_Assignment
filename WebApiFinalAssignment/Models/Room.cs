using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Room
    {
        public int Id { get; set; }
        public int Hotel_Id { get; set; }
        public string RoomCategory { get; set; }
        public int RoomPrice { get; set; }
        public string IsActive { get; set; }
        public string RoomNo { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public virtual Hotel Hotel { get; set; }
    }
}
