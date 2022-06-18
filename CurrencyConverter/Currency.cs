using System;


namespace CurrencyConverter
{
    internal class Currency
    {
        public int Id { get; set; }

        public string CurrencyNumCode { get; set; }

        public string CurrencyCharCode { get; set; }

        public int CurrencyNominal { get; set; }

        public string CurrencyName { get; set; }

        public decimal CurrencyValueInRoubles { get; set; }


    }
}
