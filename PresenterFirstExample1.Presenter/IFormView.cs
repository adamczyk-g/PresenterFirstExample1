using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresenterFirstExample1.Model;

namespace PresenterFirstExample1.Presenter
{
    public interface IFormView
    {
        FormData FormData();
        string Email();
        void DisplayValidationResult(ValidationResult result);
        event EventHandler SubmitButtonClick;
        void ShowEmailError(string text);
    }
}
