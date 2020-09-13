using NasaInfoViewer.Interfaces;
using NasaInfoViewer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NasaInfoViewer.Helpers
{
    public class ApiHelper : IApiHelper
    {
        string apiKey = "2vl8sQKyxeTqY8zsmaEXhYc12rVkDJkIxwQJNiz9";
        public async Task<List<imageDaily.MyArray>> getImages4LastDays(string fechaHoy, int cantidadDiasAtras)
        {
            List<imageDaily.MyArray> ImagenDiaria = new List<imageDaily.MyArray>();
            try
            {

                using (var httpclient = new HttpClient())
                {
                    using (var response = httpclient.GetAsync($"https://api.nasa.gov/planetary/apod?api_key=" + apiKey + "&start_date=" + Convert.ToDateTime(fechaHoy).AddDays(-cantidadDiasAtras).ToString("yyyy-MM-dd") + "&end_date=" + fechaHoy))
                    {
                            string jsonResponse = await response.Result.Content.ReadAsStringAsync();
                            ImagenDiaria = JsonConvert.DeserializeObject<List<imageDaily.MyArray>>(jsonResponse);
                       
                    }
                }
               

                return ImagenDiaria;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}

