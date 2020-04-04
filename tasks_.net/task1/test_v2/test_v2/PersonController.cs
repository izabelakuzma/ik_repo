using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace test_v2
{
    public class PersonController
    {
        public static IEnumerable<PersonWithEmail> Flatten(IEnumerable<Person> people)
        {
            List<PersonWithEmail> personsWithEmail = new List<PersonWithEmail>(); 

            foreach (var person in people)
            {
                foreach (var email in person.Emails)
                {
                    
                    Regex ASCIILettersOnly = new Regex(@"^[\P{L}A-Za-z]*$");
                    PersonWithEmail personWithEmail = new PersonWithEmail();
                    if (person.Name.All(n => char.IsLetterOrDigit(n) || char.IsWhiteSpace(n)))
                    {
                        if (ASCIILettersOnly.IsMatch(person.Name))
                        {
                            personWithEmail.SanitizedNameWithId = person.Name;
                        }
                           
                    }
                    personWithEmail.FormattedEmail = IsValidEmail(email.Email.ToString()) ? personWithEmail.FormattedEmail = email.Email : null;
                   
                    personsWithEmail.Add(personWithEmail);
                   
                }

            }

            return personsWithEmail;
           
        }
        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
