using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{

    internal class UserInput
    {
        public UserInput(Data data)
        {
            _context = data._context;
        }
        public string CurrencyName { get; set; }
        public string CurrencyNameConvertTo { get; set; }

        public decimal CurrencyAmount { get; set; }

        public decimal CurrencyExchangeAmount { get; set; }

        public readonly List<Currency> _context;

        public bool CheckCurrencyNameInList(string input)
        {
            try
            {
                var result = _context.Where(x => x.CurrencyCharCode.ToLower() == input.ToLower()).First();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Такой валюты нет в списке");
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

    }

    static class UserInputExtensions
    {
       
        public static void GetCurrencyNameInput(this UserInput userInput)
        {
            bool correctInput = false;
            string input = String.Empty;
            Console.WriteLine("Введите код валюты");
            while (!correctInput)
            {
                input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input) && userInput.CheckCurrencyNameInList(input))
                {
                    correctInput = true;
                    break;
                }
                Console.WriteLine("Введите код валюты из списка");
            }
            userInput.CurrencyName = input;
        }

        public static void GetCurrencyNameConvertToInput(this UserInput userInput)
        {
            bool correctInput = false;
            string input = String.Empty;
            Console.WriteLine("Введите код валюты");
            while (!correctInput)
            {
                input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input) && userInput.CheckCurrencyNameInList(input))
                {
                    correctInput = true;
                    break;
                }
                Console.WriteLine("Введите валюту из списка");
            }
            userInput.CurrencyNameConvertTo = input;
        }

        public static void GetCurrencyAmount(this UserInput userInput)
        {
            CultureInfo culture = new CultureInfo("ru-Ru");
            string input = String.Empty;
            Console.WriteLine("Введите количество конвертируемой валюты");
            bool correctInput = false;
            while (!correctInput)
            {
                input = Console.ReadLine();
                if (decimal.TryParse(input, System.Globalization.NumberStyles.AllowDecimalPoint, CultureInfo.CurrentCulture, out decimal res))
                    break;
                Console.WriteLine("Введите число в корректном формате");
            }
            decimal.TryParse(input, System.Globalization.NumberStyles.Currency, culture, out decimal result);
            userInput.CurrencyAmount = result;
        }

        public static void PrintResult(this UserInput userInput)
        {
            Console.WriteLine($"Результат обмена:\n{userInput.CurrencyAmount} {userInput.CurrencyName} = {userInput.CurrencyNameConvertTo} {userInput.CurrencyExchangeAmount}");
        }
    }
}
