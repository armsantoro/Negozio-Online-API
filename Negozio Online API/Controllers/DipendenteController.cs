using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Negozio_Online_API.Database;
using Negozio_Online_API.Models.Dipendente;
using Negozio_Online_API.Services.Dipendente;

namespace Negozio_Online_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DipendenteController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly DipendentiService _dipendentiService;
        public DipendenteController(IConfiguration configuration, DipendentiService dipendentiService)
        {
            _configuration = configuration;
            _dipendentiService = dipendentiService;
        }
       
        [HttpGet("GetAllDipendenti")]
        public List<DipendenteModelDTO> GetAllDipendenti()
        {
            List<DipendenteModelDTO> dipendenti = new List<DipendenteModelDTO>();
            dipendenti = _dipendentiService.GetDipendenti(dipendenti);
            return dipendenti;
        }

        [HttpGet("GetDipendentiByReparto")]
        public List<DipendenteModelDTO> GetDipendentiByReparto(string reparto)
        {
            List<DipendenteModelDTO> dipendenti = new List<DipendenteModelDTO>();
            dipendenti = _dipendentiService.GetDipendentiByReparto(reparto, dipendenti);
            return dipendenti;
        }
    }
}
