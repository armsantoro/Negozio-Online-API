using Negozio_Online_API.Models.Dipendente;

namespace Negozio_Online_API.Models.Reparto
{
    public class RepartoModel
    {
        public Guid ID { get; set; }
        public string NomeReparto { get; set; }
        public string DescrizioneReparto { get; set; }
        public ICollection<DipendenteModel> Dipendente { get; set; }
    }
}
