using CargueHonorarios.Models;
using CargueHonorarios.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CargueHonorarios.Controllers
{
    public class PerfilController : Controller
    {
        //
        // GET: /Perfil/

        private PerfilRepository _repo;

        public PerfilController()
        {
            _repo = new PerfilRepository();  
        }



        public ActionResult Index()
        {
            List<string> funciones = Acceso.Validar(Session["Usuario"]);
            if (Acceso.EsAnonimo)
            {
                return RedirectToAction("Login", "Login");
            }
            else if (!Acceso.EsAnonimo && !funciones.Contains("Perfil"))
            {
                Session.Add("ErrorAutorizacion", "No cuenta con autorización para la opción seleccionada");
                return RedirectToAction("Index", "Login");
            }
            var model = _repo.ObtenerTodo();
            return View(model);
        }

        //
        // GET: /Perfil/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Perfil/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Perfil/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Perfil/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Perfil/Edit/5

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
        // GET: /Perfil/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Perfil/Delete/5

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
