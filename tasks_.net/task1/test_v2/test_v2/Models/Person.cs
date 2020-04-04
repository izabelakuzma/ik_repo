using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_v2
{
    /// <summary>
    /// taka notacja mapowania mogłaby zostać użyta w przypadku niepowtarzających się adresów email, w przeciwnym wypadku będą nullowe rekordy w klasie PersonWithEmail,
    /// wg mnie powinno być pole Id int w klasie EmailAddress
    /// </summary>
    public class Person
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<EmailAddress> Emails { get; set; } 
    }
}
