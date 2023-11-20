using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MVVM.ViewModels;

public class PowersViewModel : INotifyPropertyChanged {
	double exponent, power;
	public event PropertyChangedEventHandler PropertyChanged;

	public PowersViewModel(double baseValue) {
		// Initialize properties.
		BaseValue = baseValue;
		Exponent = 0;

		// Initialize ICommand properties.
		IncreaseExponentCommand = new Command(ExecuteIncreaseExponent);
		DecreaseExponentCommand = new Command(ExecuteDecreaseExponent);
	}
	void ExecuteIncreaseExponent() {
		Exponent += 1;
	}
	void ExecuteDecreaseExponent() {
		Exponent -= 1;
	}
	public double BaseValue { private set; get; }

	public double Exponent {
		private set {
			if (SetProperty(ref exponent, value)) {
				Power = Math.Pow(BaseValue, exponent);
			}
		}
		get {
			return exponent;
		}
	}
	public double Power {
		private set { SetProperty(ref power, value); }
		get { return power; }
	}
	protected bool SetProperty<T>(ref T storage, T value,
							  [CallerMemberName] string propertyName = null) {
		if (Object.Equals(storage, value))
			return false;

		storage = value;
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		return true;
	}
	public ICommand IncreaseExponentCommand { private set; get; }

	public ICommand DecreaseExponentCommand { private set; get; }
}
