class Fraction
{
    private int numerator;

    private int denumerator;

    public int Denumerator => denumerator;

    private int Numerator => numerator;

    public double DecimalForm => (double) numerator / denumerator;

    public Fraction(int numerator, int denumerator) {
        if (denumerator == 0) {
            throw new ArgumentException("denumerator canno`t be equal a zero");
        }

        this.numerator = numerator;
        this.denumerator = denumerator;
    }

    public static Fraction operator+(Fraction left, Fraction right)
    {
        int lcm = Math.lcm(left.denumerator, right.denumerator);
        int denumeratorLeft = lcm / left.denumerator;
        int denumeratorRight = lcm / right.denumerator;
    
        return new Fraction(left.numerator*denumeratorLeft + right.numerator*denumeratorRight, lcm);
    }

    public static Fraction operator-(Fraction left, Fraction right)
    {
        int lcm = Math.lcm(left.denumerator, right.denumerator);
        int denumeratorLeft = lcm / left.denumerator;
        int denumeratorRight = lcm / right.denumerator;
    
        return new Fraction(left.numerator*denumeratorLeft - right.numerator*denumeratorRight, lcm);
    }

    public static Fraction operator*(Fraction left, Fraction right)
    {
        return new Fraction(left.numerator*right.numerator, left.denumerator*right.denumerator);
    }

    public static Fraction operator/(Fraction left, Fraction right)
    {
        return left * new Fraction(right.denumerator, right.numerator);
    }

    public Fraction Simplyfy()
    {
        int gcd = Math.gcd(numerator, denumerator);

        numerator /= gcd;
        denumerator /= gcd;

        return this;
    }

    public override string ToString()
    {
        return $"numerator: {numerator}; denumerator: {denumerator}";
    }
}

class Math
{
    public static int gcd(int a, int b)
    {
        while (a > 0 && b > 0)
        {
            if (a >= b)
                a %= b;
            else
                b %= a;
        }

        return System.Math.Max(a, b);
    }

    public static int lcm(int a, int b)
    {
        return a * b / gcd(a,b);
    }   
}
