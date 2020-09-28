using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace PresenterFirstExample1.Model
{
    public class FormModel : IFormModel
    {
        public FormModel() { }

        public ValidationResult ValidateFormData(FormData formData)
        {
            if (!DataIsValid(formData.FirstName) || !DataIsValid(formData.LastName))
                return new ValidationResult("data form is incorrect!", false);

            return new ValidationResult("data is correct", true);
        }

        public Pdf GeneratePdf(FormData formData) { return new Pdf(); }
        public bool ValidateEmail(string email) { return false; }
        public void EmailFile(string email, Pdf pdf) { }

        private bool DataIsValid(string data)
        {
            return Regex.Match(data, "^[A-Z][a-zA-Z]+$").Success;
        }
    }
}
