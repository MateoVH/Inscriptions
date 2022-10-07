using Inscriptions.API.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Vereyon.Web;
using Inscriptions.API.Data.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Inscriptions.API.Models;
using System.IO;

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

            var model = new AddInscriptionViewModel()
            {
                Cedula = form.Cedula,
                Departamento = form.Departamento,
                Empresa = form.Empresa,
                Municipio = form.Municipio,
                NombreCompleto = form.NombreCompleto,
                Zona = form.Zona,
                Id = form.Id,
                
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Confirm2(AddInscriptionViewModel form)
        {
            var form2 = await _context.Asociados.FindAsync(form.Id);
            form2.CreationDate = DateTime.Now;
            form2.HasInscription = true;

            if (form.ImageFile != null && form.ImageFile.Length > 0)
            {
                var pathImg = string.Empty;

                var guid = Guid.NewGuid().ToString();
                var file = $"{form2.Cedula}{Path.GetExtension(form.ImageFile.FileName)}";

                pathImg = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\fotos", file);

                using (var stream = new FileStream(pathImg, FileMode.Create))
                {
                    await form.ImageFile.CopyToAsync(stream);
                }

                form2.FileName = file;
                form2.FilePath = $"/fotos/{file}";
            }

            _context.Asociados.Update(form2);
            await _context.SaveChangesAsync();
            _flashMessage.Warning("La Inscripción se ha realizado correctamente!");
            return RedirectToAction("add", "Asociados");
        }

    }
}
