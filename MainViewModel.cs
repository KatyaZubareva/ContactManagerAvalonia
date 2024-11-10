using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

public class MainViewModel : INotifyPropertyChanged
{
    private Contact _selectedContact;

    public ObservableCollection<Contact> Contacts { get; set; }
    public Contact SelectedContact
    {
        get => _selectedContact;
        set
        {
            _selectedContact = value;
            OnPropertyChanged(nameof(SelectedContact));
        }
    }

    public ICommand AddCommand { get; }
    public ICommand SaveCommand { get; }

    public MainViewModel()
    {
        Contacts = new ObservableCollection<Contact>();
        AddCommand = new RelayCommand(AddContact);
        SaveCommand = new RelayCommand(SaveContact);
    }

    private void AddContact()
    {
        SelectedContact = new Contact();
        OnPropertyChanged(nameof(SelectedContact));
    }

    private void SaveContact()
    {
        if (!Contacts.Contains(SelectedContact))
            Contacts.Add(SelectedContact);
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
