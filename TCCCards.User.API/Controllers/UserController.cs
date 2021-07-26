using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TCCCards.User.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "User1", "User2", "User3" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public bool CheckUser([FromBody] ViewModels.Account.User user)
        {
            if (user != null)
            {
                return true;
            }
            return false;
            //User Result = new User() {Email="test@gmail.com" ,Password = "abc!123" };

            //return Request.CreateResponse(HttpStatusCode.OK, Result);
        }

        //public HttpResponseMessage CheckUser(User user)
        //{
        //    // string Result = "Name: " + employee.Name + " Age: " + employee.Age;
        //    User Result = new User() { Email = "test@gmail.com", Password = "abc!123" };
        //    HttpResponseMessage request = new HttpResponseMessage();
        //    return request.CreateResponse(HttpStatusCode.OK, Result);
        //    //return HttpStatusCode.OK
        //    StatusCodeResult result = new StatusCodeResult(200);
        //    return result;
        //}

    }
}
