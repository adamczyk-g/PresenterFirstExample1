using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace PresenterFirstExample1.Model
{
    public class NameValidator: INameValidator
    {
        public NameValidator() { }

        public bool isValid(string name)
        {
            return Regex.Match(name, "^[A-Z][a-zA-Z]+$").Success;
        }
    }
}
