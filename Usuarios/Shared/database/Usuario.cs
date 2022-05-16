using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usuarios.Compartidos.database
{
    [Index(nameof(Id), Name = "UQ_Usuario_Id", IsUnique = true)]
    public class Usuario
    {
        [Required(ErrorMessage = "El Id del pais es obligatorio.")]
        [MaxLength(2, ErrorMessage = "El campo tiene como máximo {1} caracteres.")]

        public int Id { get; set; }
        [Required(ErrorMessage = "El Username es obligatorio.")]
        [MaxLength(120, ErrorMessage = "El campo tiene como máximo {1} caracteres.")]

        public string Username { get; set; }


        [Required(ErrorMessage = "El Email es obligatorio.")]
        [MaxLength(120, ErrorMessage = "El campo tiene como máximo {1} caracteres.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "El Lastname es obligatorio.")]
        [MaxLength(120, ErrorMessage = "El campo tiene como máximo {1} caracteres.")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "El Pasword es obligatorio.")]
        [MaxLength(120, ErrorMessage = "El campo tiene como máximo {1} caracteres.")]
        public string Pasword { get; set; }
        [Required(ErrorMessage = "El Nombre del proyecto es obligatorio.")]
        [MaxLength(120, ErrorMessage = "El campo tiene como máximo {1} caracteres.")]

        public string NombreProyecto { get; set; }

        [Required(ErrorMessage = "El Id del Proyecto es obligatorio.")]
        [MaxLength(2, ErrorMessage = "El campo tiene como máximo {1} caracteres.")]
        public string IdProyecto { get; set; }
        public List<Proyecto> Proyecto { get; set; }

    }
}
