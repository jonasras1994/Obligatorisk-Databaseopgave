using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelModels
{
    public class Guest
    {
        public Guest(int guest_no, string address, string name)
        {
            Guest_no = guest_no;
            Address = address;
            Name = name;
        }

        public Guest()
        {
            
        }

        public int Guest_no { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
    }
}
