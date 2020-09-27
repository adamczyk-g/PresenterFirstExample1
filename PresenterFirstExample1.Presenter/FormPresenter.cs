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
        }

        private void OnSubmitButtonClick(object obj, EventArgs e)
        {
            OnSubmit();
        }

        void OnSubmit()
        {
            FormData formData = view.FormData();
            ValidationResult validationResult = model.ValidateFormData(formData);

            if (validationResult != ValidationResult.Valid)
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

        }

        private void ShowEmailError(string email)
        {
            view.ShowEmailError("email address is incorrect!");
        }
    }
}
