using NUnit.Framework;
using PresenterFirstExample1.Model;
using Moq;

namespace PresenterFirstExample1.Model.Tests
{
    [TestFixture]
    public class FormModelTests
    {
        [Test]
        public void Form_model_with_invalid_email_return_email_validation_error()
        {
            bool expected = false;
            var nameValidator = new Mock<INameValidator>();
            var emailValidator = new Mock<IEmailValidator>();
            IFormModel model = new FormModel(emailValidator.Object, nameValidator.Object);
            nameValidator.Setup(mock => mock.isValid(It.IsAny<string>())).Returns(true);
            emailValidator.Setup(mock => mock.IsValid(It.IsAny<string>())).Returns(expected);            

            bool actual = model.ValidateEmail("");
            
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Form_model_with_proper_email_return_no_validation_error()
        {
            bool expected = true;
            var nameValidator = new Mock<INameValidator>();
            var emailValidator = new Mock<IEmailValidator>();
            IFormModel model = new FormModel(emailValidator.Object, nameValidator.Object);
            nameValidator.Setup(mock => mock.isValid(It.IsAny<string>())).Returns(true);
            emailValidator.Setup(mock => mock.IsValid(It.IsAny<string>())).Returns(expected);
            
            bool actual = model.ValidateEmail("");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Form_model_with_invalid_name_return_validation_error()
        {
            bool expected = false;
            var nameValidator = new Mock<INameValidator>();
            var emailValidator = new Mock<IEmailValidator>();
            IFormModel model = new FormModel(emailValidator.Object, nameValidator.Object);
            nameValidator.Setup(mock => mock.isValid(It.IsAny<string>())).Returns(expected);
            emailValidator.Setup(mock => mock.IsValid(It.IsAny<string>())).Returns(true);

            bool actual = model.ValidateFormData(new FormData("","","","")).IsValid;

            Assert.AreEqual(expected, actual);
        }
    }
}
