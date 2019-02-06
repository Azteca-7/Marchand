using System.Collections.Generic;

namespace Marchand.Model
{
    public class Bitacora : BaseResponse
    {
        public Jornada jornada { get; set; }
        public List<Establecimiento> establecimientos { get; set; }
        public int intervalo { get; set; }
    }
    
    public class Establecimiento
    {
        public int idEstablecimiento { get; set; }
    }
}
