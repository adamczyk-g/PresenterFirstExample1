using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresenterFirstExample1.Model.Tests
{
    [TestFixture]
    public class FormValidatorTests
    {
        [Test]
        public void Form_validator_with_proper_data_return_no_errors()
        {
            //arrange
            FormData formData = new FormData("ProperFirstName", "ProperLastName", "proper comment");
            EmailData emailData = new EmailData("gadamczyk@gmail.com", "smtp.host.name");
            IEnumerable<string> expected = new List<string>() { };
            EmailValidator emailValidator = new EmailValidator();
            IFormValidator sut = new FormValidator(emailValidator);

            //act
            Notification notification = sut.Validate(formData, emailData);

            //assert
            CollectionAssert.AreEquivalent(expected, notification.Messages);
            Assert.AreEqual(false, notification.HasErrors);
        }

        [Test]
        public void Form_validator_with_incorrect_first_name_return_errors()
        {
            //arrange
            FormData formData = new FormData("incorrectFirstName", "ProperLastName", "proper comment");
            EmailData emailData = new EmailData("proper@email.address", "smtp.host.name");
            IEnumerable<string> expected = new List<string>() {
            "First name is invalid!"
            };
            EmailValidator emailValidator = new EmailValidator();
            IFormValidator sut = new FormValidator(emailValidator);

            //act
            Notification notification = sut.Validate(formData, emailData);

            //assert
            CollectionAssert.AreEquivalent(expected, notification.Messages);
            Assert.AreEqual(true, notification.HasErrors);
        }

        [Test]
        public void Form_validator_with_incorrect_last_name_return_errors()
        {
            //arrange
            FormData formData = new FormData("ProperFirstName", "inncorectLastName", "proper comment");
            EmailData emailData = new EmailData("proper@email.address", "smtp.host.name");
            IEnumerable<string> expected = new List<string>() {
            "Last name is invalid!"
            };
            EmailValidator emailValidator = new EmailValidator();
            IFormValidator sut = new FormValidator(emailValidator);

            //act
            Notification notification = sut.Validate(formData, emailData);

            //assert
            CollectionAssert.AreEquivalent(expected, notification.Messages);
            Assert.AreEqual(true, notification.HasErrors);
        }


        [Test]
        public void Form_validator_with_incorrect_email_address_return_errors()
        {
            //arrange
            FormData formData = new FormData("ProperFirstName", "ProperLastName", "proper comment");
            EmailData emailData = new EmailData("emailAddressWithoutAt.com", "smtp.host.name");
            IEnumerable<string> expected = new List<string>() {
            "Email address is invalid!"
            };
            EmailValidator emailValidator = new EmailValidator();
            IFormValidator sut = new FormValidator(emailValidator);

            //act
            Notification notification = sut.Validate(formData, emailData);

            //assert
            CollectionAssert.AreEquivalent(expected, notification.Messages);
            Assert.AreEqual(true, notification.HasErrors);
        }

        [Test]
        public void Form_validator_with_incorrect_email_address_return_errors1()
        {
            //arrange
            FormData formData = new FormData("ProperFirstName", "ProperLastName", "proper comment");
            EmailData emailData = new EmailData("email@AddressWithoutDoamin", "smtp.host.name");
            IEnumerable<string> expected = new List<string>() {
            "Email address is invalid!"
            };
            EmailValidator emailValidator = new EmailValidator();
            IFormValidator sut = new FormValidator(emailValidator);

            //act
            Notification notification = sut.Validate(formData, emailData);

            //assert
            CollectionAssert.AreEquivalent(expected, notification.Messages);
            Assert.AreEqual(true, notification.HasErrors);
        }
    }
}
