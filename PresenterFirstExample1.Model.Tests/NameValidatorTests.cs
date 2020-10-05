using NUnit.Framework;
using PresenterFirstExample1.Model;

namespace PresenterFirstExample1.Model.Tests
{
    [TestFixture]
    public class NameValidatorTests
    {
        [Test]
        public void Empty_name_is_not_valid()
        {
            INameValidator sut = new NameValidator(); 
            string name = string.Empty;
            bool expected = false;

            bool actual = sut.isValid(name);

            Assert.AreEqual(expected, actual);   
        }

        [Test]
        public void Name_without_first_capital_letter_is_not_valid()
        {
            INameValidator sut = new NameValidator();
            string name = "nameWithoutFirstCapittalLetter";
            bool expected = false;

            bool actual = sut.isValid(name);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Name_with_non_alphabetic_characters_is_not_valid()
        {            
            INameValidator sut = new NameValidator();
            string name = "FirstName123";
            bool expected = false;

            bool actual = sut.isValid(name);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Name_with_space_is_not_valid()
        {
            INameValidator sut = new NameValidator();
            string name = "First Name";
            bool expected = false;

            bool actual = sut.isValid(name);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Proper_Name_is_valid()
        {
            INameValidator sut = new NameValidator();
            string name = "ProperName";
            bool expected = true;

            bool actual = sut.isValid(name);

            Assert.AreEqual(expected, actual);
        }       
    }
}
