using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Intro
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public class ContactMethod
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public partial class SwitchPage : ContentPage
    {

        private IList<ContactMethod> _contactMethods;

        public SwitchPage()
        {
            InitializeComponent();

            _contactMethods = GetContactMethods();
            foreach (var method in _contactMethods)
                contactMethods.Items.Add(method.Name);
        }

        private void Entry_Completed(object sender, EventArgs e)
        {
            label.Text = "Completed";
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            label.Text = e.NewTextValue;
        }

        private void contactMethods_SelectedIndexChanged(object sender, EventArgs e)
        {
            var name = contactMethods.Items[contactMethods.SelectedIndex];
            var contactMethod = _contactMethods.Single(cm => cm.Name == name);


            DisplayAlert("Selection", name, "OK");
        }

        private IList<ContactMethod> GetContactMethods()
        {
            return new List<ContactMethod>
            {
                new ContactMethod{ Id= 1, Name = "SMS"},
                new ContactMethod{ Id= 2, Name = "Email"}
            };
        }

        private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            return;
        }

        //private void Switch_Toggled(object sender, ToggledEventArgs e)
        //{
        //    label.IsVisible = e.Value;
        //}
    }
}