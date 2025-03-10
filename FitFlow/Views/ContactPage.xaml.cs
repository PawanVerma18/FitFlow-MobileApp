using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace FitFlow.Views
{
    public partial class ContactPage : ContentPage
    {
        public ContactPage()
        {
            InitializeComponent();
        }

        private void OnSubmitClicked(object sender, EventArgs e)
        {
            // Get input values
            string name = nameEntry.Text?.Trim();
            string email = emailEntry.Text?.Trim();
            string message = messageEditor.Text?.Trim();

            // Perform validation
            if (string.IsNullOrEmpty(name))
            {
                DisplayAlert("Validation Error", "Name is required.", "OK");
                return;
            }

            if (string.IsNullOrEmpty(email) || !IsValidEmail(email))
            {
                DisplayAlert("Validation Error", "A valid email address is required.", "OK");
                return;
            }

            if (string.IsNullOrEmpty(message))
            {
                DisplayAlert("Validation Error", "Message cannot be empty.", "OK");
                return;
            }

            // If all validations pass
            DisplayAlert("Contact Submitted", $"Name: {name}\nEmail: {email}\nMessage: {message}", "OK");
        }

        private bool IsValidEmail(string email)
        {
            // Basic email validation using a regular expression
            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            return emailRegex.IsMatch(email);
        }
    }
}
