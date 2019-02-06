using Marchand.Model;
using Marchand.Model.Ws;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using static Marchand.Model.Ws.Constants;

namespace Marchand.Services
{
    public class ApiHelper
    {
        #region Constants
        const string API_URL = "http://157.230.133.235:65022";
        const string BASIC_AUTO = "Basic Y2xpZW50ZXdlYjptYXJjaGFuZA==";
        #endregion

        #region Members
        private string access_token;
        #endregion

        #region Properties
        public string Access_token { get => access_token; set => access_token = value; }
        HttpWebRequest request;

        #endregion

        #region Ctor
        public ApiHelper(eUrlApi urlApi, eMethod method)
        {
            request = WebRequest.Create(string.Concat(API_URL,  Constants.GetEnumDescription(urlApi))) as HttpWebRequest;
            request.Method = method.ToString();
        }
        public void AddContentType(eContentType contentType) => request.ContentType = Constants.GetEnumDescription(contentType);
        public void IncludeBasicAuto() => request.Headers.Add("Authorization", BASIC_AUTO);
        public void IncludeBarerToken(string access_token) => request.Headers.Add("Authorization", $"Bearer {access_token}");
        public void AddHeader(string key, string value) => request.Headers.Add(key, value);
        public void AddBody(List<Tuple<string, string>> bodyContent)
        {
            var bodyString = string.Empty;
            foreach (var b in bodyContent)
                bodyString += $"{b.Item1}={b.Item2}&";
            ASCIIEncoding encoder = new ASCIIEncoding();
            byte[] byte1 = encoder.GetBytes(bodyString.Substring(0,bodyString.Length - 1));
            request.ContentLength = byte1.Length;
            Stream newStream = request.GetRequestStream();
            newStream.Write(byte1, 0, byte1.Length);
            newStream.Close();
        }

        public void AddBody(Ubicacion ubicacion)
        {
            JsonConvert.DefaultSettings().ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            var bodyString = JsonConvert.SerializeObject(ubicacion);
            ASCIIEncoding encoder = new ASCIIEncoding();
            byte[] byte1 = encoder.GetBytes(bodyString);
            request.ContentLength = byte1.Length;
            Stream newStream = request.GetRequestStream();
            newStream.Write(byte1, 0, byte1.Length);
            newStream.Close();
        }
        public BaseResponse Execute()
        {
            var response = new BaseResponse();
            try
            {
                WebResponse wrep = request.GetResponse();
                string result;
                using (var reader = new StreamReader(wrep.GetResponseStream()))
                {
                    result = reader.ReadToEnd(); 
                }
                if (result != null)
                {
                    response.JsonResult = result;
                    response.SetDefaulSuccess();
                }
                else
                    response.SetDefaulFailure();
            }
            catch
            {
                response.SetDefaulError();
            }
            return response;
        }
        #endregion

        #region ActionHandler
        
        #endregion

        #region Internal

        #endregion
    }
}