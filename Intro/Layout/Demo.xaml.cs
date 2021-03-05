using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Intro
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Demo : ContentPage
    {
        public Demo()
        {
            InitializeComponent();

            _contacts = GetContacts();
            listView.ItemsSource = _contacts;
        }

        private void listView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            //var contact = e.Item as Contact;
            //DisplayAlert("Tapped", contact.Name, "OK");
        }

        async void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;
            var contact = e.SelectedItem as Contact;
            await Navigation.PushAsync(new ContactDetailPage(contact));
            listView.SelectedItem = null;
        }

        private void CallClicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var contact = menuItem.CommandParameter as Contact;

            DisplayAlert("Call", contact.Name, "OK");
        }

        private ObservableCollection<Contact> _contacts;
        private void DeleteClicked(object sender, EventArgs e)
        {
            var contact = (sender as MenuItem).CommandParameter as Contact;
            _contacts.Remove(contact);
        }

        ObservableCollection<Contact> GetContacts(string searchText = null)
        {
            ObservableCollection<Contact> contacts = new ObservableCollection<Contact>
            {
                    new Contact { Name = "Thor", ImageUrl = "https://hips.hearstapps.com/digitalspyuk.cdnds.net/18/09/1519729389-thor-ragnarok-reviews-big.jpg?crop=0.5428571428571428xw:1xh;center,top&resize=100:*"},
                    new Contact { Name = "Loki", Status = "new phone who dis?", ImageUrl = "https://hips.hearstapps.com/digitalspyuk.cdnds.net/18/05/1517238563-loki-tom-hiddleston-thor-ragnarok.jpg?crop=1xw:0.9025xh;center,top&resize=100:*"},
                    new Contact { Name = "Jacky", Status = "<3", ImageUrl = "https://schuett-grundei.de/wp-content/uploads/2020/11/BEARBEITET-01154_Die_Maus.jpg-100x100.png"}
            };

            if (String.IsNullOrWhiteSpace(searchText)) return contacts;
            var result = contacts.Where(c => c.Name.StartsWith(searchText, StringComparison.InvariantCultureIgnoreCase));
            return new ObservableCollection<Contact>(result);
        }
        private void listView_Refreshing(object sender, EventArgs e)
        {
            listView.ItemsSource = GetContacts();

            listView.EndRefresh();
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            _contacts = GetContacts(SearchBar.Text);
            listView.ItemsSource = _contacts;
        }

    }
}