using System;
using System.ComponentModel;
using System.Reflection;

namespace Marchand.Model.Ws
{
    public class Constants
    {
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
             (DescriptionAttribute[])fi.GetCustomAttributes(
             typeof(DescriptionAttribute),
             false);

            if (attributes != null &&
             attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        public enum eMethod
        {
            [Description("POST")]
            POST,
            [Description("GET")]
            GET,
        }

        public enum eUrlApi
        {
            [Description("/oauth/token")]
            Login,
            [Description("/bitacora/")]
            Bitacora,
            [Description("/ubicacion")]
            Ubicacion,
        }

        public enum eContentType
        {
            [Description("application/x-www-form-urlencoded")]
            UrlEncoded,
            [Description("application/json")]
            Json
        }
    }
}
