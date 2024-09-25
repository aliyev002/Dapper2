using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson2Dapper.Model.DTOs
{
    internal record BookDto
    {
        public string Name { get; }
        public int Pages { get; }
        public int Quantity { get; }
    }
}
