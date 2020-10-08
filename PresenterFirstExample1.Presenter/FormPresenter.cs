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
            view.ViewLoad += OnViewLoad;
            this.view.ClearValidationError();
        }
        private void OnViewLoad(object obj, EventArgs e)
        {
            view.SetDefaultData(model.GetDefaultFormData());
        }

        private void OnSubmitButtonClick(object obj, EventArgs e)
        {
            FormData formData = view.FormData;
            EmailData emailData = view.EmailData;
            FormValidationResult validationResult = model.ValidateFormData(formData, emailData);

            view.ClearValidationError();

            if (validationResult.IsValid == false)
            {
                view.DisplayValidationResult(validationResult.Messages); // Determines the message and shows it on the View
                return;
            }

            Pdf pdf = model.GeneratePdf(formData);

            EmailSendingResult sendingResult = model.EmailFile(emailData, pdf);

            view.DisplayEmailError(sendingResult.Message);
        }
    }
}
