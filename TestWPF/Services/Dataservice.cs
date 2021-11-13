using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using TestWPFApp.Model;

namespace TestWPFApp.Services
{
    internal class DataService
    {
        private const string _dataSourceAddress = @"https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/csse_covid_19_time_series/time_series_covid19_confirmed_global.csv";
        public IEnumerable<CountryInfo> GetData()
        {
            var dates = GetDates();
            var data = GetCountriesData().GroupBy(x=>x.Country);
            foreach (var item in data)
            {
                var country = new CountryInfo()
                {
                    Name = item.Key,
                    
                    ProvinceCount = item.Select(c => new PlaceInfo()
                    {
                        Name = c.Province,
                        Locatoin = c.Point,
                        InfectedCounts = dates.Zip(c.Counts, (data, counts) => new ConfimedCount { Date = data, Count = counts }),

                    }),
                    
                };
                //var avgLatitude = item.Average(x => x.Point.X);
                //var avgLongitude = item.Average(y => y.Point.Y);
                //var avgLocation = new Point(avgLatitude, avgLongitude);
                //country.Locatoin = avgLocation;

                yield return country;
            }
        }
        /// <summary>
        /// Получает ответ от сервера в виде потока
        /// </summary>
        /// <returns></returns>
        private static  async Task<Stream> GetDataStream()
        {
            var client = new HttpClient();
            var respond = await client.GetAsync(_dataSourceAddress, HttpCompletionOption.ResponseHeadersRead);
            return await respond.Content.ReadAsStreamAsync();
        }
        /// <summary>
        /// Разбирает ответ сервера и возвращает построчно 
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<string> GetDataLines()
        {

            using var data_stream = (SynchronizationContext.Current is null) ? GetDataStream().Result : Task.Run(() => GetDataStream()).Result;
           

            
            using var data_reader = new StreamReader(data_stream);
            while (!data_reader.EndOfStream)
            {
                var line = data_reader.ReadLine();
                if (string.IsNullOrWhiteSpace(line)) continue;
                yield return line.Replace("Korea,", "Korea -")
                    .Replace("Bonaire,", "Bonaire-")
                    .Replace("Saint Helena,", "Saint Helena- ");
            }

        }
        /// <summary>
        /// Получает даты из на которые разбиты данные
        /// </summary>
        /// <returns></returns>
        private static DateTime[] GetDates()
        {
            var datalines = GetDataLines();
                var datetime= datalines
                                .First()
                                .Split(',')
                                .Skip(4)
                                .Select(x => DateTime.Parse(x, CultureInfo.InvariantCulture))
                                .ToArray();
            return datetime;
        }
        /// <summary>
        /// Разбивает данные на страну провинцию и [] зараженных
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<(string Province, string Country, Point Point, int [] Counts)> GetCountriesData()
        {
            var lines = GetDataLines()
                        .Skip(1)
                        .Select(line => line.Split(','));
            foreach (var row in lines)
            {
                var province = row[0].Trim();
                var countryName = row[1].Trim(' ', '"');
                Point point; 
                try
                {
                    var latitude = double.Parse(string.IsNullOrWhiteSpace(row[2]) ? "0" : row[2], CultureInfo.InvariantCulture);
                    var longitude = double.Parse(string.IsNullOrWhiteSpace(row[3]) ? "0" : row[3], CultureInfo.InvariantCulture);
                    point = new Point(latitude, longitude);
                    
                  
                }
                catch (Exception e)
                {

                    throw new ArgumentException(row[2].ToString());
                }
                var count = row.Skip(4).Select(int.Parse).ToArray();

                yield return (province, countryName, point, count);

            }

        }
    }
}
