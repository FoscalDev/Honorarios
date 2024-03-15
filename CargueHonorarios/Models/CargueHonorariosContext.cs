using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


//namespace CargueHonorarios.Models
//{
//    public class CargueHonorariosContext : DbContext
//    {
//        // Puede agregar código personalizado a este archivo. Los cambios no se sobrescribirán.
//        // 
//        // Si desea que Entity Framework lo omita y regenere la base de datos
//        // automáticamente siempre que cambie el esquema de modelo, agregue
//        // el siguiente código al método Application_Start en el archivo Global.asax.
//        // Nota: esta operación destruirá y volverá a crear la base de datos con cada cambio de modelo.
//        // 
//        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<CargueHonorarios.Models.CargueHonorariosContext>());

//        public CargueHonorariosContext() : base("name=CargueHonorariosContext")
//        {
//        }

//        public DbSet<ISH> ISHes { get; set; }

//        public DbSet<Usuarios> Usuarios { get; set; }
//    }
//}


namespace CargueHonorarios.Models
{
    public class CargueHonorariosContext: DbContext

    {
        public CargueHonorariosContext()
            : base("Conexion") 
        {
        
        }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Tipo_usuario> Tipo_Usuario { get; set; }
        public DbSet<Sociedad> Sociedad { get; set; }
        public DbSet<SD> SD {get;set;}
        public DbSet<ISH> ISH { get; set; }
        public DbSet<GrupoUsuarios> GrupoUsuarios { get; set; }
        public DbSet<Rol> Rol { get; set; } 
        public DbSet<Perfil> Perfil { get; set; }
        public DbSet<Maestros> Maestros { get; set; }
        
    }
}