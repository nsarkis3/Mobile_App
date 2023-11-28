using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.ViewModels
{
    public class TimerViewModel : BindableObject
    {
        private Timer timer;
        private TimeSpan countdownDuration = TimeSpan.FromMinutes(1);

        public TimerViewModel()
        {
            RemainingTime = countdownDuration;
        }

        ~TimerViewModel()
        {
            // Dispose of the timer when the ViewModel is no longer needed
            timer.Dispose();
        }

        private void UpdateCountdown(object state)
        {
            // Calculate the remaining time
            TimeSpan remainingTime = countdownDuration - TimeSpan.FromSeconds(timerCount/2);

            // Update the properties on the UI thread
            Dispatcher.Dispatch(() =>
            {
                RemainingTime = remainingTime;
                if (RemainingTime <= TimeSpan.Zero)
                {
                    DisplayAlert();
                    timer.Dispose();
                }
            });
            timerCount++;
        }

        private int timerCount = 0;

        private TimeSpan remainingTime;
        public TimeSpan RemainingTime
        {
            get { return remainingTime; }
            private set
            {
                if (remainingTime != value)
                {
                    remainingTime = value;
                    OnPropertyChanged(nameof(RemainingTime));
                    UpdateRemainingTime();
                }
            }
        }
        public void UpdateRemainingTime()
        {
            // Explicitly update the remaining time
            RemainingTime = countdownDuration - TimeSpan.FromSeconds(timerCount/2);
        }

        public void startTimer()
        {
            // Start the timer when the button is clicked
            timer = new Timer(UpdateCountdown, null, TimeSpan.Zero, TimeSpan.FromMilliseconds(500));
        }

        public void halfTime() 
        {
            timer.Dispose();
            timerCount = 0;
            countdownDuration = TimeSpan.FromMinutes(10);
            timer = new Timer(UpdateCountdown, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
        }

        public void startSecondHalf()
        {
            timer.Dispose();
            timerCount = 0;
            countdownDuration = TimeSpan.FromMinutes(45);
            timer = new Timer(UpdateCountdown, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
        }

        private async void DisplayAlert()
        {
            await Dispatcher.DispatchAsync(async () =>
            {
                await App.Current.MainPage.DisplayAlert("Time", "Time is up", "OK");
            });
        }
    }
}
