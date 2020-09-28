using NUnit.Framework;
using PresenterFirstExample1.Model;

namespace PresenterFirstExample1.Model.Tests
{
    [TestFixture]
    public class FormModelTests
    {
        [Test]
        public void Empty_first_name_is_not_valid()
        {
            FormModel sut = new FormModel();
            FormData formData = new FormData(string.Empty, "LastName", string.Empty);

            bool expected = sut.ValidateFormData(formData).IsValid;

            Assert.AreEqual(false, expected);
        }

        [Test]
        public void Empty_last_name_is_not_valid()
        {
            FormModel sut = new FormModel();
            FormData formData = new FormData("FirstName", string.Empty, string.Empty);

            bool expected = sut.ValidateFormData(formData).IsValid;

            Assert.AreEqual(false, expected);
        }

        [Test]
        public void first_name_without_first_capital_letter_is_not_valid()
        {
            FormModel sut = new FormModel();
            FormData formData = new FormData("firstNameWithoutFirstCapittalLetter", "ProperLastName", string.Empty);

            bool expected = sut.ValidateFormData(formData).IsValid;

            Assert.AreEqual(false, expected);
        }

        [Test]
        public void last_name_without_first_capital_letter_is_not_valid()
        {
            FormModel sut = new FormModel();
            FormData formData = new FormData("ProperFirstName", "lastNameWithoutFirstCapittalLetter", string.Empty);

            bool expected = sut.ValidateFormData(formData).IsValid;

            Assert.AreEqual(false, expected);
        }

        [Test]
        public void first_name_with_non_alphabetic_characters_is_not_valid()
        {
            FormModel sut = new FormModel();
            FormData formData = new FormData("FirstName123", "ProperLastName", string.Empty);

            bool expected = sut.ValidateFormData(formData).IsValid;

            Assert.AreEqual(false, expected);
        }

        [Test]
        public void last_name_with_non_alphabetic_characters_is_not_valid()
        {
            FormModel sut = new FormModel();
            FormData formData = new FormData("ProperFirstName", "LastName123", string.Empty);

            bool expected = sut.ValidateFormData(formData).IsValid;

            Assert.AreEqual(false, expected);
        }

        [Test]
        public void Proper_first_and_last_name_is_valid()
        {
            FormModel sut = new FormModel();
            FormData formData = new FormData("ProperFirstName", "ProperLastName", string.Empty);

            bool expected = sut.ValidateFormData(formData).IsValid;

            Assert.AreEqual(true, expected);
        }

        [Test]
        public void email_without_at_character_is_not_valid()
        {
            FormModel sut = new FormModel();
            string email = "blablagmail.com";
            bool expected = sut.ValidateEmail(email);

            Assert.AreEqual(false, expected);
        }
    }
}
