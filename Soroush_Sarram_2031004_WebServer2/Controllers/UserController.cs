using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Soroush_Sarram_2031004_WebServer2.Data;
using Soroush_Sarram_2031004_WebServer2.Models;

namespace Soroush_Sarram_2031004_WebServer2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult Post(Dictionary<string, string> UserDesc)
        {
            if (UserDesc.Count < 3)
            {
                var User = _context.Users.FirstOrDefault(x => x.Email == UserDesc["Email"]);

                if (User.Password != UserDesc["Password"] || User == null)
                {
                    return NotFound("Oups! The selected user has not been found");
                }

                var session = new Session() { Email = UserDesc["Email"] };

                _context.Sessions.Add(session);

                try
                {
                    _context.SaveChanges();
                }
                catch (Exception exception)
                {
                    return BadRequest(exception.Message);
                }
                return Ok(session.Token);
            }
            else
            {
                var Usercontroller = _context.Users.FirstOrDefault(x => x.Email == UserDesc["Email"]);

                if (User != null)
                {
                    return BadRequest("Oups! The selected user has been found");
                }

                Usercontroller = new Models.User();
              
                Usercontroller.Email = UserDesc["Email"];

                Usercontroller.Name = UserDesc["Name"];

                Usercontroller.Password = UserDesc["Password"];

                _context.Users.Add(Usercontroller);

                try
                {
                    _context.SaveChanges();
                }
                catch (Exception exception)
                {
                    return BadRequest(exception.Message);
                }
                return Ok(User);
            }
        }
    }
}
