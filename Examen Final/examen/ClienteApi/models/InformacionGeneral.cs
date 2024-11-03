namespace ClienteApi.Models
{
    public class InformacionGeneral
    {
        public int ID { get; set; }
        public string TipoInformacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public string UsuarioCreador { get; set; }
        public string EstadoInformacion { get; set; }
        public int ClienteID { get; set; }
        public Cliente Cliente { get; set; }
    }
}