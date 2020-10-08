﻿using System.Text.RegularExpressions;

namespace PresenterFirstExample1.Model
{
    public class FormValidator: IFormValidator
    {
        public FormValidationResult Validate(FormData formData, EmailData emailData)
        {
            FormValidationResult result = new FormValidationResult();

            string message = string.Empty;

            if (!FirstNameValidator(formData.FirstName)) result.AddMessage("First name is invalid!");
            if (!LastNameValidator(formData.LastName)) result.AddMessage("Last name is invalid!");
            if (!CommentsValidator(formData.Comments)) result.AddMessage("Comments are invalid!");
            if (!EmailValidator(emailData.ToAddress)) result.AddMessage("Email address is invalid!");
            if (!SmtpHostValidator(emailData.SmtpHost)) result.AddMessage("Smtp host is invalid!");

            return result;
        }        

        private bool EmailValidator(string email)
        {
            return Regex.Match(email, @"^[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$").Success;
        }

        bool FirstNameValidator(string firstName)
        {
            return Regex.Match(firstName, "^[A-Z][a-zA-Z]+$").Success;
        }

        bool LastNameValidator(string lastName)
        {
            return Regex.Match(lastName, "^[A-Z][a-zA-Z]+$").Success;
        }

        bool SmtpHostValidator(string smtpHost)
        {
            return Regex.Match(smtpHost, @"^(([a-zA-Z0-9]|[a-zA-Z0-9][a-zA-Z0-9\-]*[a-zA-Z0-9])\.)*([A-Za-z0-9]|[A-Za-z0-9][A-Za-z0-9\-]*[A-Za-z0-9])$").Success;
        }

        bool CommentsValidator(string comments)
        {
            return comments.Length < 255;
        }
    }
}