using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HotelModel;
using HotelRest.DBUtil;

namespace HotelRest.Controllers
{
    public class GuestController : ApiController
    {
        ManageGuest mnGuest = new ManageGuest();
        // GET: api/Guest
        public IEnumerable<Guest> Get()
        {
            return mnGuest.GetAllGuest();
            //return new [] { "value1", "value2" };
        }

        // GET: api/Guest/5
        public Guest Get(int id)
        {
            return mnGuest.GetGuestFromId(id);
            //return "value";
        }

        // POST: api/Guest
        public void Post([FromBody]Guest value)
        {
            mnGuest.CreateGuest(value);
        }

        // PUT: api/Guest/5
        public void Put(int id, [FromBody]Guest value)
        {
            mnGuest.UpdateGuest(value, id);
        }

        // DELETE: api/Guest/5
        public void Delete(int id)
        {
            mnGuest.DeleteGuest(id);
        }
    }
}
