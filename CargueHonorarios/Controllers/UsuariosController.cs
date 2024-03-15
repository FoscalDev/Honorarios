using CargueHonorarios.Services;
using CargueHonorarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;

namespace CargueHonorarios.Controllers
{
    public class UsuariosController : Controller
    {


        private UsuariosRepository _Repo;

        public UsuariosController()
        {
            _Repo = new UsuariosRepository();
        }
        //
        // GET: /Usuarios/

        public ActionResult Index()
        {

            using (var db = new CargueHonorariosContext())
            {
                ViewBag.Sociedad = db.Sociedad.ToList();
            }
            var model = _Repo.ObtenerTodos();

            return View(model);
        }

        //
        // GET: /Usuarios/Details/5

        public ActionResult Details(int id)
        {
            using (var db = new CargueHonorariosContext())
            {
                Usuarios usuario = db.Usuarios.Find(id);

                if (usuario == null)
                {
                    return HttpNotFound();
                }
                return View(usuario);
            }
        }

        public ActionResult Details2(int id)
        {
            using (var db = new CargueHonorariosContext())
            {
                Usuarios usuario = db.Usuarios.Find(id);
                if (usuario == null)
                {
                    return HttpNotFound();
                }
                return PartialView(usuario);
            }
        }

        //
        // GET: /Usuarios/Create

        public ActionResult Nuevo()
        {

            using (var db = new CargueHonorariosContext())
            {

                ViewBag.Sociedad = db.Sociedad.ToList();
                ViewBag.TipoUsuario = db.Tipo_Usuario.ToList();
           
            }
            return View();
        }

        //
        // POST: /Usuarios/Create

        [HttpPost]
        public ActionResult Nuevo(Usuarios model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                using ( var db = new CargueHonorariosContext())
                    {
                        var datos = new Usuarios();

                        datos.Codigo = model.Codigo;
                        datos.Nombre = model.Nombre;
                        datos.Correo = model.Correo;
                        datos.Clave = model.Clave;
                        datos.Telefono = model.Telefono;
                        datos.EmpresaId = model.EmpresaId;
                        datos.TipoUsuarioId = model.TipoUsuarioId;

                        db.Usuarios.Add(datos);
                        db.SaveChanges();
                        
                    }
                    
                  }
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
         
        }

        
        
        // GET: /Usuarios/Edit/5

        public ActionResult Edit(int Id)
        {
                     
            using (var db = new CargueHonorariosContext())
            {
                Usuarios usuario = db.Usuarios.Find(Id);
                if (usuario == null)
                {
                    return HttpNotFound();
                }


                usuario.ListadoSociedad = db.Sociedad.ToList();
                usuario.ListadoTipoUsuario = db.Tipo_Usuario.ToList();
                return View(usuario);
            }
            

        }

        //
        // POST: /Usuarios/Edit/5

        [HttpPost]
        public ActionResult Edit(int Id, Usuarios model)
        {


            try
            {
                // TODO: Add update logic here
                using (var db = new CargueHonorariosContext())
                {

                if (ModelState.IsValid)
                {
                    //model.ListadoSociedad = db.Sociedad.ToList();
                    //model.ListadoTipoUsuario = db.Tipo_Usuario.ToList();

                    _Repo.Editar(model);

                    return RedirectToAction("Index");
                }
               }
            }
            catch
            {

            }
            return View();
            
        }

        
        // GET: /Usuarios/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Usuarios/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
