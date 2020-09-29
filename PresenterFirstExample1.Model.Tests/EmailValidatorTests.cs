using NUnit.Framework;
using PresenterFirstExample1.Model;

namespace PresenterFirstExample1.Model.Tests
{
    [TestFixture]
    public class EmailValidatorTests
    {        

        [Test]
        public void email_without_at_character_is_not_valid()
        {
            IEmailValidator sut = new SystemNetEmailValidator();
            string email = "blablagmail.com";            
            bool expected = false;

            bool actual = sut.IsValid(email);

            Assert.AreEqual(expected, actual);
        }

        public void Proper_email_is_valid()
        {
            IEmailValidator sut = new SystemNetEmailValidator();
            string email = "blabla@gmail.com";
            bool expected = true;

            bool actual = sut.IsValid(email);

            Assert.AreEqual(expected, actual);
        }
    }
}
