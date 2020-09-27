using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresenterFirstExample1.Model
{
    public interface IFormModel
    {
        ValidationResult ValidateFormData(FormData formData);
        Pdf GeneratePdf(FormData formData);
        bool ValidateEmail(string email);
        void EmailFile(string email, Pdf pdf);
    }
}
