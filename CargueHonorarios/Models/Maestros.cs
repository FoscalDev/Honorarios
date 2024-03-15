using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace CargueHonorarios.Models
{
    public class Maestros
    {
        public int Id { get; set; }
        [Required]
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }
  
    }
}