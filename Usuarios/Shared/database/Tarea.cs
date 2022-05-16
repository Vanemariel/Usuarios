using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usuarios.Compartidos.database
{
    [Index(nameof(Id), Name = "UQ_Tarea_Id", IsUnique = true)]
    public class Tarea
    {
        [Required(ErrorMessage = "El Id es obligatorio.")]
        [MaxLength(2, ErrorMessage = "El campo tiene como máximo {1} caracteres.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "la descripcion es obligatorio.")]
        [MaxLength(120, ErrorMessage = "El campo tiene como máximo {1} caracteres.")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El Estado es obligatorio.")]
        [MaxLength(120, ErrorMessage = "El campo tiene como máximo {1} caracteres.")]

        public string Estado { get; set; }

    }
}
