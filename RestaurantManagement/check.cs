using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

using RestaurantManagement.Data;


namespace RestaurantManagement
{
    [RoutePrefix("api/check")]
    public class checkController : ApiController
    {
        [HttpGet]
        [Route("")]
        public void check()
        {
            var check = new ApplicationDbContext().Database.Exists();
            System.Diagnostics.Debug.WriteLine("Database exists: " + check);
        }
    }
}