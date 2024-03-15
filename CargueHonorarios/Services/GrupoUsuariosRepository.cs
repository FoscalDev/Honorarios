using CargueHonorarios.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CargueHonorarios.Services
{
    public class GrupoUsuariosRepository
    {

        public List<GrupoUsuarios> ObtenerTodos()
        {
            using (var db = new CargueHonorariosContext())
            {

                return db.GrupoUsuarios.ToList();

            }
        
        }


        internal void Crear(GrupoUsuarios model)
        {

            using (var db = new CargueHonorariosContext())
            {
                try
                {
                    db.GrupoUsuarios.Add(model);
                    db.SaveChanges();
                }
                catch
                {
                }
            }

        }

    }
}