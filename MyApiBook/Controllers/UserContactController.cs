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
    public class UserContactController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public UserContactController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IEnumerable<Contact> GetContact(int id)
        {
            // var contact = await _context.Contacts.FindAsync(id);
            var contact = (from i in _context.Contacts where i.UserId == id 
                           orderby i.Id descending
                           select i);

            return contact.ToList();
        }
    }
}
