using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApiBook.Models
{
    public class Contact
    {
         public int Id { get; set; }
         public string Fist_Name { get; set; }
         public string Last_Name { get; set; }
         public string Mobile_Phone { get; set; }

        public int SexId { get; set; }      // внешний ключ
        public Sex Sex { get; set; }
        public int UserId { get; set; }      // внешний ключ
        public User User { get; set; }
    }
}
