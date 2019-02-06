using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Marchand.Services.Configuration
{
  public  class ConfigurationManager
    {

        #region consumo de servicios tipo Header
        public async Task<string> LoginMainpage (string email_, string pass_)
        {
            try
            {
                Uri geturi = new Uri(""); //replace your xml url 
                HttpClient clien = new HttpClient();
                clien.BaseAddress = new Uri(geturi.ToString());
                //Accept headers
                clien.DefaultRequestHeaders.Accept
                      .Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Authorization headers for user
                clien.DefaultRequestHeaders.Add("", email_);// tnsClient);
                clien.DefaultRequestHeaders.Add("", pass_);

                //Authorization headers for consume WS
                var wsCredentials = ConfigRequest.GetWsBasicAuthenticationHeaders();
                foreach (var header in wsCredentials)
                {
                    clien.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
                HttpResponseMessage responseGet = await clien.GetAsync(geturi);


                return responseGet.ToString();

            }
            catch (Exception ex)
            {
                var error= ex.ToString();

                return error;

            }
        }

        //public class ConfigRequest
        //{

        //    public static List<KeyValuePair<string, string>> GetWsBasicAuthenticationHeaders()
        //    {

        //        var keyAuthenticationCloud = HttpRequestHeader.Authorization.ToString();
        //        var valueAuthenticationCloud = "Basic " + Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(string.Format("{0}:{1}",
        //            Constantes.Usuario, Constantes.Password)));

        //        return new List<KeyValuePair<string, string>>()
        //            {
        //                   new KeyValuePair<string, string>(keyAuthenticationCloud, valueAuthenticationCloud)
        //            };


        //    }

        //}
        #endregion fin del consumo
    }
}
