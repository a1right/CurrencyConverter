using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CurrencyConverter
{
    internal class CurrencyCalculator
    {
        private string _currencyName { get; }
        private string _currencyExchangeName { get; }
        private decimal _currencyAmount { get; }
        private decimal _currencyExchangeAmount { get; set; }
        private readonly List<Currency> _currenciesList;

        public CurrencyCalculator(UserInput userInput, Data currencies )
        {
            _currencyName = userInput.CurrencyName;
            _currencyAmount = userInput.CurrencyAmount;
            _currencyExchangeName = userInput.CurrencyNameConvertTo;
            _currenciesList = currencies.context;
        }

        public decimal GetCurrencyExchangeAmount()
        {
            var currencyEntity = _currenciesList.Where(x => x.CurrencyCharCode.ToLower() == _currencyName.ToLower()).First();
            var currencyExchangeEntity = _currenciesList.Where(x => x.CurrencyCharCode.ToLower() == _currencyExchangeName.ToLower()).First();
            decimal result = (currencyEntity.CurrencyValueInRoubles / currencyEntity.CurrencyNominal * _currencyAmount) /
                             (currencyExchangeEntity.CurrencyValueInRoubles / currencyExchangeEntity.CurrencyNominal);
            return result;
        }
    }
}
