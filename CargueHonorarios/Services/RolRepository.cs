using CargueHonorarios.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CargueHonorarios.Services
{
    public class RolRepository
    {
        public List<Rol> ObtenerTodos()
        {
            using (var db = new CargueHonorariosContext())
            {


                return db.Rol.ToList();
            }
        }


        internal void Crear(Rol model)
        {

            using (var db = new CargueHonorariosContext())
            {
                try
                {
                    db.Rol.Add(model);
                    db.SaveChanges();
                }
                catch
                {
                }
            }

        }

        internal void Editar(Rol model)
        {
            using (var db = new CargueHonorariosContext())
            {
                try
                {

                    db.Entry(model).State = EntityState.Modified;
                    db.SaveChanges();


                }
                catch
                { }
            }
        }

    }
}