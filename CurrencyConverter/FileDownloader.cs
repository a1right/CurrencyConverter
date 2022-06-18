using System.Net;

namespace CurrencyConverter
{
    internal class FileDownloader
    {
        public readonly string filePath = "./currency.xml";
        public readonly string uriAdress = "http://www.cbr.ru/scripts/XML_daily.asp";
        private int _reconnectTries;
        private WebClient webClient = new WebClient();
        private WebClient _webClient;

        public FileDownloader ()
        {
            _reconnectTries = 5;
            _webClient = webClient;
        }

        private int ReconnectTries { get; set; }

        

        public bool TryDownloadXml(string _uriAdress, string _filePath)
        {
            bool downloadSuccsess = false;
            while (!downloadSuccsess)
            {
                if (_reconnectTries <= 0)
                {
                    Console.WriteLine("Ошибка сервер недоступен, попробуйте позже");
                    return downloadSuccsess;
                }

                try
                {
                    _webClient.DownloadFile(_uriAdress, _filePath);
                    downloadSuccsess = true;
                    return downloadSuccsess;
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"{exception.Message}");
                    Console.WriteLine($"Невозможно установить соединение. Осталось попыток переподключения {_reconnectTries}");
                    _reconnectTries -= 1;
                    Thread.Sleep(2000);
                }
            }
            return downloadSuccsess;
        }
    }
}