namespace PresenterFirstExample1.Model
{
    public interface IFormModel
    {
        FormValidationResult ValidateFormData(FormData formData, EmailData emailData);
        Pdf GeneratePdf(FormData formData);
        EmailSendingResult EmailFile(EmailData email, Pdf pdf);
        FormData GetDefaultFormData();
    }
}
