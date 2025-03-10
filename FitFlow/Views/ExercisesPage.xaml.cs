using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.IO;
namespace FitFlow.Views
{
    public partial class ExercisesPage : ContentPage
    {
        public ObservableCollection<Exercise> Exercises { get; set; }
        private Exercise _selectedExercise;

        public ExercisesPage()
        {
            InitializeComponent();
            Exercises = new ObservableCollection<Exercise>
            {
                new Exercise
                {
                    ExerciseName = "Push-ups",
                    ExerciseDescription = "A basic exercise for upper body strength.",
                    ImageUrl = "https://media1.popsugar-assets.com/files/thumbor/3mHOo40hZnyZ0JSCMzqq0G8vO3g/fit-in/1024x1024/filters:format_auto-!!-:strip_icc-!!-/2017/03/22/738/n/1922729/8589c22c445d63e2_0e7e9800cb65fd44_Tricep-Push-Up.jpg",
                    Duration = "2 minutes",
                    VideoUrl = "https://youtu.be/IODxDxX7oi4?si=SJXGSJ4n0lHVSS7J",
                    HowToDo = "1. Start in a plank position with your hands placed slightly wider than shoulder-width apart, feet together, and body in a straight line from head to heels. \r\n 2. Engage your core and keep your body straight as you lower yourself by bending your elbows, keeping them close to your body. \r\n 3. Lower your body until your chest is just above the ground or until your elbows are at a 90-degree angle. \r\n 4. Push through your hands to straighten your arms and return to the starting position. \r\n 5. Repeat for the desired number of repetitions, maintaining proper form throughout."
                },
                new Exercise
                {
                    ExerciseName = "Squats",
                    ExerciseDescription = "An exercise for strengthening legs and core.",
                    ImageUrl = "https://th.bing.com/th/id/OIP.KXTylxk6AOMgVErAIRuVDwHaFJ?rs=1&pid=ImgDetMain",
                    Duration = "3 minutes",
                    VideoUrl = "https://youtu.be/xqvCmoLULNY?si=Q19iSNrXiOwP2331",
                    HowToDo = "1. Stand with your feet shoulder-width apart and your toes pointing slightly outward. \r\n 2. Engage your core and keep your chest up as you push your hips back and bend your knees to lower your body. \r\n 3. Lower yourself until your thighs are parallel to the ground, making sure your knees do not go past your toes. \r\n 4. Press through your heels to straighten your legs and return to the starting position. \r\n 5. Repeat for the desired number of repetitions, maintaining proper form throughout."
                },
                new Exercise
                {
                    ExerciseName = "Burpees",
                    ExerciseDescription = "A full-body exercise that combines cardio and strength.",
                    ImageUrl = "https://whatsupmag.com/downloads/65289/download/fitness1.jpg?cb=b6bfba2be144bb527a222ba66ffd8ee7",
                    Duration = "4 minutes",
                    VideoUrl = "https://youtu.be/auBLPXO8Fww?si=YrO9Ktd4cDVaBMyA",
                    HowToDo = "1. Begin by standing with your feet shoulder-width apart and your arms at your sides. \r\n 2. Bend your knees and lower your body into a squat position, placing your hands on the floor in front of you. \r\n 3. Jump your feet back so that you are in a plank position with your body in a straight line from head to heels. \r\n 4. Perform a push-up by lowering your chest to the floor and then pressing back up to the plank position. \r\n 5. Jump your feet back to the squat position, keeping your hands on the floor. \r\n 6. Explode up into a jump, reaching your arms overhead. \r\n 7. Land softly and immediately go into the next repetition."
                },
                new Exercise
                {
                    ExerciseName = "Lunges",
                    ExerciseDescription = "A lower body exercise targeting legs and glutes.",
                    ImageUrl = "https://media.istockphoto.com/id/964785648/vector/illustrated-exercise-guide-by-healthy-woman-doing-lunges-workout-in-2-steps.jpg?s=612x612&w=0&k=20&c=aiyOizs_x3B3fI07LVuQ6thVMpRl_oAtbzJurVM56Jw=",
                    Duration = "3 minutes",
                    VideoUrl = "https://youtu.be/MxfTNXSFiYI?si=_DI9GKDSr_JDSjwb",
                    HowToDo = "1. Stand with your feet hip-width apart and your hands at your sides or on your hips. \r\n 2. Step forward with one leg, lowering your hips until both knees are bent at about a 90-degree angle. \r\n 3. Make sure your front knee is directly above your ankle and your back knee hovers just above the ground. \r\n 4. Push through the heel of your front foot to return to the starting position. \r\n 5. Repeat the movement with the opposite leg, stepping forward and lowering into the lunge. \r\n 6. Continue alternating legs for the desired number of repetitions, maintaining proper form throughout."
                },
                new Exercise
                {
                    ExerciseName = "Plank",
                    ExerciseDescription = "A core exercise to build endurance and strength.",
                    ImageUrl = "https://thumbs.dreamstime.com/b/art-illustration-201075973.jpg",
                    Duration = "2 minutes",
                    VideoUrl = "https://youtu.be/jAR4OF_kLX4?si=SwPy49y1e9lLUm6Y",
                    HowToDo = "1. Start by lying face down on the floor with your forearms and toes touching the ground. \r\n 2. Place your elbows directly beneath your shoulders and clasp your hands together or keep them parallel. \r\n 3. Engage your core, lift your body off the ground, and keep it in a straight line from head to heels. \r\n 4. Avoid letting your hips sag or pike upward; maintain a neutral spine throughout. \r\n 5. Hold this position for the desired amount of time, breathing steadily and keeping your core engaged."
                },
                new Exercise
                {
                    ExerciseName = "Mountain Climbers",
                    ExerciseDescription = "A cardio move that also targets your core, shoulders, and arms.",
                    ImageUrl = "https://t3.ftcdn.net/jpg/04/62/80/16/360_F_462801646_G0ioNWYiZ5PMLsb5QvQW8taMG5mZfbbU.jpg",
                    Duration = "2 minutes",
                    VideoUrl = "https://youtu.be/kLh-uczlPLg?si=2LmrqQgk07IKOFqc",
                    HowToDo = "1. Start in a high plank position with your hands directly beneath your shoulders and your body in a straight line. \r\n 2. Bring one knee towards your chest, keeping your core engaged and your hips level. \r\n 3. Quickly switch legs, bringing the other knee towards your chest while returning the first leg to the starting position. \r\n 4. Continue alternating legs at a rapid pace, maintaining proper form throughout."
                },
                new Exercise
                {
                    ExerciseName = "Jumping Jacks",
                    ExerciseDescription = "A full-body exercise to improve cardiovascular fitness.",
                    ImageUrl = "https://t3.ftcdn.net/jpg/04/43/19/04/360_F_443190446_mUwLRQrWFen369fSzxWb9WIvF6uzszCn.jpg",
                    Duration = "3 minutes",
                    VideoUrl = "https://youtu.be/iSSAk4XCsRA?si=0t0EnVwYJB4ptyeU",
                    HowToDo = "1. Start by standing with your feet together and your arms at your sides. \r\n 2. Jump up, spreading your legs to the sides while raising your arms above your head. \r\n 3. Jump back to the starting position with your feet together and arms at your sides. \r\n 4. Continue jumping in and out, maintaining a steady rhythm."
                },

new Exercise
{
    ExerciseName = "Crunches",
    ExerciseDescription = "An abdominal exercise to strengthen your core.",
    ImageUrl = "https://t3.ftcdn.net/jpg/03/67/60/32/360_F_367603208_29Ycsr2zZMI9JkikpZ2hCd3GxXbSql4j.jpg",
    Duration = "2 minutes",
    VideoUrl = "https://youtu.be/0t4t3IpiEao?si=3C3KbDlsvbtCq9K6",
    HowToDo = "1. Lie flat on your back with your knees bent and your feet flat on the floor. \r\n 2. Place your hands behind your head or across your chest. \r\n 3. Engage your core and lift your shoulders off the ground towards your knees. \r\n 4. Lower yourself back down with control. \r\n 5. Repeat for the desired number of repetitions."
},
new Exercise
{
    ExerciseName = "Leg Raises",
    ExerciseDescription = "An exercise targeting the lower abdominal muscles.",
    ImageUrl = "https://www.shutterstock.com/image-vector/leg-raises-tabata-exercises-fitness-260nw-1097123654.jpg",
    Duration = "2 minutes",
    VideoUrl = "https://youtu.be/U4L_6JEv9Jg?si=y3OSt9Hshb-avHJ4",
    HowToDo = "1. Lie flat on your back with your legs straight and your arms at your sides. \r\n 2. Keeping your legs straight, lift them up towards the ceiling until they are perpendicular to the floor. \r\n 3. Slowly lower your legs back down to just above the ground, keeping your core engaged. \r\n 4. Repeat for the desired number of repetitions."
},
new Exercise
{
    ExerciseName = "Tricep Dips",
    ExerciseDescription = "An exercise for triceps and chest.",
    ImageUrl = "https://media.istockphoto.com/id/1094508770/vector/chair-bench-triceps-dips-sport-exersice-silhouettes-of-woman-doing-exercise-workout-training.jpg?s=612x612&w=0&k=20&c=ileYV4a2zvsgQdYbN_bsOe2yn1hVAEUg2flkpAWi_-A=",
    Duration = "3 minutes",
    VideoUrl = "https://youtu.be/6kALZikXxLc?si=6mQC0zU5pSa3eT67",
    HowToDo = "1. Sit on the edge of a bench or chair with your hands placed next to your hips. \r\n 2. Slide your hips off the edge, keeping your hands on the bench, and extend your legs out in front of you. \r\n 3. Bend your elbows and lower your body down towards the floor. \r\n 4. Push through your hands to lift your body back up to the starting position. \r\n 5. Repeat for the desired number of repetitions."
},
new Exercise
{
    ExerciseName = "Bicep Curls",
    ExerciseDescription = "An exercise for strengthening the biceps.",
    ImageUrl = "https://www.shutterstock.com/image-vector/man-doing-standing-dumbbell-bicep-260nw-1850250391.jpg",
    Duration = "2 minutes",
    VideoUrl = "https://youtu.be/ykJmrZ5v0Oo?si=cHOE-KA4Fw_L5yFx",
    HowToDo = "1. Stand with your feet shoulder-width apart and hold a dumbbell in each hand with your palms facing forward. \r\n 2. Keeping your elbows close to your torso, curl the weights up towards your shoulders. \r\n 3. Slowly lower the weights back to the starting position. \r\n 4. Repeat for the desired number of repetitions."
},
new Exercise
{
    ExerciseName = "Deadlifts",
    ExerciseDescription = "A compound exercise for the back, glutes, and legs.",
    ImageUrl = "https://hips.hearstapps.com/hmg-prod/images/romanian-deadlift-1595930760.jpg",
    Duration = "3 minutes",
    VideoUrl = "https://youtu.be/1ZXobu7JvvE?si=LU3Ny-Ye7GLNvTAT",
    HowToDo = "1. Stand with your feet hip-width apart and a barbell in front of you. \r\n 2. Bend your knees slightly and hinge at the hips to grasp the barbell with an overhand grip. \r\n 3. Keeping your back flat, lift the barbell by straightening your legs and hips. \r\n 4. Lower the barbell back to the ground with control. \r\n 5. Repeat for the desired number of repetitions."
},
new Exercise
{
    ExerciseName = "Bench Press",
    ExerciseDescription = "A classic exercise for chest and triceps.",
    ImageUrl = "https://cdn.squats.in/kc_articles/165710974746405e93d3730146b9b.png",
    Duration = "3 minutes",
    VideoUrl = "https://youtu.be/SCVCLChPQFY?si=Lxvzg7T4iIKEX8L4",
    HowToDo = "1. Lie flat on a bench with your feet planted on the floor and a barbell held above your chest. \r\n 2. Lower the barbell to your chest by bending your elbows. \r\n 3. Push the barbell back up to the starting position. \r\n 4. Repeat for the desired number of repetitions."
},
new Exercise
{
    ExerciseName = "Rows",
    ExerciseDescription = "An exercise for the back muscles.",
    ImageUrl = "https://www.shutterstock.com/shutterstock/photos/2101536073/display_1500/stock-vector-man-doing-single-arm-bent-over-row-exercise-flat-vector-illustration-isolated-on-white-background-2101536073.jpg",
    Duration = "3 minutes",
    VideoUrl = "https://youtu.be/tZUYS7X50so?si=GWqKrLdbq0TskwB0",
    HowToDo = "1. Bend at the waist with a slight bend in your knees and hold a barbell or dumbbells in front of you. \r\n 2. Pull the weights towards your lower rib cage, squeezing your shoulder blades together. \r\n 3. Lower the weights back to the starting position. \r\n 4. Repeat for the desired number of repetitions."
},
new Exercise
{
    ExerciseName = "Overhead Press",
    ExerciseDescription = "An exercise for shoulders and triceps.",
    ImageUrl = "https://www.mensjournal.com/.image/t_share/MTk2MTM2OTEwMjczNzE3NzY1/should-i-do-the-overhead-press.jpg",
    Duration = "2 minutes",
    VideoUrl = "https://youtu.be/F3QY5vMz_6I?si=ZdM9DYOUT_6fjebt",
    HowToDo = "1. Stand with your feet shoulder-width apart and hold a barbell or dumbbells at shoulder height. \r\n 2. Press the weights overhead until your arms are fully extended. \r\n 3. Lower the weights back to shoulder height. \r\n 4. Repeat for the desired number of repetitions."
}

            };

            ExercisesListView.ItemsSource = Exercises;
            // Preload images for caching
            foreach (var exercise in Exercises)
            {
                _ = PreloadImage(exercise.ImageUrl);
            }
        }

