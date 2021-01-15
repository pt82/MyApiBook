using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApiBook.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SmallDesc { get; set; }
        public string FullDesc { get; set; }
        public bool Active { get; set; }
        public DateTime Date { get; set; }

        public int UserId { get; set; }      // внешний ключ
        public User User { get; set; }
    }
}
