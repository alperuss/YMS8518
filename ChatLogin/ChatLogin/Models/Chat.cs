using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatLogin.Models
{
    public class Chat
    {
        public int Id { get; set; }
        public string Username { get; set; }

        public string Message { get; set; }
        
        public DateTime Date { get; set; }
    }
}
