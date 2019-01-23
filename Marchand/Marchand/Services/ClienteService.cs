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
                new Cliente_() { Nombre = "Papeleria Gotita", Ciudad = "Puebla", Direccion = "Puebla", Estado = "Puebla", ClienteId = long.MaxValue, Zip = "75100" },
                new Cliente_() { Nombre = "Papeleria Tintero", Ciudad = "Puebla", Direccion = "Puebla", Estado = "Puebla", ClienteId = long.MaxValue-1, Zip = "72000" },
                new Cliente_() { Nombre = "Papeleria Tony", Ciudad = "Puebla", Direccion = "Puebla", Estado = "Puebla", ClienteId = long.MaxValue-2, Zip = "72000" },
                new Cliente_() { Nombre = "Palero Gutierrez", Ciudad = "Puebla", Direccion = "Puebla", Estado = "Puebla", ClienteId = long.MaxValue-3, Zip = "72000" }
            };
        }
    }
}
