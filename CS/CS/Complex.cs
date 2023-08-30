using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS;
public class ComplexNumber {
    private double r, i;
    public ComplexNumber() : this(0, 0) {
    }
    public ComplexNumber(double real, double imag) {
        r = real;
        i = imag;
    }
    public override string ToString() {
        if (i < 0) {
            return string.Format("({0}{1}i)", r, i);
        } else {
            return string.Format("({0}+{1}i)", r, i);
        }
    }
    public double Real {
        get {
            return r;
        }
        set {
            r = value;
        }
    }
    public double Imaginary {
        get {
            return i;
        }
        set {
            i = value;
        }
    }
    public static void ComplexMain() {
        ComplexNumber c1 = new ComplexNumber();
        ComplexNumber c2 = new ComplexNumber(2, 3);
        ComplexNumber c3 = new ComplexNumber {
                                Real = 45,
                                Imaginary = 22
                            };
        Console.WriteLine(c1);
        Console.WriteLine(c2);
        Console.WriteLine(c3);
    }
}