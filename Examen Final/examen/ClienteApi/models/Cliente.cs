namespace ClienteApi.Models
{
    public class Cliente
    {
        public int ID { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Genero { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Estado { get; set; }
        public DateTime FechaCreacion { get; set; } // Nuevo campo
    }
}