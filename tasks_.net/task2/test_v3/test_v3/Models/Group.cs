using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_v3.Models
{
    public class Group
    {
        public string Id { get; set; }
        public string Label { get; set; }
        public IEnumerable<Person> People { get; set; } 

    }
}
