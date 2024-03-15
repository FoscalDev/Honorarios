using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CargueHonorarios.Models
{
    public class Rol
    {
        public int Id { get; set; }

        public int GrupoId { get; set; }
        [ForeignKey("GrupoId")]
        public GrupoUsuarios GrupoUsuarios { get; set; }

        public int UsuarioId { get; set; }
        [ForeignKey("UsuarioId")]
        public Usuarios Usuarios { get; set; }


        public List<Models.GrupoUsuarios> ListadoGrupos { get; set; }
    }
}