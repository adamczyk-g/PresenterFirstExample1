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
        private readonly IEmailValidator emailValidator;

        public FormModel(IEmailValidator emailValidator)
        {
            this.emailValidator = emailValidator;
        }

        public ValidationResult ValidateFormData(FormData formData)
        {
            if (!DataIsValid(formData.FirstName) || !DataIsValid(formData.LastName))
                return new ValidationResult("data form is incorrect!", false);

            return new ValidationResult("data is correct", true);
        }

        public Pdf GeneratePdf(FormData formData) { return new Pdf(); }
        public bool ValidateEmail(string email) { return emailValidator.IsValid(email); }
        public void EmailFile(string email, Pdf pdf) { }

        private bool DataIsValid(string data)
        {
            return Regex.Match(data, "^[A-Z][a-zA-Z]+$").Success;
        }
    }
}
