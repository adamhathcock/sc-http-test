using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using SharpCompress.Readers;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            Test().Wait();
        }

        public static async Task Test()
        {
            using(var client = new HttpClient())
            using (var response = await client.GetAsync("https://github.com/adamhathcock/sharpcompress/raw/master/tests/TestArchives/Archives/Tar.tar",
                    HttpCompletionOption.ResponseHeadersRead))
            {
                using(var stream = await response.Content.ReadAsStreamAsync())
                using (var reader = ReaderFactory.Open(stream))
                {
                    reader.MoveToNextEntry();
                    reader.WriteEntryTo(new MemoryStream());  //System
                }
            }
        }
    }
}
