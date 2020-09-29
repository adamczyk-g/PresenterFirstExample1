using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PresenterFirstExample1.Model;
using PresenterFirstExample1.Presenter;

namespace PresenterFirstExample1.View
{
    static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            INameValidator nameValidator = new NameValidator();
            IEmailValidator emailValidator = new SystemNetEmailValidator();

            IFormView view = new FormView();
            IFormModel model = new FormModel(emailValidator, nameValidator);
            FormPresenter prezenter = new FormPresenter(view, model);

            Application.Run((Form)view);
        }
    }
}
