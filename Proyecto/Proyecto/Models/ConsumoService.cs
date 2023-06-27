using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Proyecto.Models
{
    public class ConsumoService
    {
        public string url { get; set; }
        public ConsumoService(string newurl)
        {
            url = newurl;
        }
        public async Task<T> Get<T>(){

            try
            {
                HttpClient cliente = new HttpClient();
                var response = await cliente.GetAsync(url);

                if (response.StatusCode == System.Net.HttpStatusCode.OK && response != null)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonString);
                }
            }
             
            catch
            {
                Application.Current.MainPage.DisplayAlert("Error", "Error al consumir web service", "Cancelar");
            }

            return default(T);

        }

        public async Task<T> PostAsync<T>(Object obj)
        {

            try
            {
                HttpClient cliente = new HttpClient();

                string jsonData = JsonConvert.SerializeObject(obj);
                var formData = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonData);
                var content = new FormUrlEncodedContent(formData);
                //var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var response = await cliente.PostAsync(url, content);

                if (response.StatusCode == System.Net.HttpStatusCode.OK && response != null)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonString);
                }
            }
            catch
            {
                Application.Current.MainPage.DisplayAlert("Error", "Error al consumir web service", "Cancelar");

            }


            return default(T);
        }

        internal Task Get<T>(string nombreUser)
        {
            throw new NotImplementedException();
        }
    }
}
