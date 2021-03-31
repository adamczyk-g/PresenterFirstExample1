using System.Text.RegularExpressions;

namespace PresenterFirstExample1.Model
{
    public class SimpleEmailValidator: EmailValidator
    {
        public bool Validate(string email)
        {
            return Regex.IsMatch(email, @"^.{1,64}@(?:[a-zA-Z0-9-]+\.)[a-zA-Z]{2,63}$");
        }
    }
}