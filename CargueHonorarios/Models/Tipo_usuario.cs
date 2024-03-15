using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CargueHonorarios.Models
{
    public class Tipo_usuario
    {
        public int Id { get; set; }
        [Required]
        public int Codigo { get; set; }
        [Required]
        public string Descripcion { get; set; }
    }
}