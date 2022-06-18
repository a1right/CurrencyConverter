using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Globalization;

namespace CurrencyConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            CultureInfo culture = new CultureInfo("ru-Ru");

            FileDownloader fileDownloader = new FileDownloader();
            
            if (fileDownloader.TryDownloadXml(fileDownloader.uriAdress, fileDownloader.filePath))
            {
                Caching cachedXml = new Caching();
                cachedXml.CacheFile(fileDownloader.filePath);
                XmlParser xmlParser = new XmlParser();
                Data currencies = new Data(xmlParser.ParseCurrenciesToList(cachedXml));
                cachedXml.Dispose();
                while (true)
                {
                    UserInput userInput = new UserInput(currencies);
                    currencies.PrintAllCurrenciesCharCodes();
                    userInput.GetCurrencyNameInput();
                    userInput.GetCurrencyAmount();
                    userInput.GetCurrencyNameConvertToInput();
                    CurrencyCalculator calculator = new CurrencyCalculator(userInput, currencies);
                    userInput.CurrencyExchangeAmount = calculator.GetCurrencyExchangeAmount();
                    userInput.PrintResult();
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}