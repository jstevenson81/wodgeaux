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
                var workout = context.Workouts.Add(new Workout {WorkoutDate = DateTime.Now});
                context.UserMovements.Add(new UserMovement {WorkoutId = workout.Id});
                await context.SaveChangesAsync();
                return Ok();
            }
        }
    }
}
