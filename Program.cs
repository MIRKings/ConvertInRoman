using System;
using System.Collections.Generic;
using System.Linq;

namespace ConvertInTo
{
    class Program
    {
        static Dictionary<int, string> ra = new Dictionary<int, string>
        { { 1000, "M" },  { 900, "CM" },  { 500, "D" },  { 400, "CD" },  { 100, "C" },
                          { 90 , "XC" },  { 50 , "L" },  { 40 , "XL" },  { 10 , "X" },
                          { 9  , "IX" },  { 5  , "V" },  { 4  , "IV" },  { 1  , "I" } };
    
        static void Main(string[] args)
        {
            Console.Write("Выберите вариант перевода: \n" +
                "1. Арабские цифры в Римские.\n" +
                "2. Римские цифры в Арабские.\n " +
                "Ответ: ");
            int vvod = Convert.ToByte(Console.ReadLine());
            
            if (vvod == 1 )
            {
                Console.Write("Введите Арабские цифры для конвертации: ");
                int n = Convert.ToInt32(Console.ReadLine()); // вводим число с консоли
                ToRoman(n);
                Console.WriteLine("Число в Римской системе счисления = " + ToRoman(n));
                
            }   
            else if (vvod == 2)
            {
                Console.Write("Введите Римские цифры для конвертации: ");
                string romanNumeral = Console.ReadLine(); //считываем строку
                FromRoman(romanNumeral);

                Console.WriteLine("Число в Арабской системе счисления = " + FromRoman(romanNumeral));
            }
            else Console.WriteLine("Выберите верный ответ, данный ответ не соответсвует требованиям");
        }

        public static string ToRoman(int n) => ra
            .Where(d => n >= d.Key)
            .Select(d => d.Value + ToRoman(n - d.Key))
            .FirstOrDefault();

        public static int FromRoman(string romanNumeral) => romanNumeral.Length == 0 ? 0 : ra
           .Where(d => romanNumeral.StartsWith(d.Value))
           .Select(d => d.Key + FromRoman(romanNumeral.Substring(d.Value.Length)))
           .First(); 
    }
}
