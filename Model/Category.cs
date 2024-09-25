using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson2Dapper.Model
{
    internal class Category
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<Book> Books { get; set; } = [];
    }
}
