using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MVVM.ViewModels;
public class SimpleMultiplierViewModel : INotifyPropertyChanged {
	double multiplicand, multiplier, product;
	int first, second, sum;

	public event PropertyChangedEventHandler PropertyChanged;

	public SimpleMultiplierViewModel() {
		Multiplicand = 0.5;
		Multiplier = 0.5;
		First = 2;
		Second = 2;
	}
	public double Multiplicand {
		set {
			if (multiplicand != value) {
				multiplicand = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Multiplicand"));
				UpdateProduct();
			}
		}
		get {
			return multiplicand;
		}
	}
	public double Multiplier {
		set {
			if (multiplier != value) {
				multiplier = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Multiplier"));
				UpdateProduct();
			}
		}
		get {
			return multiplier;
		}
	}

	public double Product {
		protected set {
			if (product != value) {
				product = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Product"));
			}
		}
		get {
			return product;
		}
	}

	public int First
	{
		set
		{
			if (first != value)
			{
				first = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("First"));
				UpdateSum();
			}
		}
		get {
			return first;
		}
	}

    public int Second
    {
        set
        {
            if (second != value)
            {
                second = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Second"));
                UpdateSum();
            }
        }
        get
        {
            return second;
        }
    }

    public int Sum
    {
        protected set
        {
            if (sum != value)
            {
                sum = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Sum"));
            }
        }
        get
        {
            return sum;
        }
    }
    void UpdateProduct() {
		Product = Multiplicand * Multiplier;
	}

    void UpdateSum()
    {
        Sum = First + Second;
    }
}