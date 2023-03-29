namespace Negozio_Online_API.Models.Dipendente
{
    public class DipendenteModelDTO
    {
        public Guid ID { get; set; }
        public string NomeDipendente { get; set; }
        public string CognomeDipendente { get; set; }
        public string EmailDipendente { get; set; }
        public DateTime DataAssunzioneDipendente { get; set; }
        public Guid RepartoID { get; set; }
        public string NomeReparto { get; set;}
    }
}
