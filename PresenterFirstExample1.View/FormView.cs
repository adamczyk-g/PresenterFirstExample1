using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PresenterFirstExample1.Presenter;
using PresenterFirstExample1.Model;

namespace PresenterFirstExample1.View
{
    public partial class FormView : Form, IFormView
    {
        public FormData FormData { get { return new FormData(firstNameTextBox.Text, lastNameTextBox.Text, commentsTextBox.Text); } }
        public EmailData EmailData { get { return new EmailData( emailTextBox.Text, smtpTextBox.Text); } }

        public event EventHandler SubmitButtonClick;

        public FormView()
        {
            InitializeComponent();
            this.submitButton.Click += OnSubmitButtonClick;
        }

        private void OnSubmitButtonClick(object sender, EventArgs e)
        {
            SubmitButtonClick.Invoke(sender, EventArgs.Empty);
        }

        public void DisplayValidationResult(IEnumerable<string> errorMessage)
        {
            validationErrors.DataSource = errorMessage;
        }

        public void DisplayEmailError(string error)
        {
            sendingErrors.Text = error;
        }

        public void ClearValidationError()
        {
            validationErrors.DataSource = new List<string>();
            sendingErrors.Text = string.Empty;
        }       

        private void FormView_Load(object sender, EventArgs e)
        {
            firstNameTextBox.Text = "John";
            lastNameTextBox.Text = "Smith";
            commentsTextBox.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.";
            emailTextBox.Text = "gadamczyk@mops.katowice.pl";
            smtpTextBox.Text = "mail.mops.katowice.pl";
        }
    }
}
