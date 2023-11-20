using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVM.ViewModels;

public class ColorViewModel : INotifyPropertyChanged {
	Color color;

	public event PropertyChangedEventHandler PropertyChanged;

	public ColorViewModel() {
		color = Colors.Black;
	}
	public float Red {
		set {
			if (Round(color.Red) != value)
				Color = Color.FromRgba(value, color.Green, color.Blue, color.Alpha);
		}
		get {
			return Round(color.Red);
		}
	}
	public float Green {
		set {
			if (Round(color.Green) != value)
				Color = Color.FromRgba(color.Red, value, color.Blue, color.Alpha);
		}
		get {
			return Round(color.Green);
		}
	}
	public float Blue {
		set {
			if (Round(color.Blue) != value)
				Color = Color.FromRgba(color.Red, color.Green, value, color.Alpha);
		}
		get {
			return Round(color.Blue);
		}
	}
	public float Alpha {
		set {
			if (Round(color.Alpha) != value)
				Color = Color.FromRgba(color.Red, color.Green, color.Blue, value);
		}
		get {
			return Round(color.Alpha);
		}
	}
	public float Hue {
		set {
			if (Round(color.GetHue()) != value)
				Color = Color.FromHsla(value, color.GetSaturation(), color.GetLuminosity(), color.Alpha);
		}
		get {
			return Round(color.GetHue());
		}
	}
	public float Saturation {
		set {
			if (Round(color.GetSaturation()) != value)
				Color = Color.FromHsla(color.GetHue(), value, color.GetLuminosity(), color.Alpha);
		}
		get {
			return Round(color.GetSaturation());
		}
	}
	public float Luminosity {
		set {
			if (Round(color.GetLuminosity()) != value)
				Color = Color.FromHsla(color.GetHue(), color.GetSaturation(), value, color.Alpha);
		}
		get {
			return Round(color.GetLuminosity());
		}
	}
	public Color Color {
		set {
			Color oldColor = color;

			if (color != value) {
				color = value;
				OnPropertyChanged();	// Take advantage of [CallerMemberName]
			}

			if (color.Red != oldColor.Red)
				OnPropertyChanged("Red");

			if (color.Green != oldColor.Green)
				OnPropertyChanged("Green");

			if (color.Blue != oldColor.Blue)
				OnPropertyChanged("Blue");

			if (color.Alpha != oldColor.Alpha)
				OnPropertyChanged("Alpha");

			if (color.GetHue() != oldColor.GetHue())
				OnPropertyChanged("Hue");

			if (color.GetSaturation() != oldColor.GetSaturation())
				OnPropertyChanged("Saturation");

			if (color.GetLuminosity() != oldColor.GetLuminosity())
				OnPropertyChanged("Luminosity");
		}
		get {
			return color;
		}
	}
	// [CallerMemberName] ensures that the passed parameter (propertyName) matches
	// the calling method (if not provided).
	protected void OnPropertyChanged([CallerMemberName] string propertyName = "") {
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
	float Round(float value) {
		return (float)Math.Round(value, 2);
	}
}
