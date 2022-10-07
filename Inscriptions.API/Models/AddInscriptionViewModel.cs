using Inscriptions.API.Data.Entities;
using Microsoft.AspNetCore.Http;

namespace Inscriptions.API.Models
{
    public class AddInscriptionViewModel : Asociado
    {
        public IFormFile ImageFile { get; set; }
    }
}