        private async Task PreloadImage(string imageUrl)
        {
            try
            {
                var localFilePath = await DownloadAndCacheImage(imageUrl);
                if (!string.IsNullOrEmpty(localFilePath))
                {
                    // Update the ImageUrl to the local file path
                    foreach (var exercise in Exercises)
                    {
                        if (exercise.ImageUrl == imageUrl)
                        {
                            exercise.ImageUrl = localFilePath;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to preload image: {ex.Message}");
            }
        }

        private async Task<string> DownloadAndCacheImage(string imageUrl)
        {
            var httpClient = new HttpClient();
            var imageBytes = await httpClient.GetByteArrayAsync(imageUrl);

            // Create a local file path for caching
            var localFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Path.GetFileName(imageUrl));

            // Save the image to the local file
            File.WriteAllBytes(localFilePath, imageBytes);

            return localFilePath;
        }



        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is Exercise selectedExercise)
            {
                // If the selected exercise is the same as the previously selected one, toggle its visibility
                if (_selectedExercise == selectedExercise)
                {
                    selectedExercise.IsDetailVisible = !selectedExercise.IsDetailVisible;
                }
                else
                {
                    // Close details of the previously selected exercise
                    if (_selectedExercise != null)
                    {
                        _selectedExercise.IsDetailVisible = false;
                    }

                    // Open details of the newly selected exercise
                    selectedExercise.IsDetailVisible = true;

                    // Update the reference to the currently selected exercise
                    _selectedExercise = selectedExercise;
                }

                // Force the ListView to update
                ExercisesListView.BeginRefresh();
                ExercisesListView.EndRefresh();
            }
        }
    }
}
