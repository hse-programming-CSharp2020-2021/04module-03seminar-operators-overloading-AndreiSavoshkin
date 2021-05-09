using System;
using System.Globalization;

/*
Источник: https://metanit.com/

Класс Celcius представляет градусник по Цельсию, а Fahrenheit - градусник по Фаренгейту.
Определите операторы преобразования от типа Celcius и наоборот.
Преобразование температуры по шкале Фаренгейта (Tf) в температуру по шкале Цельсия (Tc): Tc = 5/9 * (Tf - 32).
Преобразование температуры по шкале Цельсия в температуру по шкале Фаренгейта: Tf = 9/5 * Tc + 32.

Тестирование приложения выполняется путем запуска разных наборов тестов, например,
на вход поступает две строки - количество градусов в Фаренгейтах и количество градусов в Цельсиях.
50
50
Программа должна вывести на экран число градусов в Цельсиях и Фаренгейтах, соответственно
с использованием перегруженных операторов (округлять до 2 знаков после запятой):
10,00
122,00

Никаких дополнительных символов выводиться не должно.

Код метода Main можно подвергнуть изменениям, но вывод меняться не должен.
*/

namespace Task04
{
    class Celcius
    {
        public double Gradus { get; set; }
        public static explicit operator Fahrenheit(Celcius celcius)
        {
            return new Fahrenheit() { Gradus = celcius.Gradus * 9 / 5 + 32 };
        }
        public override string ToString()
        {
            return Gradus.ToString("f2");
        }
    }

    class Fahrenheit
    {
        public double Gradus { get; set; }
        public static explicit operator Celcius(Fahrenheit fahrenheit)
        {
            return new Celcius() { Gradus = (fahrenheit.Gradus - 32) * 5 / 9 };
        }
        public override string ToString()
        {
            return Gradus.ToString("f2");
        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            Fahrenheit fahrenheit = new Fahrenheit() { Gradus = int.Parse(Console.ReadLine()) };
            Celcius celcius = new Celcius() { Gradus = int.Parse(Console.ReadLine()) };
            Console.WriteLine((Celcius)fahrenheit);
            Console.WriteLine((Fahrenheit)celcius);
        }
    }
}
