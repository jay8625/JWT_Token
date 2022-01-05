using Authentification;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JWT.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NamesController : ControllerBase
    {
        private readonly IAuthenticationManager authenticationManager;

        public NamesController(IAuthenticationManager authenticationManager)
        {
            this.authenticationManager = authenticationManager;
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("Authenticate")]
        public ActionResult Authenticate([FromBody] User user)
        {
            var token = authenticationManager.Authenticate(user.Name, user.Password);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }
        // GET: api/<NamesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<NamesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<NamesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<NamesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<NamesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
