using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_v2
{
    class Program
    {
        static void Main(string[] args)
        {

            
            Person person1 = new Person();
            person1.Id = "1";
            person1.Name = "name 1";


            EmailAddress emailAddress = new EmailAddress();
            emailAddress.Email = "email1@wp.pl";
            emailAddress.EmailType = "1";

            EmailAddress emailAddress2 = new EmailAddress();
            emailAddress2.Email = "email2@wp.pl";
            emailAddress2.EmailType = "1";
            IEnumerable<EmailAddress> emails = new List<EmailAddress> { emailAddress , emailAddress2};
            person1.Emails = emails;

            IEnumerable<Person> people = new List<Person> { person1};


            IEnumerable<PersonWithEmail>  personWithEmail = PersonController.Flatten(people);
            foreach (var person in personWithEmail)
            {
                string name = person.SanitizedNameWithId;
                string email = person.FormattedEmail;
            }

        }
    }
}
