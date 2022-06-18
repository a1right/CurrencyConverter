namespace CurrencyConverter
{
    internal class Data
    {
        public readonly List<Currency> context;
        public Data(List<Currency> currencies)
        {
            Currency RUB = new Currency();
            RUB.CurrencyCharCode = "RUB";
            RUB.CurrencyName = "Российский рубль";
            RUB.CurrencyValueInRoubles = 1;
            RUB.CurrencyNominal = 1;
            currencies.Insert(0,RUB);
            context = currencies;
        }

        public void PrintAllCurrenciesCharCodes()
        {
            foreach (var currency in context)
            {
                Console.WriteLine($"Код валюты: ({currency.CurrencyCharCode})\t\tПолное название валюты : {currency.CurrencyName}");
            }
        }
    }

    
}
