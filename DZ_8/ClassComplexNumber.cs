using System;
namespace DZ_8;

public class Complex
{
    public double Real { get; private set; }
    public double Imaginary { get; private set; }



    public Complex(double real, double imaginary)
    {
        Real = real;
        Imaginary = imaginary;
    }

    public Complex Plus(Complex number)
    {
        return new Complex(this.Real + number.Real, this.Imaginary + number.Imaginary);
    }


    public Complex Minus(Complex number)
    {
        return new Complex(this.Real - number.Real, this.Imaginary - number.Imaginary);
    }

}
