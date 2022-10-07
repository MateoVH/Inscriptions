using Inscriptions.API.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Vereyon.Web;
using Inscriptions.API.Data.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Inscriptions.API.Controllers
{
    public class AsociadosController : Controller
    {
        private readonly DataContext _context;
        private readonly IFlashMessage _flashMessage;

        public AsociadosController(
            DataContext context,
            IFlashMessage flashMessage)
        {
            _context = context;
            _flashMessage = flashMessage;
        }

        public IActionResult add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> add(Asociado form)
        {
            var form2 = await _context.Asociados.Where(p => p.Cedula == form.Cedula).FirstOrDefaultAsync();
            if (form2 != null)
            {
                if (form2.HasInscription == false)
                {
                    return RedirectToAction("Confirm", "Asociados", form2);
                }
                else
                {
                    _flashMessage.Danger("La cédula ingresada ya se encuentra registrada para la elección de delegados.");
                }
            }
            else
            {
                _flashMessage.Danger("La cédula ingresada no se encontró en nuestro sistema. Verifique por favor.");
            }
            return RedirectToAction("add", "Asociados");
        }

        public async Task <IActionResult> Confirm(int? id)
        {
            var form = await _context.Asociados.FindAsync(id);
            return View(form);
        }

        [HttpPost]
        public async Task<IActionResult> Confirm2(Asociado form)
        {
            var form2 = await _context.Asociados.FindAsync(form.Id);
            form2.CreationDate = DateTime.Now;
            form2.HasInscription = true;
            _context.Asociados.Update(form2);
            await _context.SaveChangesAsync();
            _flashMessage.Warning("El Registro se ha creado correctamente!");
            return RedirectToAction("add", "Asociados");
        }

    }
}
