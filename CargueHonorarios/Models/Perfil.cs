using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CargueHonorarios.Models
{
    public class Perfil
    {
        public int Id { get; set; }
        public int GrupoId { get; set; }
        [ForeignKey("GrupoId")]
        public GrupoUsuarios GrupoUsuarios { get; set; }
        public string Funcion { get; set; }
        [NotMapped]
        public virtual List<GrupoUsuarios> ListadoGrupos { get; set; }
    }
}