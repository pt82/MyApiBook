using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApiBook.Models;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using MyApiBook.Services;
using BC = BCrypt.Net.BCrypt;


namespace MyApiBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly ApplicationContext _context;

        public UsersController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
       

        [HttpGet("{it}")]
        [Route("Event")]
        public IEnumerable<Event> GetEvent(int it)
        {
            // var contact = await _context.Contacts.FindAsync(id);
            var ev = (from i in _context.Events where i.UserId == it select i);

            return ev.ToList();
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
       
        [HttpPost]
        [Route("login")]
       
        public async Task<ActionResult<User>> Login(Login model)
        {
           int count = (from c in _context.Users 
                        where c.email == model.email 
                        select c)
                        .Count();
            if (count == 0)
            {
               return BadRequest(count); 
           }
           else
            {
               
                var usr = _context.Users.SingleOrDefault(x => x.email == model.email);
                bool isValidPassword = BC.Verify(model.Password, usr.Password);

            if (!isValidPassword)
            {

                //var mod = (from i in _context.Users where i.email == model.email select i);
                ModelState.AddModelError("DD", "dddd");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok();
            }

        }

        // POST: api/Users
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            int count = (from i in _context.Users where i.email == user.email select i).Count();
            if (count < 1) {
                
                EmailService emailService = new EmailService();
                await emailService.SendEmailAsync(user.email, "Регистрация пользователя", "Спасибо за регистрацию!");
                user.Password = BC.HashPassword(user.Password);
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
              
                return CreatedAtAction("GetUser", new { id = user.Id }, user);
               // return Ok(user);
            }
            else return BadRequest();

        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
