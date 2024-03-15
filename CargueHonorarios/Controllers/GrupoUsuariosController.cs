using CargueHonorarios.Models;
using CargueHonorarios.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace CargueHonorarios.Controllers
{
    public class GrupoUsuariosController : Controller

    {
        
        private GrupoUsuariosRepository _repo;

        public GrupoUsuariosController()
        {
            _repo = new GrupoUsuariosRepository();

        }



        //
        // GET: /GrupoUsuarios/

        public ActionResult Index()
        {
            List<string> funciones = Acceso.Validar(Session["Usuario"]);

            if (Acceso.EsAnonimo)
            {
                return RedirectToAction("Login", "Login");
            }
            else if (!Acceso.EsAnonimo && !funciones.Contains("GrupoUsuarios"))
            {
                Session.Add("ErrorAutorizacion", "No cuenta con autorización para la opción seleccionada");
                return RedirectToAction("Index", "Login");
                
            }

            var model = _repo.ObtenerTodos();
            return View(model);
        }

        //
        // GET: /GrupoUsuarios/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /GrupoUsuarios/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /GrupoUsuarios/Create

        [HttpPost]
        public ActionResult Create(GrupoUsuarios model)
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
        // GET: /GrupoUsuarios/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /GrupoUsuarios/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /GrupoUsuarios/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /GrupoUsuarios/Delete/5

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

        public GrupoUsuarios model { get; set; }
    }
}
