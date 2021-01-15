using Microsoft.AspNetCore.Mvc;
using MyApiBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyApiBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorizeController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public AutorizeController(ApplicationContext context)
        {
            _context = context;
        }
        // GET: api/<AutorizeController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AutorizeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AutorizeController>
        [HttpPost]
        public async Task<ActionResult<User>> Login(Login model)
        {
           var usr = _context.Users.SingleOrDefault(x => x.email == model.email);
           bool isValidPassword = BC.Verify(model.Password, usr.Password);
            
           if (isValidPassword)
          {
                //var mod = (from i in _context.Users where i.email == model.email select i);
              return Ok(usr);
           }
            return null;
        }

        // PUT api/<AutorizeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AutorizeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
