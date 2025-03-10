using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

public class Exercise : INotifyPropertyChanged
{
    private bool _isDetailVisible;

    public string ExerciseName { get; set; }
    public string ExerciseDescription { get; set; }
    public string ImageUrl { get; set; }
    public string Duration { get; set; }
    public string VideoUrl { get; set; }

    public string HowToDo { get; set; }

    public bool IsDetailVisible
    {
        get => _isDetailVisible;
        set
        {
            if (_isDetailVisible != value)
            {
                _isDetailVisible = value;
                OnPropertyChanged(nameof(IsDetailVisible));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;


    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

