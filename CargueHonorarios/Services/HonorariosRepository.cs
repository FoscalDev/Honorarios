using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CargueHonorarios.Models;

namespace CargueHonorarios.Services
{
    public class HonorariosRepository
    {
        public List<SD> ObtenerTodos()
        {

            using (var db = new CargueHonorariosContext())
            {

                List<SD> Items = db.SD.ToList();
                foreach (SD Item in Items)
                {
                    Item.Usuario = db.Usuarios.FirstOrDefault(e => e.Id == Item.Usuario_Id);
                }
                return Items;

              
            }
        }    

    }
}