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
    public partial class Quotes : ContentPage
    {
        private int index = 0;
        private string[] quotes = new string[] { "a", "b", "Jacky ist ne Supermaus"};

        public Quotes()
        {
            InitializeComponent();
            currentQuote.Text = quotes[index];
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            index++;
            if (index > 2) index = 0;
            currentQuote.Text = quotes[index];
        }

    }
}