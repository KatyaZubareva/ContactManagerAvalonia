// ViewModels/ContactViewModel.cs
using ReactiveUI;
using System.Collections.ObjectModel;
using AvaloniaContactManager.Models;

namespace AvaloniaContactManager.ViewModels
{
    public class ContactViewModel : ReactiveObject
    {
        private Contact selectedContact;
        public ObservableCollection<Contact> Contacts { get; set; }

        public Contact SelectedContact
        {
            get => selectedContact;
            set => this.RaiseAndSetIfChanged(ref selectedContact, value);
        }

        public ReactiveCommand<Unit, Unit> AddContactCommand { get; }
        public ReactiveCommand<Unit, Unit> SaveChangesCommand { get; }

        public ContactViewModel()
        {
            Contacts = new ObservableCollection<Contact>();
            AddContactCommand = ReactiveCommand.Create(AddContact);
            SaveChangesCommand = ReactiveCommand.Create(SaveChanges);
        }

        private void AddContact()
        {
            SelectedContact = new Contact();
        }

        private void SaveChanges()
        {
            if (SelectedContact != null && !Contacts.Contains(SelectedContact))
            {
                Contacts.Add(SelectedContact);
            }
        }

        
    }
}
