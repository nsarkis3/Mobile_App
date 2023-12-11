using Plugin.Maui.Audio;
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
        private TimeSpan countdownDuration = TimeSpan.FromMinutes(45);
        IAudioManager audioManager;
        IAudioPlayer start;
        IAudioPlayer end;

        public TimerViewModel(IAudioManager audioManager)
        {
            RemainingTime = countdownDuration;
            this.audioManager = audioManager;
        }

        ~TimerViewModel()
        {
            timer.Dispose();
            start.Dispose();
        }

        private void UpdateCountdown(object state)
        {
            TimeSpan remainingTime = countdownDuration - TimeSpan.FromSeconds(timerCount/2);
            Dispatcher.Dispatch(async () =>
            {
                RemainingTime = remainingTime;
                if (RemainingTime <= TimeSpan.Zero)
                {
                    end = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("End.mp3"));
                    end.Play();
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
            RemainingTime = countdownDuration - TimeSpan.FromSeconds(timerCount/2);
        }

        public async void startTimer()
        {
            start = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("Horn.wav"));
            start.Play();
            timer = new Timer(UpdateCountdown, null, TimeSpan.Zero, TimeSpan.FromMilliseconds(500));
        }

        public async void halfTime() 
        {
            timer.Dispose();
            timerCount = 0;
            start = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("Horn.wav"));
            start.Play();
            countdownDuration = TimeSpan.FromMinutes(10);
            timer = new Timer(UpdateCountdown, null, TimeSpan.Zero, TimeSpan.FromMilliseconds(500));
        }

        public async void startSecondHalf()
        {
            timer.Dispose();
            timerCount = 0;
            start = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("Horn.wav"));
            start.Play();
            countdownDuration = TimeSpan.FromSeconds(7);
            timer = new Timer(UpdateCountdown, null, TimeSpan.Zero, TimeSpan.FromMilliseconds(500));
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
