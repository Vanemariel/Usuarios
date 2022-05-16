using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usuarios.Compartidos.database
{
    [Index(nameof(Id), Name = "UQ_Proyecto_Id", IsUnique = true)]
    public class Proyecto
    {
        [Required(ErrorMessage = "El Id es obligatorio.")]
        [MaxLength(2, ErrorMessage = "El campo tiene como máximo {1} caracteres.")]
        public int Id { get; set; }
        [Required(ErrorMessage = "El Titulo es obligatorio.")]
        [MaxLength(120, ErrorMessage = "El campo tiene como máximo {1} caracteres.")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "La tecnica back es obligatorio.")]
        [MaxLength(120, ErrorMessage = "El campo tiene como máximo {1} caracteres.")]
        public string TecnicaBack { get; set; }

        [Required(ErrorMessage = "La tecnica front es obligatorio.")]
        [MaxLength(120, ErrorMessage = "El campo tiene como máximo {1} caracteres.")]
        public string TecnicaFront { get; set; }
        public List<Tarea> Tareas { get; set; }
    }
}
