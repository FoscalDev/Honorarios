using CargueHonorarios.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.Entity;





namespace CargueHonorarios.Services
{
    public class UsuariosRepository
    {
        public List<Usuarios> ObtenerTodos()
        {
            using (var db = new CargueHonorariosContext())
            {

                var usu = db.Usuarios.Include(p => p.Sociedad).Include(p => p.Tipo_Usuario).ToList();

                return usu;

            }
        }

        internal void Editar(Usuarios model)
        {
            using (var db = new CargueHonorariosContext())
            {
                try
                {
                    if (model.Clave == null)
                    {
                        model.Clave = "";
                    }
                    db.Entry(model).State = EntityState.Modified;
                    db.SaveChanges();


                }

                catch
                { }
            }
        }
    }
}

