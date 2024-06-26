using System;

namespace Learning03
{
    public class Fraction
    {
        private int _numerator;
        private int _denominator;

        public Fraction() // constructor
        {
            _numerator = 1;
            _denominator = 1;
        }

        public Fraction(int numerator) // constructor with 1 parameters
        {
            _numerator = numerator;
            _denominator = 1;
        }

        public Fraction(int numerator, int denominator) // constructor woth 2 parameters
        {
            _numerator = numerator;
            _denominator = denominator;
        }

        public int GetNumerator() // getters
        {
            return _numerator;
        }

        public int GetDenominator() // getters
        {
            return _denominator;
        }

        public void SetNumerator(int value) // setters
        {
            _numerator = value;
        }

        public void SetDenominator(int value) // setters
        {
            if (value != 0)
            {
                _denominator = value;
            }
            
            else
            {
                throw new ArgumentException("The denominator can't be zero");
            }
        }

        public string GetFractionString()
        {
            return $"{_numerator}/{_denominator}";
        }

        public double GetDecimalValue()
        {
            return(double)_numerator / _denominator;
        }

        public override string ToString()
        {
            return GetFractionString();
        }
    }
}
