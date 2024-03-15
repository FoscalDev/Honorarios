using CargueHonorarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CargueHonorarios.Services
{
    public class PerfilRepository
    {
        public List<Perfil> ObtenerTodo()
        {
            using (var db = new CargueHonorariosContext())
            {
            return db.Perfil.ToList();
            }
        }


        internal void Crear(Perfil model)
        {
            using (var db = new CargueHonorariosContext())
            {
                try
                {
                    db.Perfil.Add(model);
                    db.SaveChanges();
                }
                catch
                { }
            }
        }
    }

    
}