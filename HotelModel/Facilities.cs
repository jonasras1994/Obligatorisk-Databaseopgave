using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelModel
{
    public class Facilities
    {
        public int Hotel_no { get; set; }
        public bool Swimmingpool { get; set; }
        public bool Tabletennis { get; set; }
        public bool Pooltable { get; set; }
        public bool Bar { get; set; }

        public Facilities()
        {

        }

        public Facilities(int hotel_no, bool swimmingpool, bool tabletennis, bool pooltable, bool bar)
        {
            Hotel_no = hotel_no;
            Swimmingpool = swimmingpool;
            Tabletennis = tabletennis;
            Pooltable = pooltable;
            Bar = bar;
        }

        public override string ToString()
        {
            return $"Hotelnummer: {Hotel_no} \t Swimmingpool: {Swimmingpool} \t Bordtennis: {Tabletennis} \t Poolbord: {Pooltable} \t Bar: {Bar}";
        }
    }
}
