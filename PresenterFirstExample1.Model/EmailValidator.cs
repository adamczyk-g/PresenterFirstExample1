using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace PresenterFirstExample1.Model
{
    class SystemNetEmailValidator : IEmailValidator
    {
        public SystemNetEmailValidator()
        {

        }

        public bool IsValid(string email)
        {
            try
            {
                var mail = new MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
