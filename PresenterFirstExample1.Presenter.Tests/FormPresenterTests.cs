using NUnit.Framework;
using PresenterFirstExample1.Model;
using PresenterFirstExample1.Presenter;
using System;

namespace PresenterFirstExample1.Presenter.Tests
{
    [TestFixture]
    public class FormPresenterTests
    {
        public class FormViewMock : IFormView
        {
            private string emailValidationError;
            private string emailAddress;

            public FormData FormData() { return new FormData(); }
            public string Email() { return emailAddress; }
            public void DisplayValidationResult(ValidationResult result) { }
            public event EventHandler SubmitButtonClick;
            public void ShowEmailError(string text) { emailValidationError = text; }

            public void SetEmailAdressForTest(string text) { emailAddress = text; }
            public void SimulateSubmitButtonClick() { SubmitButtonClick.Invoke(this, null); }
            public string GetEmailValidatorErrorForTest() { return emailValidationError; }
        }

        public class FormModelMock : IFormModel
        {
            public ValidationResult ValidateFormData(FormData formData) { return new ValidationResult(); }
            public Pdf GeneratePdf(FormData formData) { return new Pdf(); }
            public bool ValidateEmail(string email) { return false; }
            public void EmailFile(string email, Pdf pdf) {; }
        }

        [Test]
        public void View_show_error_if_user_input_incorrect_email()
        {
            FormViewMock formViewMock = new FormViewMock();
            FormModelMock formModelMock = new FormModelMock();

            FormPresenter presenter = new FormPresenter(formViewMock, formModelMock);

            formViewMock.SetEmailAdressForTest("test");
            formViewMock.SimulateSubmitButtonClick();
            Assert.AreEqual("email address is incorrect!", formViewMock.GetEmailValidatorErrorForTest());
        }
    }
}
