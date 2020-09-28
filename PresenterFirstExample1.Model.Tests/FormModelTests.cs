using NUnit.Framework;
using PresenterFirstExample1.Model;

namespace PresenterFirstExample1.Model.Tests
{

    /*
     * public ValidationResult ValidateFormData(FormData formData)
        {
            if (!DataIsValid(formData.FirstName) && DataIsValid(formData.LastName))
                return new ValidationResult("data form is incorrect!", false);

            return new ValidationResult("data is correct", true);
        }

        public Pdf GeneratePdf(FormData formData) { return new Pdf(); }
        public bool ValidateEmail(string email) { return false; }
        public void EmailFile(string email, Pdf pdf) { }
    */


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
            FormData formData = new FormData("firstNameWithoutFirstCapittalLetter", "ProperLastname", string.Empty);

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
    }
}
