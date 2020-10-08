using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PresenterFirstExample1.Model
{
    public class FormValidationResult
    {
        private readonly List<string> messages;

        public FormValidationResult()
        {
            messages = new List<string>();
        }

        public void AddMessage(string message) { messages.Add(message); }
        public bool IsValid { get { return messages.Count == 0; } }
        public IEnumerable<string> Messages { get { return new ReadOnlyCollection<string>(messages); } }
    };
}
