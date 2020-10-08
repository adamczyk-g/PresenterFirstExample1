namespace PresenterFirstExample1.Model
{
    public interface IFormValidator
    {
        FormValidationResult Validate(FormData formData, EmailData emailData);
    }
}
