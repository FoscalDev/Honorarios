using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CargueHonorarios.Models
{
    public static class Acceso
    {

        private static int Usuario;

        public static Boolean EsAnonimo { get { return Usuario <= 0; } }

        public static List<string> Validar(object usuario = null)
        {
            Usuario = -1;
            List<string> Items = new List<string>();
            CargueHonorariosContext db = new CargueHonorariosContext();

            if (int.TryParse(string.Format("{0}", usuario), out Usuario) && Usuario > 0)
            {

                Perfil[] PE = db.Perfil.Where(e => e.GrupoUsuarios.Estado == true).ToArray();
                Rol[] RO = db.Rol.Where(e => e.UsuarioId == Usuario && e.GrupoUsuarios.Estado == true).ToArray();

                foreach (Rol x in RO)
                {
                    foreach (Perfil y in PE)
                    {
                        if (x.GrupoId == y.GrupoId)
                        {
                            if (!Items.Contains(y.Funcion)) { Items.Add(y.Funcion); }
                        }
                    }
                }


            }

            return Items;
        }
      }
    
}