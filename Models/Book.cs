using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto10_06
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Author { get; set; }

        public string PrintToExportDelimited() {
            return $"{Id};{Name}";
        }

        public override string ToString() {
            return $"{Id} - {Name}";
        }
    }
}