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
        public FormView()
        {
            InitializeComponent();

            formDataError.ForeColor = Color.Red;
            emailError.ForeColor = Color.Red;
        }

        public event EventHandler SubmitButtonClick { add { this.submitButton.Click += new EventHandler(value); } remove { this.submitButton.Click -= new EventHandler(value); } }
     
        public FormData GetFormData()
        {
            return new FormData(firstNameTextBox.Text, lastNameTextBox.Text, emailTextBox.Text);
        }

        public string GetEmail()
        {
            return emailTextBox.Text;
        }

        public void DisplayValidationResult(string errorMessage)
        {
            formDataError.Text = errorMessage;
        }


        public void DisplayEmailError(string text)
        {
            emailError.Text = text;
        }

        public void ClearValidationError()
        {
            formDataError.Text = string.Empty;
            emailError.Text = string.Empty;
        }
    }
}
