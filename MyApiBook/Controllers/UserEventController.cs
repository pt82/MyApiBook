using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApiBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApiBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserEventController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public UserEventController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IEnumerable<Event> GetContact(int id)
        {
            // var contact = await _context.Contacts.FindAsync(id);
            var ev = (from i in _context.Events 
                      where i.UserId == id 
                      select i);

            return ev.ToList();
        }

    }
}
