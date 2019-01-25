using System;
using System.Collections.Generic;
using System.Text;
using Marchand.Model;

namespace Marchand.Services
{
    public class ClienteService
    {
        public static IEnumerable<Cliente_> GetClientes()
        {
            return new List<Cliente_>() {
                new Cliente_() { Nombre = "Siguiente Papeleria Gotita", Ciudad = "CDMX", Direccion = "Puebla", Estado = "Puebla", ClienteId = long.MaxValue, Zip = "75100" },
                new Cliente_() { Nombre = "Siguiente Papeleria Tintero", Ciudad = "CDMX", Direccion = "Puebla", Estado = "Puebla", ClienteId = long.MaxValue-1, Zip = "72000" },
                new Cliente_() { Nombre = "Siguiente Papeleria Tony", Ciudad = "CDMX", Direccion = "Puebla", Estado = "Puebla", ClienteId = long.MaxValue-2, Zip = "72000" },
                new Cliente_() { Nombre = "Siguiente Palero Gutierrez", Ciudad = "CDMX", Direccion = "Puebla", Estado = "Puebla", ClienteId = long.MaxValue-3, Zip = "72000" }
            };
        }
    }
}
