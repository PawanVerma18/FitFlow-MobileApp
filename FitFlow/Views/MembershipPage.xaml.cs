using System;
using Xamarin.Forms;

namespace FitFlow.Views
{
    public partial class MembershipPage : ContentPage
    {
        // Property to store the selected plan
        public string SelectedPlan { get; set; }

        public MembershipPage()
        {
            InitializeComponent();
        }

        // Event handler for subscription buttons
        private async void OnSubscribeClicked(object sender, EventArgs e)
        {
            // Get the selected plan from the button's CommandParameter
            var button = sender as Button;
            string plan = button?.CommandParameter as string;

            if (!string.IsNullOrEmpty(plan))
            {
                // Store the selected plan
                SelectedPlan = plan;

                // Show a confirmation message
                await DisplayAlert("Plan Selected", $"You have selected the {plan} Plan.", "OK");
                await Navigation.PushAsync(new RegistrationPage());

                // Navigate to the payment page or perform other actions
                // For example:
                // await Navigation.PushAsync(new PaymentPage(SelectedPlan));
            }
        }


    }
}