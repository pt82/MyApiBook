using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApiBook.Models
{
    public class User
    {
        public int Id { get; set; }
        public string login { get; set; }
        public string email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }

      //  public List<Contact> Contacts { get; set; }
     //   public List<Event> Events { get; set; }
    }
}
