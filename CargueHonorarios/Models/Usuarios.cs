using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CargueHonorarios.Models
{
    public class Usuarios
    {
        public int Id { get; set; }
        [Required]
        public string Codigo { get; set; }
        [DisplayName("Nombre Usuario")]
        [Required(ErrorMessage = "Digite Usuario.")]
        public string Nombre { get; set; }
        public string Correo { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Digite clave de acceso.")]
        public string Clave { get; set; }
        public string Telefono { get; set; }

        public int EmpresaId { get; set; }
        [ForeignKey("EmpresaId")]
        public Sociedad Sociedad { get; set; } 

        public int TipoUsuarioId { get; set; }
        [ForeignKey("TipoUsuarioId")]
        public Tipo_usuario Tipo_Usuario { get; set; }

        [NotMapped]
        public List<Sociedad> ListadoSociedad{ get; set; }
        [NotMapped]
        public List<Tipo_usuario> ListadoTipoUsuario{ get; set; }

    }

}