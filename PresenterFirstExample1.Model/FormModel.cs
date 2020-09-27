using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresenterFirstExample1.Model
{
    public class FormModel : IFormModel
    {
        public FormModel() { }
        public ValidationResult ValidateFormData(FormData formData) { return new ValidationResult(); }
        public Pdf GeneratePdf(FormData formData) { return new Pdf(); }
        public bool ValidateEmail(string email) { return false; }
        public void EmailFile(string email, Pdf pdf) { }
    }
}
