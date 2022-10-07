using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;

namespace Inscriptions.API.Data.Entities
{
    public class Asociado
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Display(Name = "Nro. de Documento")]
        [MaxLength(20, ErrorMessage = "El campo {0} sólo puede contener {1} caracteres de longitud.")]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Display(Name = "Nombre Completo")]
        [MaxLength(100, ErrorMessage = "El campo {0} sólo puede contener {1} caracteres de longitud.")]
        public string NombreCompleto { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Display(Name = "Empresa")]
        [MaxLength(100, ErrorMessage = "El campo {0} sólo puede contener {1} caracteres de longitud.")]
        public string Empresa { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Display(Name = "Departamento")]
        [MaxLength(100, ErrorMessage = "El campo {0} sólo puede contener {1} caracteres de longitud.")]
        public string Departamento { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Display(Name = "Municipio")]
        [MaxLength(100, ErrorMessage = "El campo {0} sólo puede contener {1} caracteres de longitud.")]
        public string Municipio { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Display(Name = "Zona")]
        [MaxLength(100, ErrorMessage = "El campo {0} sólo puede contener {1} caracteres de longitud.")]
        public string Zona { get; set; }

        [Display(Name = "Fecha Confirmación Inscripción")]
        public DateTime? CreationDate { get; set; }

        public bool HasInscription { get; set; }

        [MaxLength(50, ErrorMessage = "El campo {0} sólo puede contener {1} caracteres de longitud.")]
        public string FileName { get; set; }

        [MaxLength(300, ErrorMessage = "El campo {0} sólo puede contener {1} caracteres de longitud.")]
        public string FilePath { get; set; }

    }
}
