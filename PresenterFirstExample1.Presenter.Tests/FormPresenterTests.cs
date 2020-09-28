using NUnit.Framework;
using PresenterFirstExample1.Model;
using PresenterFirstExample1.Presenter;
using System;

using Moq;

namespace PresenterFirstExample1.Presenter.Tests
{
    [TestFixture]
    public class FormPresenterTests
    {
        public class FormViewMock : IFormView
        {
            private string formDataValidationError;
            private string emailValidationError;
            private string firstName;
            private string lastName;
            private string emailAddress;

            public FormData FormData() { return new FormData("","",""); }
            public string Email() { return emailAddress; }
            public void DisplayValidationResult(string errorMessage) { formDataValidationError = errorMessage; }
            public event EventHandler SubmitButtonClick;
            public void DisplayEmailError(string text) { emailValidationError = text; }
            public void ClearValidationError() { }

            public void SetFirstNameForTest(string text) { firstName = text; }
            public void SetlastNameForTest(string text) { lastName = text; }
            public void SetEmailAdressForTest(string text) { emailAddress = text; }
            public void SimulateSubmitButtonClick() { SubmitButtonClick.Invoke(this, null); }
            public string GetEmailValidatorErrorForTest() { return emailValidationError; }
            public string GetFormDataErrorForTest() { return formDataValidationError; }            
        }

        public class FormModelMock : IFormModel
        {
            public ValidationResult ValidateFormData(FormData formData) { return new ValidationResult("", true); }
            public Pdf GeneratePdf(FormData formData) { return new Pdf(); }
            public bool ValidateEmail(string email) { return false; }
            public void EmailFile(string email, Pdf pdf) { }            
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

        [Test]
        public void View_show_error_if_user_input_incorrect_first_name()
        {
            var viewMock = new Mock<IFormView>();
            var modelMock = new Mock<IFormModel>();

            FormPresenter sut = new FormPresenter((IFormView)viewMock, (IFormModel)modelMock);

            viewMock.Setup(x => x.FormData()).Returns(new FormData("","",""));


            /*
                var Service = new Mock<IService>();
            Service.Setup(x => x.method("argument")).Returns(YourReturnObject)
            Controller _controller = new Controller(Service.Object);*/
            /*
            formViewMock.SetFirstNameForTest("incorrectFirstName");
            formViewMock.SimulateSubmitButtonClick();

            string actual = formViewMock.GetFormDataErrorForTest();
            string expected = "data form is incorrect!";
            Assert.AreEqual(expected, actual);*/
        }

    }
}
