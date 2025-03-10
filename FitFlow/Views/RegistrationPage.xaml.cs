using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace FitFlow.Views
{
    public partial class RegistrationPage : ContentPage, INotifyPropertyChanged
    {
        // Properties for binding
        private string _fullName;
        private string _email;
        private string _phoneNumber;
        private string _cardNumber;
        private string _expiryDate;
        private string _cvv;
        private MembershipPlan _selectedPlan;
        private bool _isDropdownVisible;

        public RegistrationPage()
        {
            InitializeComponent();
            BindingContext = this;

            // Initialize membership plans
            MembershipPlans = new List<MembershipPlan>
            {
                new MembershipPlan { Name = "Basic Plan", Price = "$9.99/month" },
                new MembershipPlan { Name = "Premium Plan", Price = "$19.99/month" },
                new MembershipPlan { Name = "Ultimate Plan", Price = "$29.99/month" }
            };

            // Initialize selected plan
            SelectedPlan = MembershipPlans[0]; // Default to the first plan
            IsDropdownVisible = false; // Hide dropdown initially
        }

        // List of membership plans
        public List<MembershipPlan> MembershipPlans { get; set; }

        // Selected membership plan
        public MembershipPlan SelectedPlan
        {
            get => _selectedPlan;
            set
            {
                _selectedPlan = value;
                OnPropertyChanged(nameof(SelectedPlan));
                OnPropertyChanged(nameof(SelectedPlan.Name)); // Update button text
                IsDropdownVisible = false; // Hide dropdown after selection
            }
        }

        // Dropdown visibility
        public bool IsDropdownVisible
        {
            get => _isDropdownVisible;
            set
            {
                _isDropdownVisible = value;
                OnPropertyChanged(nameof(IsDropdownVisible));
            }
        }

        // User details
        public string FullName
        {
            get => _fullName;
            set
            {
                _fullName = value;
                OnPropertyChanged(nameof(FullName));
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                _phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }

        // Payment details
        public string CardNumber
        {
            get => _cardNumber;
            set
            {
                _cardNumber = value;
                OnPropertyChanged(nameof(CardNumber));
            }
        }

        public string ExpiryDate
        {
            get => _expiryDate;
            set
            {
                _expiryDate = value;
                OnPropertyChanged(nameof(ExpiryDate));
            }
        }

        public string CVV
        {
            get => _cvv;
            set
            {
                _cvv = value;
                OnPropertyChanged(nameof(CVV));
            }
        }

        // Event handler for dropdown button
        private void OnDropdownClicked(object sender, EventArgs e)
        {
            IsDropdownVisible = !IsDropdownVisible; // Toggle dropdown visibility
        }

        // Event handler for "Buy Now" button
        private async void OnBuyNowClicked(object sender, EventArgs e)
        {
            // Validate user input
            if (string.IsNullOrWhiteSpace(FullName) ||
                string.IsNullOrWhiteSpace(Email) ||
                string.IsNullOrWhiteSpace(PhoneNumber) ||
                string.IsNullOrWhiteSpace(CardNumber) ||
                string.IsNullOrWhiteSpace(ExpiryDate) ||
                string.IsNullOrWhiteSpace(CVV) ||
                SelectedPlan == null)
            {
                await DisplayAlert("Error", "Please fill in all fields and select a membership plan.", "OK");
                return;
            }

            // Simulate payment processing
            bool confirmPurchase = await DisplayAlert("Confirm Purchase", $"Do you want to purchase the {SelectedPlan.Name} for {SelectedPlan.Price}?", "Yes", "No");

            if (confirmPurchase)
            {
                // Simulate successful purchase
                await DisplayAlert("Success", $"You have successfully purchased the {SelectedPlan.Name}!", "OK");

                // Navigate back to the main page (or any other page)
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Cancelled", "Purchase cancelled.", "OK");
            }
        }

        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    // MembershipPlan class
    public class MembershipPlan
    {
        public string Name { get; set; }
        public string Price { get; set; }
    }
}