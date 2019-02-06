using System;

namespace Marchand.Model
{
    public class Jornada
    {
        public int idBitacoraJornada { get; set; }
        public DateTime inicioJornada { get; set; }
        public DateTime? finJornada { get; set; }
        public decimal kms_recorridos { get; set; } = 0;
        public Usuario usuario { get; set; }
    }

    public class Usuario
    {
        public int idUsuario { get; set; }
        public string username { get; set; }
        public string nombre { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public Perfil perfil { get; set; }
    }

    public class Perfil
    {
        public int idPerfil { get; set; }
        public string descripcion { get; set; }
    }
}