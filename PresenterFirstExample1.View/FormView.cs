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
        }

        public FormData FormData() { return new FormData(); }
        public string Email() { return emailAddressTextBox.Text; }
        public void DisplayValidationResult(ValidationResult result) { throw new NotImplementedException(); }
        public event EventHandler SubmitButtonClick { add { this.submitButton.Click += new EventHandler(value); } remove { this.submitButton.Click -= new EventHandler(value); } }
        public void ShowEmailError(string text) { emailValidationError.Text = text; }
    }
}
