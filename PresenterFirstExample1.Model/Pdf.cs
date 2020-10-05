using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresenterFirstExample1.Model
{
    public class Pdf
    {
        private readonly string pathToFile;

        public Pdf(string pathToFile)
        {
            this.pathToFile = pathToFile;
        }

        public string PathToFile { get { return pathToFile; } }
    }
}
