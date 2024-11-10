// Models/Contact.cs
using ReactiveUI;
using System.Reactive;

namespace AvaloniaContactManager.Models
{
    public class Contact : ReactiveObject
    {
        private string name;
        private string email;
        private string phone;

        public string Name
        {
            get => name;
            set => this.RaiseAndSetIfChanged(ref name, value);
        }

        public string Email
        {
            get => email;
            set => this.RaiseAndSetIfChanged(ref email, value);
        }

        public string Phone
        {
            get => phone;
            set => this.RaiseAndSetIfChanged(ref phone, value);
        }
    }
}
