using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Net.Mail;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PdfSharp.Drawing.Layout;

namespace PresenterFirstExample1.Model
{
    public class FormModel : IFormModel
    {
        private readonly IEmailValidator emailValidator;
        private readonly INameValidator nameValidator;

        public FormModel(IEmailValidator emailValidator, INameValidator nameValidator)
        {
            this.emailValidator = emailValidator;
            this.nameValidator = nameValidator;
        }

        public ValidationResult ValidateFormData(FormData formData)
        {
            if (!nameValidator.isValid(formData.FirstName) || !nameValidator.isValid(formData.LastName))
                return new ValidationResult("data form is incorrect!", false);

            return new ValidationResult("data is correct", true);
        }
        
        public bool ValidateEmail(string email) { return emailValidator.IsValid(email); }

        public Pdf GeneratePdf(FormData formData)
        {
            /*
            PdfDocument pdfDoc = new PdfDocument();
            PdfPage pdfPage = pdfDoc.AddPage();
            XGraphics graph = XGraphics.FromPdfPage(pdfPage);
            XFont font = new XFont("Verdana", 12, XFontStyle.Bold);
            graph.DrawString("This is my first PDF document" + Environment.NewLine + "ds fdsf dsf sdfsdfds", font, XBrushes.Black, new XRect(0, 0, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            */

            string text = "first name: " + formData.FirstName + Environment.NewLine + 
                "last name: " + formData.LastName + Environment.NewLine +
                "email address: " + formData.Email + Environment.NewLine +
                "smtp server: " + formData.SmtpServer;

            PdfDocument document = new PdfDocument();

            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Times New Roman", 10, XFontStyle.Bold);
            XTextFormatter tf = new XTextFormatter(gfx);

            XRect rect = new XRect(40, 100, 250, 220);
            gfx.DrawRectangle(XBrushes.SeaShell, rect);
            tf.DrawString(text, font, XBrushes.Black, rect, XStringFormats.TopLeft);

            document.Save("myDocument.pdf");

            return new Pdf("myDocument.pdf");
        }

        public void EmailFile(string smtpHost, string email, Pdf pdf)
        {
            string emailFrom = "notify@mvptest.com.pl";
            string displayName = "PresenterFirst example 1";
            
            SmtpClient client = new SmtpClient(smtpHost);
            MailAddress from = new MailAddress(emailFrom, displayName, System.Text.Encoding.UTF8);
            MailAddress to = new MailAddress(email);
            MailMessage message = new MailMessage(from, to);
            message.Body = "This is a test email message sent by an application.";
            message.Attachments.Add(new Attachment(pdf.PathToFile));
            client.Send(message);            
            message.Dispose();
        }
    }
}
