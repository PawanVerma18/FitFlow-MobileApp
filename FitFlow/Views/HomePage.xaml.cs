using System;
using Xamarin.Forms;

namespace FitFlow.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void OnGetStartedClicked(object sender, EventArgs e)
        {
            // Handle the button click event
            Navigation.PushAsync(new MainPage());
        }
    }
}
