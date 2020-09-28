using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresenterFirstExample1.Model
{
    public class FormData
    {
        private readonly string firstName;
        private readonly string lastName;
        private readonly string email;

        public FormData(string firstName, string lastName, string email)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
        }

        public string FirstName => firstName;
        public string LastName => lastName;
        public string Email => email;
    }
}
