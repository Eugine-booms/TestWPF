using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace TestWPFConsole
{
    class Program
    {
        const string data_url = @"https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/csse_covid_19_time_series/time_series_covid19_confirmed_global.csv";
        /// <summary>
        /// Получает ответ от сервера в виде потока
        /// </summary>
        /// <returns></returns>
        private static async Task<Stream> GetDataStream()
        {
            var client = new HttpClient();
            var respond = await client.GetAsync(data_url, HttpCompletionOption.ResponseHeadersRead);
            return await respond.Content.ReadAsStreamAsync();
        }
        /// <summary>
        /// Разбирает ответ сервера и возвращает построчно 
        /// </summary>
        /// <returns></returns>
        private static IEnumerable <string> GetDataLines()
        {
            using var data_stream =  GetDataStream().Result;
            using var data_reader = new StreamReader(data_stream);
            while (!data_reader.EndOfStream)
            {
                var line = data_reader.ReadLine();
                if (string.IsNullOrWhiteSpace(line)) continue;
                yield return line.Replace("Korea,", "Korea -").Replace("Bonaire,", "Bonaire-");
            }

        }
        /// <summary>
        /// Получает даты из на которые разбиты данные
        /// </summary>
        /// <returns></returns>
        private static DateTime[] GetDates() => GetDataLines()
            .First()
            .Split(',')
            .Skip(4)
            .Select(x=> DateTime.Parse(x, CultureInfo.InvariantCulture))
            .ToArray();
        /// <summary>
        /// Разбивает данные на страну провинцию и [] зараженных
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<(string Country, string Province, int[] Count)> GetData()
        {
            var lines = GetDataLines()
                .Skip(1)
                .Select(line => line.Split(','));
            foreach (var row in lines)
            {
                var province = row[0].Trim();
                var countryName = row[1].Trim(' ', '"');
                var stringToCount = row.Skip(4);
                var count = row.Skip(4).Select(int.Parse).ToArray();

                yield return (countryName, province, count);
            }

        }
         static void Main(string[] args)
        {
            // WebClient client = new WebClient();

            //var client = new HttpClient();
            //var responseMessage = client.GetAsync(data_url).Result;
            //var csv_str = responseMessage.Content.ReadAsStringAsync().Result;
            //foreach (var item in GetDates())
            //{
            //    Console.WriteLine(item);
            //}
            
            var russia_data = GetData()
                .First(v => v.Country.Equals("Russia", StringComparison.OrdinalIgnoreCase));
            Console.WriteLine(string.Join("\r\n", GetDates().Zip(russia_data.Count, (date, count)=> $"{date:yyyy-MM.dd} - {count}")));
            Console.ReadLine();
            Console.WriteLine("Hello World!");
        }
    }
}
