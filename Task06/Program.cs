using System;

/*
Источник: https://docs.microsoft.com/ru-ru/dotnet/csharp/language-reference/operators/operator-overloading

Fraction - упрощенная структура, представляющая рациональное число.
Необходимо перегрузить операции:
+ (бинарный)
- (бинарный)
*
/ (в случае деления на 0, выбрасывать DivideByZeroException)

Тестирование приложения выполняется путем запуска разных наборов тестов, например,
на вход поступает две строки, содержацие числители и знаменатели двух дробей, разделенные /, соответственно.
1/3
1/6
Программа должна вывести на экран сумму, разность, произведение и частное двух дробей, соответственно,
с использованием перегруженных операторов (при необходимости, сокращать дроби):
1/2
1/6
1/18
2

Обратите внимание, если дробь имеет знаменатель 1, то он уничтожается (2/1 => 2). Если дробь в числителе имеет 0, то 
знаменатель также уничтожается (0/3 => 0).
Никаких дополнительных символов выводиться не должно.

Код метода Main можно подвергнуть изменениям, но вывод меняться не должен.
*/

public readonly struct Fraction
{
    private readonly int num;
    private readonly int den;

    public Fraction(int num, int den)
    {
        this.num = num;
        this.den = den;
    }
    public static Fraction Parse(string input)
    {
        string[] data = input.Split('/');
        if (data.Length == 2)
        {
            return new Fraction(int.Parse(data[0]), int.Parse(data[1]));
        }
        return new Fraction(int.Parse(data[0]), 1);
    }
    public static Fraction operator +(Fraction rat1, Fraction rat2)
    {
        int a = rat1.num * rat2.den + rat1.den * rat2.num;
        int b = rat1.den * rat2.den;
        Fraction rat = new Fraction(a / GCD(Math.Abs(a), Math.Abs(b)), b / GCD(Math.Abs(a), Math.Abs(b)));
        return rat;
    }

    public static Fraction operator -(Fraction rat1, Fraction rat2)
    {
        Fraction Fraction = new Fraction(-1 * rat2.num, rat2.den);
        return rat1 + Fraction;
    }

    public static Fraction operator *(Fraction rat1, Fraction rat2)
    {
        int a = rat1.num * rat2.num;
        int b = rat1.den * rat2.den;

        return new Fraction(a / GCD(Math.Abs(a), Math.Abs(b)), b / GCD(Math.Abs(a), Math.Abs(b)));
    }

    public static Fraction operator /(Fraction rat1, Fraction rat2)
    {
        int a = rat1.num * rat2.den;
        int b = rat1.den * rat2.num;
        if (a * b == 0)
        {
            throw new DivideByZeroException();
        }
        if (b < 0)
        {
            a *= -1;
            b *= -1;
        }
        return new Fraction(a / GCD(Math.Abs(a), Math.Abs(b)), b / GCD(Math.Abs(a), Math.Abs(b)));
    }
    public static int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    public override string ToString()
    {
        if (num == 0 || den == 1)
        {
            return num.ToString();
        }
        return $"{num}/{den}";
    }
}

public static class OperatorOverloading
{
    public static void Main()
    {
        try
        {
            Fraction fraction1 = Fraction.Parse(Console.ReadLine());
            Fraction fraction2 = Fraction.Parse(Console.ReadLine());
            Console.WriteLine(fraction1 + fraction2);
            Console.WriteLine(fraction1 - fraction2);
            Console.WriteLine(fraction1 * fraction2);
            Console.WriteLine(fraction1 / fraction2);
        }
        catch (ArgumentException)
        {
            Console.WriteLine("error");
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("zero");
        }
    }
}
