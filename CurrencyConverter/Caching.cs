using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    public class Caching : IDisposable
    {
        public MemoryStream cachedStream { get; private set; }

        internal void CacheFile(string fileName)
        {
            cachedStream = new MemoryStream(File.ReadAllBytes(fileName));
        }

        public void Dispose()
        {
            cachedStream.Dispose();
        }

       
    }
}
