using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MVVM.ViewModels;


public class AdderViewModel : INotifyPropertyChanged {
	string currentEntry = "0";
	string historyString = "";
	bool isSumDisplayed = false;
	double accumulatedSum = 0;
	int factorial = 0;

	public event PropertyChangedEventHandler PropertyChanged;
	public AdderViewModel() {
		ClearCommand = new Command(
			execute: () => {
				HistoryString = "";
				accumulatedSum = 0;
				CurrentEntry = "0";
				isSumDisplayed = false;
				RefreshCanExecutes();
			});

		ClearEntryCommand = new Command(
			execute: () => {
				CurrentEntry = "0";
				isSumDisplayed = false;
				RefreshCanExecutes();
			});

		BackspaceCommand = new Command(
			execute: () => {
				CurrentEntry = CurrentEntry.Substring(0, CurrentEntry.Length - 1);

				if (CurrentEntry.Length == 0) {
					CurrentEntry = "0";
				}

				RefreshCanExecutes();
			},
			canExecute: () => {
				return !isSumDisplayed && (CurrentEntry.Length > 1 || CurrentEntry[0] != '0');
			});

		NumericCommand = new Command<string>(
			execute: (string parameter) => {
				if (isSumDisplayed || CurrentEntry == "0")
					CurrentEntry = parameter;
				else
					CurrentEntry += parameter;

				isSumDisplayed = false;
				RefreshCanExecutes();
			},
			canExecute: (string parameter) => {
				return isSumDisplayed || CurrentEntry.Length < 16;
			});

		DecimalPointCommand = new Command(
			execute: () => {
				if (isSumDisplayed)
					CurrentEntry = "0.";
				else
					CurrentEntry += ".";

				isSumDisplayed = false;
				RefreshCanExecutes();
			},
			canExecute: () => {
				return isSumDisplayed || !CurrentEntry.Contains(".");
			});

		AddCommand = new Command(
			execute: () => {
				double value = Double.Parse(CurrentEntry);
				HistoryString += value.ToString() + " + ";
				accumulatedSum += value;
				CurrentEntry = accumulatedSum.ToString();
				isSumDisplayed = true;
				RefreshCanExecutes();
			},
			canExecute: () => {
				return !isSumDisplayed;
			});
		PlusMinusCommand = new Command(
			execute: () => {
				double v = -Double.Parse(CurrentEntry);
				CurrentEntry = v.ToString();
				RefreshCanExecutes();
			});
        FactCommand = new Command(
            execute: () => {
				int value;
				if(int.TryParse(CurrentEntry, out value) && value >= 0){
					long result = computeFactorial(value);
                    CurrentEntry = result.ToString();
                    HistoryString = value.ToString() + "! ";
                }
                RefreshCanExecutes();
            },
            canExecute: () => {
				int value;
                return int.TryParse(CurrentEntry, out value) && value >= 0 && !isSumDisplayed;
            });
    }
	int computeFactorial(int val)
	{
		if (val == 0) return 1;
		return val * computeFactorial(val - 1);
	}
	void RefreshCanExecutes() {
		((Command)BackspaceCommand).ChangeCanExecute();
		((Command)NumericCommand).ChangeCanExecute();
		((Command)DecimalPointCommand).ChangeCanExecute();
		((Command)AddCommand).ChangeCanExecute();
        ((Command)FactCommand).ChangeCanExecute();
    }
	public string CurrentEntry {
		private set { SetProperty(ref currentEntry, value); }
		get { return currentEntry; }
	}
	public string HistoryString {
		private set { SetProperty(ref historyString, value); }
		get { return historyString; }
	}
	public ICommand ClearCommand { private set; get; }
	public ICommand ClearEntryCommand { private set; get; }
	public ICommand BackspaceCommand { private set; get; }
	public ICommand NumericCommand { private set; get; }
	public ICommand PlusMinusCommand { private set; get; }
	public ICommand DecimalPointCommand { private set; get; }
	public ICommand FactCommand { private set; get; }
	public ICommand AddCommand { private set; get; }
	public void SaveState(IDictionary<string, object> dictionary) {
		dictionary["CurrentEntry"] = CurrentEntry;
		dictionary["HistoryString"] = HistoryString;
		dictionary["isSumDisplayed"] = isSumDisplayed;
		dictionary["accumulatedSum"] = accumulatedSum;
	}
	public void RestoreState(IDictionary<string, object> dictionary) {
		CurrentEntry = GetDictionaryEntry(dictionary, "CurrentEntry", "0");
		HistoryString = GetDictionaryEntry(dictionary, "HistoryString", "");
		isSumDisplayed = GetDictionaryEntry(dictionary, "isSumDisplayed", false);
		accumulatedSum = GetDictionaryEntry(dictionary, "accumulatedSum", 0.0);

		RefreshCanExecutes();
	}
	protected bool SetProperty<T>(ref T storage, T value,
							  [CallerMemberName] string propertyName = null) {
		if (Object.Equals(storage, value))
			return false;

		storage = value;
		OnPropertyChanged(propertyName);
		return true;
	}
	protected void OnPropertyChanged([CallerMemberName] string propertyName = null) {
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
	public T GetDictionaryEntry<T>(IDictionary<string, object> dictionary,
									string key, T defaultValue) {
		if (dictionary.ContainsKey(key))
			return (T)dictionary[key];

		return defaultValue;
	}
}
