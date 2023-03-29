using Microsoft.EntityFrameworkCore;
using Negozio_Online_API.Database;
using Negozio_Online_API.Models.Dipendente;
using Negozio_Online_API.Models.Reparto;
using System.Diagnostics;

namespace Negozio_Online_API.Services.Dipendente
{
    public class DipendentiService
    {
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _context;
        public DipendentiService(IConfiguration configuration, AppDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        //chiamata con ENTITY FRAMEWORK
        public List<DipendenteModelDTO> GetDipendenti(List<DipendenteModelDTO> dipendentiDTO)
        {
            List<DipendenteModel> dipendenti = new List<DipendenteModel>();
            try
            {
                dipendenti = _context.Dipendente.Include(d => d.Reparto).ToList();
                dipendentiDTO = dipendenti.Select(d => new DipendenteModelDTO
                {
                    ID = d.ID,
                    NomeDipendente = d.NomeDipendente,
                    CognomeDipendente = d.CognomeDipendente,
                    EmailDipendente = d.EmailDipendente,
                    DataAssunzioneDipendente = d.DataAssunzioneDipendente,
                    RepartoID = d.RepartoID,
                    NomeReparto = d.Reparto.NomeReparto
                }).ToList();

            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
            return dipendentiDTO;
        }

        public List<DipendenteModelDTO> GetDipendentiByReparto(string reparto, List<DipendenteModelDTO> dipendentiDTO)
        {
            List<DipendenteModel> dipendenti = new List<DipendenteModel>();
            try
            {
                /*Ricerca dipendenti utilizzando due chiamate distinte
                RepartoModel repartoModel = _context.Reparto.Where(rep => rep.NomeReparto == reparto).First();
                dipendenti = _context.Dipendente.Where(dip => dip.RepartoID == repartoModel.ID).ToList();
                dipendentiDTO = dipendenti.Select(d => new DipendenteModelDTO
                {
                    ID = d.ID,
                    NomeDipendente = d.NomeDipendente,
                    CognomeDipendente = d.CognomeDipendente,
                    EmailDipendente = d.EmailDipendente,
                    DataAssunzioneDipendente = d.DataAssunzioneDipendente,
                    RepartoID = d.RepartoID,
                    NomeReparto = d.Reparto.NomeReparto
                }).ToList();*/

                //Stesso metodo di ricerca con una sola chiamata
                dipendentiDTO = _context.Dipendente.Include(d => d.Reparto)
                      .Where(d => d.Reparto.NomeReparto == reparto)
                      .Select(d => new DipendenteModelDTO
                      {
                          ID = d.ID,
                          NomeDipendente = d.NomeDipendente,
                          CognomeDipendente = d.CognomeDipendente,
                          EmailDipendente = d.EmailDipendente,
                          DataAssunzioneDipendente = d.DataAssunzioneDipendente,
                          RepartoID = d.RepartoID,
                          NomeReparto = d.Reparto.NomeReparto
                      }).ToList();
            }
            catch (Exception ex)
            {

                Debug.Write(ex.Message);
            }
            return dipendentiDTO;
        }
    }
}
