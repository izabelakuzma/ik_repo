using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test_v3.Models;

namespace test_v3
{
    class Program
    {
        static void Main(string[] args)
        {
            Group group = new Group();
            group.Id = "1";
            group.Label = "label 1";


            Person person1 = new Person();
            person1.Id = "1";
            person1.Name = "name 1";


            Person person2 = new Person();
            person2.Id = "2";
            person2.Name = "name 2";



            IEnumerable<Person> people = new List<Person> { person1 , person2};
            group.People = people;


            EmailAddress emailAddress = new EmailAddress();
            emailAddress.Email = "email@wp.pl";
            emailAddress.EmailType = "1";


            EmailAddress emailAddress1 = new EmailAddress();
            emailAddress1.Email = "email1@wp.pl";
            emailAddress1.EmailType = "1";
           

            EmailAddress emailAddress2 = new EmailAddress();
            emailAddress2.Email = "email2@wp.pl";
            emailAddress2.EmailType = "1";

            EmailAddress emailAddress3 = new EmailAddress();
            emailAddress3.Email = "email3@wp.pl";
            emailAddress3.EmailType = "1";

            IEnumerable<EmailAddress> emails = new List<EmailAddress> { emailAddress, emailAddress2 , emailAddress3};
            person1.Emails = emails;

            IEnumerable<EmailAddress> emails2 = new List<EmailAddress> { emailAddress1 };
            person2.Emails = emails2;


            

            Account account = new Account();
            account.EmailAddress = emailAddress2;

            Account account1 = new Account();
            account1.EmailAddress = emailAddress1;

            Account account2 = new Account();
            account2.EmailAddress = emailAddress;

            Account account3 = new Account();
            account3.EmailAddress = emailAddress3;

            IEnumerable<Account> accounts = new List<Account> { account , account2, account1};


            IEnumerable<string> emails_list = new List<string> { "email@wp.pl", "email2@wp.pl" , "email1@wp.pl" , "email1bad@wp.pl" };

                     

            IEnumerable<Group> groups = new List<Group> { group};


            IEnumerable<(Account, Person)> tuple = Enumerable.Empty<(Account, Person)>();
            tuple  = PersonController.FindPersonAndGroupByEmail(groups, accounts, emails_list);
            foreach (var t in tuple)
            {
                var acc = t.Item1;
                var pers = t.Item2;
            }



        }
    }
}
