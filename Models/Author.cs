using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto10_06
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }
        public override string ToString() {
            return $"{Id} - {Name} - {Nationality}";
        }
    }
}
