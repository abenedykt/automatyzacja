using System;

namespace Automatyzacja2017
{
    public class Mathematics
    {
        public double Add(double x, double y)
        {
            return x + y;
        }

        public double Substract(double x, double y)
        {
            return x - y;
        }

        public double Multiply(double x, double y)
        {
            return x * y;
        }

        public double Divide(double x, double y)
        {
            return x / y;
        }

        public double Divide2(double x, double y)
        {
            if (y == 0) throw new DivideByZeroException();
            return x / y;
        }

    }
}
