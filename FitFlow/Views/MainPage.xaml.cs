using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FitFlow.Views
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        private string _dailyQuote;
        private List<Workout> _workouts;
        private string _benefits;
        private bool _isBenefitsVisible;
        private int _totalCalories;
        private string _totalDuration;

        // List of motivational quotes
        private List<string> _quotes = new List<string>
        {
            "<i>'The only bad workout is the one you didn’t do.'</i>",
            "<i>'Strive for progress, not perfection.'</i>",
            "<i>'Don’t stop until you’re proud.'</i>",
            "<i>'Sweat is fat crying.'</i>",
            "<i>'Your body can stand almost anything. It’s your mind you have to convince.'</i>"
        };

        // List of workouts
        private List<Workout> _workoutsData = new List<Workout>
        {
            new Workout
            {
                WorkoutName = "Push-ups",
                WorkoutDescription = "A basic exercise for upper body strength.",
                Duration = "2 minutes",
                CaloriesPerMinute = 8,
                HowToDo = "1. Start in a plank position...",
                ImageUrl = "https://media1.popsugar-assets.com/files/thumbor/3mHOo40hZnyZ0JSCMzqq0G8vO3g/fit-in/1024x1024/filters:format_auto-!!-:strip_icc-!!-/2017/03/22/738/n/1922729/8589c22c445d63e2_0e7e9800cb65fd44_Tricep-Push-Up.jpg"
            },
            new Workout
            {
                WorkoutName = "Squats",
                WorkoutDescription = "An exercise for strengthening legs and core.",
                Duration = "3 minutes",
                CaloriesPerMinute = 10,
                HowToDo = "1. Stand with your feet shoulder-width apart...",
                ImageUrl = "https://th.bing.com/th/id/OIP.KXTylxk6AOMgVErAIRuVDwHaFJ?rs=1&pid=ImgDetMain"
            },
            new Workout
            {
                WorkoutName = "Burpees",
                WorkoutDescription = "A full-body exercise that combines cardio and strength.",
                Duration = "4 minutes",
                CaloriesPerMinute = 12,
                HowToDo = "1. Begin by standing with your feet shoulder-width apart...",
                ImageUrl = "https://whatsupmag.com/downloads/65289/download/fitness1.jpg?cb=b6bfba2be144bb527a222ba66ffd8ee7"
            },
            new Workout
            {
                WorkoutName = "Plank",
                WorkoutDescription = "A core exercise to build endurance and strength.",
                Duration = "2 minutes",
                CaloriesPerMinute = 5,
                HowToDo = "1. Start by lying face down on the floor...",
                ImageUrl = "https://thumbs.dreamstime.com/b/art-illustration-201075973.jpg"
            }
        };

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;

            // Set a random quote when the page loads
            SetRandomQuote();

            // Initialize workouts
            Workouts = GetRandomWorkouts(3); // Show 3 random workouts
            Benefits = "";
            IsBenefitsVisible = false;
            TotalCalories = 0;
            TotalDuration = "0 minutes";
        }

        // Properties for binding
        public string DailyQuote
        {
            get => _dailyQuote;
            set
            {
                _dailyQuote = value;
                OnPropertyChanged(nameof(DailyQuote));
            }
        }

        public List<Workout> Workouts
        {
            get => _workouts;
            set
            {
                _workouts = value;
                OnPropertyChanged(nameof(Workouts));
            }
        }

        public string Benefits
        {
            get => _benefits;
            set
            {
                _benefits = value;
                OnPropertyChanged(nameof(Benefits));
            }
        }

        public bool IsBenefitsVisible
        {
            get => _isBenefitsVisible;
            set
            {
                _isBenefitsVisible = value;
                OnPropertyChanged(nameof(IsBenefitsVisible));
            }
        }

        public int TotalCalories
        {
            get => _totalCalories;
            set
            {
                _totalCalories = value;
                OnPropertyChanged(nameof(TotalCalories));
            }
        }

        public string TotalDuration
        {
            get => _totalDuration;
            set
            {
                _totalDuration = value;
                OnPropertyChanged(nameof(TotalDuration));
            }
        }

        // Set a random quote from the list
        private void SetRandomQuote()
        {
            Random random = new Random();
            DailyQuote = _quotes[random.Next(_quotes.Count)];
        }

        // Get random workouts
        private List<Workout> GetRandomWorkouts(int count)
        {
            Random random = new Random();
            List<Workout> randomWorkouts = new List<Workout>();

            for (int i = 0; i < count; i++)
            {
                int index = random.Next(_workoutsData.Count);
                randomWorkouts.Add(_workoutsData[index]);
            }

            return randomWorkouts;
        }

        // Event handler for "Check It" button
        private void OnCheckItClicked(object sender, EventArgs e)
        {
            // Calculate total calories and duration
            int totalCalories = 0;
            int totalDurationMinutes = 0;

            foreach (var workout in Workouts)
            {
                int durationMinutes = int.Parse(workout.Duration.Split(' ')[0]); // Extract minutes from "X minutes"
                totalCalories += workout.CaloriesPerMinute * durationMinutes;
                totalDurationMinutes += durationMinutes;
            }

            // Update properties
            TotalCalories = totalCalories;
            TotalDuration = $"{totalDurationMinutes} minutes";

            // Set benefits of the workout
            Benefits = $"Benefits of today's workout:\n- Improves strength\n- Burns {TotalCalories} kcal\n- Boosts endurance";
            IsBenefitsVisible = true;
        }

        // Event handler for "Share Progress" button
        private async void OnShareProgressClicked(object sender, EventArgs e)
        {
            try
            {
                // Share text using Xamarin.Essentials
                await Share.RequestAsync(new ShareTextRequest
                {
                    Text = $"I just completed a {TotalDuration} workout and burned {TotalCalories} kcal with GymBuddy! 💪 #FitnessGoals",
                    Title = "Share Your Progress"
                });
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Unable to share progress.", "OK");
            }
        }

        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public class Workout
    {
        public string WorkoutName { get; set; }
        public string WorkoutDescription { get; set; }
        public string Duration { get; set; }
        public int CaloriesPerMinute { get; set; }
        public string HowToDo { get; set; }
        public string ImageUrl { get; set; } // Add this if you want to display images
    }
}