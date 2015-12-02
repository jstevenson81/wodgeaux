using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using wodgeaux.web.Models;

namespace wodgeaux.web.Controllers
{
    [Route("api/workout")]
    public class WorkoutController : ApiController
    {
        [HttpPut]
        public async Task<IHttpActionResult> Put()
        {
            using (var context = new WodgeauxContext())
            {
                return null;
            }
        }
    }
}
