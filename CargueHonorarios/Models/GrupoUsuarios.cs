using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CargueHonorarios.Models
{
    public class GrupoUsuarios
    {
        public int Id { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public Boolean Estado { get; set; }

    }
}