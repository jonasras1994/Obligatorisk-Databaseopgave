using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelModels
{
    public class Facilities
    {
        public Facilities(int hotel_no, bool swimmingpool, bool tabletennis, bool pooltable, bool bar)
        {
            Hotel_no = hotel_no;
            Swimmingpool = swimmingpool;
            Tabletennis = tabletennis;
            Pooltable = pooltable;
            Bar = bar;
        }

        public Facilities()
        {
            
        }

        public int Hotel_no { get; set; }
        public bool Swimmingpool { get; set; }
        public bool Tabletennis { get; set; }
        public bool Pooltable { get; set; }
        public bool Bar { get; set; }
    }
}
