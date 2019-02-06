using Marchand.Model.Ws;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Marchand.Services.Configuration
{
 public class ConfigRequest
    {
        public static List<KeyValuePair<string, string>> GetWsBasicAuthenticationHeaders()
        {

            var keyAuthenticationCloud = HttpRequestHeader.Authorization.ToString();
            var valueAuthenticationCloud = "Basic " + Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(string.Format("{0}:{1}",
                Constantes.Usuario, Constantes.Password)));

            return new List<KeyValuePair<string, string>>()
                    {
                           new KeyValuePair<string, string>(keyAuthenticationCloud, valueAuthenticationCloud)
                    };


        }

    }
}
