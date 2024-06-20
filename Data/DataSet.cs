using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto10_06
{
    public class DataSet
    {
        public static List<Book> Books { get; set; } = new List<Book>();
        public static List<Author> Authors { get; set; } = new List<Author>();
        public static List<User> Users { get; set; } = new List<User>();
    }
}
