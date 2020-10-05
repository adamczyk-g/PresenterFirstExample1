using NUnit.Framework;
using PresenterFirstExample1.Model;
using System;
using Moq;

namespace PresenterFirstExample1.Presenter.Tests
{
    [TestFixture]
    public class FormPresenterTests
    {
        [Test]
        public void View_show_error_if_user_input_incorrect_first_name_or_last_name()
        {
            var viewMock = new Mock<IFormView>();
            var modelMock = new Mock<IFormModel>();
            FormPresenter sut = new FormPresenter(viewMock.Object, modelMock.Object);
            modelMock.Setup(model => model.ValidateFormData(It.IsAny<FormData>())).Returns(new ValidationResult("", false));
            string actual = string.Empty;
            viewMock.Setup(view => view.DisplayValidationResult(It.IsAny<string>())).Callback<string>((param) => { actual = param; });

            viewMock.Raise(view => view.SubmitButtonClick += null, new EventArgs());

            Assert.AreEqual("data form incorrect!", actual);
        }

        [Test]
        public void View_show_error_if_user_input_incorrect_email()
        {
            var viewMock = new Mock<IFormView>();
            var modelMock = new Mock<IFormModel>();
            FormPresenter sut = new FormPresenter(viewMock.Object, modelMock.Object);
            modelMock.Setup(model => model.ValidateFormData(It.IsAny<FormData>())).Returns(new ValidationResult("", true));
            modelMock.Setup(model => model.ValidateEmail(It.IsAny<string>())).Returns(false);
            string actual = string.Empty;
            viewMock.Setup(view => view.DisplayEmailError(It.IsAny<string>())).Callback<string>((param) => { actual = param; });

            viewMock.Raise(view => view.SubmitButtonClick += null, new EventArgs());

            Assert.AreEqual("email address is incorrect!", actual);
        }    
    }
}
