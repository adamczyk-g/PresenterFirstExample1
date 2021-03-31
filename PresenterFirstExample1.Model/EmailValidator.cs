using System.Text.RegularExpressions;

namespace PresenterFirstExample1.Model
{
    public class EmailValidator
    {
        public EmailValidator() { }
        public bool Validate(string email)
        {
            return Regex.Match(email, @"^[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$").Success;
        }
    }
}