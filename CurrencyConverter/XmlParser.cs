using System.Globalization;
using System.Xml.Linq;

namespace CurrencyConverter
{
    internal class XmlParser
    {
        public string xmlData { get; set; }


        public List<Currency> ParseCurrenciesToList (Caching data)
        {
            List<Currency> currencyList = new List<Currency>();
            XDocument xmlData = XDocument.Load(data.cachedStream);
            foreach (XElement element in xmlData.Element("ValCurs").Elements())
            {
                var currency = new Currency();
                currency.CurrencyName = element.Element("Name").Value;
                currency.CurrencyNumCode = element.Element("NumCode").Value;
                currency.CurrencyCharCode = element.Element("CharCode").Value;
                currency.CurrencyNominal = int.Parse(element.Element("Nominal").Value);
                currency.CurrencyValueInRoubles = decimal.Parse(element.Element("Value").Value, NumberStyles.Currency, CultureInfo.CurrentCulture);
                currencyList.Add(currency);
            }
            return currencyList;
        }
    }

}
