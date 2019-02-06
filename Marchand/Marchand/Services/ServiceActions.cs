using Marchand.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using static Marchand.Model.Ws.Constants;

namespace Marchand.Services
{
    public class ServiceActions
    {
        ApiHelper apiHelper;

        #region ActionHandler
        public Token DoLogin(string username, string password, bool isRefresh = false)
        {
            var token = new Token();
            try
            {
                apiHelper = new ApiHelper(eUrlApi.Login, eMethod.POST);
                apiHelper.AddContentType(eContentType.UrlEncoded);
                apiHelper.IncludeBasicAuto();
                apiHelper.AddBody(new List<Tuple<string, string>> {
                    new Tuple<string, string>("grant_type","password"),
                    new Tuple<string, string>("username", username),
                    new Tuple<string, string>("password", password)});
                var result = apiHelper.Execute();
                if (result.Success)
                {
                    token = JsonConvert.DeserializeObject<Token>(result.JsonResult);
                    if (!string.IsNullOrEmpty(token.Access_token))
                        token.SetDefaulSuccess();
                    else
                        token.SetDefaulFailure();
                }
                else
                    token.SetDefaulFailure();
            }
            catch
            {
                token.SetDefaulError();
            }
            return token;
        }
        public Bitacora GetJornada(string access_token)
        {
            var jornada = new Bitacora();
            try
            {
                apiHelper = new ApiHelper(eUrlApi.Bitacora, eMethod.POST);
                apiHelper.IncludeBarerToken(access_token);
                apiHelper.AddContentType(eContentType.Json);
                var result = apiHelper.Execute();
                if (result.Success)
                {
                    jornada = JsonConvert.DeserializeObject<Bitacora>(result.JsonResult);
                    if (jornada.jornada != null)
                        jornada.SetDefaulSuccess();
                    else
                        jornada.SetDefaulFailure();
                }
                else
                    jornada.SetDefaulFailure();
            }
            catch (Exception)
            {
                jornada.SetDefaulError();
            }
            return jornada;
        }
        public BaseResponse UpdateLocation(string access_token, string latitud, string longitud)
        {
            var response = new BaseResponse();
            try
            {
                apiHelper = new ApiHelper(eUrlApi.Ubicacion, eMethod.POST);
                apiHelper.AddContentType(eContentType.Json);
                apiHelper.IncludeBarerToken(access_token);
                apiHelper.AddBody(new Ubicacion() { latitud = latitud, longitud = longitud });
                var result = apiHelper.Execute();
                if (result.Success)
                    response.SetDefaulSuccess();
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
    }
}