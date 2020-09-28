using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresenterFirstExample1.Model;

namespace PresenterFirstExample1.Presenter
{
    public class FormPresenter
    {
        private readonly IFormView view;
        private readonly IFormModel model;

        public FormPresenter(IFormView view, IFormModel model)
        {
            this.view = view;
            this.model = model;

            this.view.SubmitButtonClick += OnSubmitButtonClick;
            this.view.ClearValidationError();
        }

        private void OnSubmitButtonClick(object obj, EventArgs e)
        {
            OnSubmit();
        }

        void OnSubmit()
        {            
            FormData formData = view.FormData();
            ValidationResult validationResult = model.ValidateFormData(formData);

            view.ClearValidationError();

            if (validationResult.IsValid == false)
            {
                ShowValidationError(validationResult); // Determines the message and shows it on the View
                return;
            }

            Pdf pdf = model.GeneratePdf(formData);

            string email = view.Email();

            if (!model.ValidateEmail(email))
            {
                ShowEmailError(email); // Determines the message and shows it on the view
                return;
            }

            model.EmailFile(email, pdf);
        }

        private void ShowValidationError(ValidationResult result)
        {
            view.DisplayValidationResult("data form incorrect!");
        }

        private void ShowEmailError(string email)
        {
            view.DisplayEmailError("email address is incorrect!");
        }
    }
}
