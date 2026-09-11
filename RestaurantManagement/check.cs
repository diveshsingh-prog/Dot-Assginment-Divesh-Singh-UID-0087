using RestaurantManagement.Data;
using System.Web.Http;


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

