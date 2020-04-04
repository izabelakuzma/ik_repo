using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test_v3.Models;

namespace test_v3
{
    public class PersonController
    {
        internal static IEnumerable<(Account, Person)> FindPersonAndGroupByEmail(IEnumerable<Group> groups, IEnumerable<Account> accounts, IEnumerable<string> emails)
        {
            List<Group> group_new = groups.ToList();
            List<Account> account_new = accounts.ToList();


            return from gn in group_new
                        
                   from sq in
                       (from pe in gn.People
                        from pema in pe.Emails
                        join an in account_new on pema.Email equals an.EmailAddress.Email
                        join em in emails on pema.Email equals em
                        select new { an, pe })
                   select
                       (( sq.an, sq.pe)
                       ) ;
                          

        }
    }
}
