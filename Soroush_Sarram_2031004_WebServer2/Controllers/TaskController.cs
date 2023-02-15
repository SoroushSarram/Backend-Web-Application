using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Soroush_Sarram_2031004_WebServer2.Data;

namespace Soroush_Sarram_2031004_WebServer2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public TaskController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpPost]
        public ActionResult Post(Dictionary<string, string> TaskDesc)
        {
            var Token = _context.Sessions.FirstOrDefault(x => x.Token == TaskDesc["Token"]);

            if (Token == null)
            {
                return NotFound("Oups! The token is not valid");
            }

            var UserEmail = Token.Email;

            var AssignedToUser = _context.Users.FirstOrDefault(x => x.UId == TaskDesc["AssignedToUid"]);

            var CreatedByUser = _context.Users.FirstOrDefault(x => x.Email == UserEmail);
         
            if (AssignedToUser == null)
            {
                return NotFound("Oups! The AssignedToUid is not valid");
            }

            var assignedToName = AssignedToUser.Name;

            var Taskcontroller = new Models.Task();

            Taskcontroller.CreatedByUid = CreatedByUser.UId;

            Taskcontroller.AssignedToName = assignedToName;

            Taskcontroller.CreatedByName = CreatedByUser.Name;

            Taskcontroller.Description = TaskDesc["Description"];

            Taskcontroller.AssignedToUid = TaskDesc["AssignedToUid"];

            _context.Tasks.Add(Taskcontroller);

            try
            {
                _context.SaveChanges();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
            return Ok(Taskcontroller);
        }

        [HttpGet("CreatedBy/{token}")]
        public ActionResult<IEnumerable<Models.Task>> CreatedBy(string token)
        {
            var Session = _context.Sessions.FirstOrDefault(x => x.Token == token);
            if (Session == null)
            {
                return NotFound("Oups! The token is not found");
            }

            var User = _context.Users.FirstOrDefault(x => x.Email == Session.Email);

            var Tasks = _context.Tasks.Where(x => x.CreatedByUid == User.UId).ToList();

            if (Tasks.Count == 0 || Tasks == null)
            {
                return NotFound("Oups! The task has not been found");
            }
            return Tasks;
        }

        [HttpGet("AssignedTo/{token}")]
        public ActionResult<IEnumerable<Models.Task>> AssignedTo(string token)
        {
            var Session = _context.Sessions.FirstOrDefault(x => x.Token == token);

            if (Session == null)
            {
                return NotFound("Oups! Token has not been found");
            }
            
            var User = _context.Users.FirstOrDefault(x => x.Email == Session.Email);

            var Tasks = _context.Tasks.Where(x => x.AssignedToUid == User.UId).ToList();

            if (Tasks.Count==0 || Tasks == null)
            {
                return NotFound("Oups! The task has not been found");
            }
            return Tasks;
        }

        [HttpPut("{taskUid}")]
        public ActionResult Put(Dictionary<string, object> updatedTask, string taskUid)
        {
            var Done = updatedTask["Done"].ToString();

            var Token = updatedTask["Token"].ToString();
           
            var Session = _context.Sessions.FirstOrDefault(x => x.Token == Token);
           
            if (Session == null)
            {
                return NotFound("Oups! The token has not been found ");
            }
            
            var Task = _context.Tasks.FirstOrDefault(x => x.TaskUId == taskUid);

            var User = _context.Users.FirstOrDefault(x => x.Email == Session.Email);

            if (Task == null)
            {
                return NotFound("Oups! The task has not been found");
            }

            if (Task.AssignedToUid != User.UId)
            {
                return BadRequest("Oups! You can not delete the task");
            }

            Task.Done = Convert.ToBoolean(Done);

            _context.Tasks.Entry(Task).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }

            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
            return Ok(Task);
}

        [HttpDelete("{taskUid}")]
        public ActionResult Delete(Dictionary<string, string> token, string taskUid)
        {
            var session = _context.Sessions.FirstOrDefault(x => x.Token == token["Token"]);

            if (session == null)
            {
                return NotFound("Oups! The token has not been found");
            }
           
            var task = _context.Tasks.FirstOrDefault(x => x.TaskUId == taskUid);

            var user = _context.Users.FirstOrDefault(x => x.Email == session.Email);

            if (task == null)
            {
                return NotFound("Oups! The task has not been found");
            }
            if (task.CreatedByUid != user.UId)
            {
                return BadRequest("Oups! You cannot delete the task.");
            }

            _context.Tasks.Remove(task);

            try
            {
                _context.SaveChanges();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
            return Ok(task);
        }
    }
}
