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
    public partial class PopUpPage : ContentPage
    {
        public PopUpPage()
        {
            InitializeComponent();
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            //var response = await DisplayAlert("Warning","Are you sure?","Yes","No");
            //if (response)
            //{
            //    await DisplayAlert("Done", "Saving", "Ok");
            //}

            var response = await DisplayActionSheet("Title","Cancel","Delete","Copy", "Message", "Email");
            await DisplayAlert("Response", response, "Ok");
        }

        private void ToolbarItem_Activated(object sender, EventArgs e)
        {
            DisplayAlert("Ok", "Toolbar activated", "Oki");
        }
    }
}