using CargueHonorarios.Models;
using CargueHonorarios.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CargueHonorarios.Controllers
{
    public class RolController : Controller
    {
        //
        // GET: /Rol/

        private RolRepository _repo;

        public RolController()
        {
            _repo = new RolRepository();

        }


        public ActionResult Index()
        {
            List<string> funciones = Acceso.Validar(Session["Usuario"]);

            if (Acceso.EsAnonimo)
            {
                return RedirectToAction("Login", "Login");
            }
            else if (!Acceso.EsAnonimo && !funciones.Contains("Rol"))
            {
                Session.Add("ErrorAutorizacion", "No cuenta con autorización para la opción seleccionada");
                return RedirectToAction("Index", "Login");
            }
            var model = _repo.ObtenerTodos();
            return View(model);
        }

        //
        // GET: /Rol/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Rol/Create

        public ActionResult Create()
        {
            List<string> funciones = Acceso.Validar(Session["Usuario"]);

            if (Acceso.EsAnonimo)
            {
                return RedirectToAction("Login", "Login");
            }
            else if (!Acceso.EsAnonimo && !funciones.Contains("Rol"))
            {
                Session.Add("ErrorAutorizacion", "No cuenta con autorización para la opción seleccionada");
                return RedirectToAction("Index", "Login");
            }
            var model = new Rol();
            using (var db = new CargueHonorariosContext())
            {
                model.ListadoGrupos = db.GrupoUsuarios .ToList();

            }



            return View(model);
        }

        //
        // POST: /Rol/Create

        [HttpPost]
        public ActionResult Create(Rol model)
        {
            try
            {
                // TODO: Add insert logic here

                if (ModelState.IsValid)
                {

                    _repo.Crear(model);
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                
            }
            return View();
        }

        //
        // GET: /Rol/Edit/5

        public ActionResult Edit(int id)
        {
            List<string> funciones = Acceso.Validar(Session["Usuario"]);

            if (Acceso.EsAnonimo)
            {
                return RedirectToAction("Login", "Login");
            }
            else if (!Acceso.EsAnonimo && !funciones.Contains("Rol"))
            {
                Session.Add("ErrorAutorizacion", "No cuenta con autorización para la opción seleccionada");
                return RedirectToAction("Index", "Login");
            }
            var model = new Rol();
            using (var db = new CargueHonorariosContext())
            {
                model.ListadoGrupos = db.GrupoUsuarios.ToList();

            }

            return View(model);
        }

        //
        // POST: /Rol/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Rol model)
        {
            try
            {
                // TODO: Add update logic here

                if (ModelState.IsValid)
                {

                    _repo.Editar(model);

                    return RedirectToAction("Index");
                }
            }
            catch
            {
             
            }
            return View();
        }

        //
        // GET: /Rol/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Rol/Delete/5

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
