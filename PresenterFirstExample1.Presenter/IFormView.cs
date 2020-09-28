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
        FormData GetFormData();
        string GetEmail();
        void DisplayValidationResult(string errorMessage);
        event EventHandler SubmitButtonClick;
        void DisplayEmailError(string text);
        void ClearValidationError();
    }
}
