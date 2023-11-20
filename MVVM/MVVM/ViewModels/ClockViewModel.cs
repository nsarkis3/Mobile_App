using System;
using System.ComponentModel;

namespace MVVM.ViewModels;

public class ClockViewModel : INotifyPropertyChanged {
	DateTime dateTime = DateTime.Now;
	Timer timer;
    DateTime appStartTime = DateTime.Now;
    TimeSpan elapsedTime;
    public event PropertyChangedEventHandler PropertyChanged;

	public ClockViewModel() {
		timer = new Timer(new TimerCallback((s) => this.DateTime = DateTime.Now),
							   null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
        elapsedTime = DateTime.Now - appStartTime;
    }
	~ClockViewModel() {
		timer.Dispose();
	}
	public DateTime DateTime {
		private set {
			if (dateTime != value) {
				dateTime = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DateTime"));
				elapsedTime = dateTime - appStartTime;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ElapsedTime"));
            }
		}
		get {
			return dateTime;
		}
	}

    public TimeSpan ElapsedTime
    {
        get { return elapsedTime; }
        private set
        {
            if (elapsedTime != value)
            {
                elapsedTime = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ElapsedTime"));
            }
        }
    }
}
