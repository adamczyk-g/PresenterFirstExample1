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
        private readonly INameValidator nameValidator;

        public FormModel(IEmailValidator emailValidator, INameValidator nameValidator)
        {
            this.emailValidator = emailValidator;
            this.nameValidator = nameValidator;
        }

        public ValidationResult ValidateFormData(FormData formData)
        {
            if (!nameValidator.isValid(formData.FirstName) || !nameValidator.isValid(formData.LastName))
                return new ValidationResult("data form is incorrect!", false);

            return new ValidationResult("data is correct", true);
        }

        public Pdf GeneratePdf(FormData formData) { return new Pdf(); }
        public bool ValidateEmail(string email) { return emailValidator.IsValid(email); }
        public void EmailFile(string email, Pdf pdf) { }
    }
}
