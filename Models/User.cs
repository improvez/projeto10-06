using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto10_06
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public override string ToString() {
            return $"{Id} - {Username} - {Email}";
        }
    }
}
