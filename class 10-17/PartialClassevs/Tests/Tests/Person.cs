using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public sealed class Person
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
