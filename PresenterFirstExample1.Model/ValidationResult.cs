using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresenterFirstExample1.Model
{
    public class ValidationResult
    {
        private readonly string message;
        private readonly bool valid;

        public ValidationResult(string message, bool valid)
        {
            this.message = message;
            this.valid = valid;
        }


        public string ErrorMessage => message;
        public bool IsValid => valid;

    };
}
