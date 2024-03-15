using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CargueHonorarios.Models;
using System.Data;


namespace CargueHonorarios.Services
{
    public class HonorariosISHRepository
    {
        public List<ISH> ObtenerTodo()

        {
            using (var db = new CargueHonorariosContext())

            {
                List<ISH> Items = db.ISH.ToList();
                foreach (ISH Item in Items)
                {
                    Item.Usuario = db.Usuarios.FirstOrDefault(e => e.Id == Item.UsuarioId);
                }
                return Items;


            }

        }
     
        }


    }
