using CargueHonorarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace CargueHonorarios.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Login(string message = "")
        {
            ViewBag.Message = message;
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return View("Login");
        }

        public ActionResult Validar(string alias, string password)
        {
            if (!string.IsNullOrEmpty(alias) && !string.IsNullOrEmpty(password))
            {
                CargueHonorariosContext db = new CargueHonorariosContext();

                var user = db.Usuarios.FirstOrDefault(e => e.Codigo == alias.Trim() && e.Clave == password.Trim());


                if (user != null)
                {
                    Session.Add("Usuario", user.Id);
                    return RedirectToAction("Index", "Login");

                }
                else
                {
                    ViewBag.message = "Codigo o Contraseña incorrectos.";
                    Session.Add("message", "Codigo o Contraseña incorrectos.");
                    return RedirectToAction("Login");

                }
            }
            else
            {
                return RedirectToAction("Login", new { message = "Sin datos" });
            }
        }

        [HttpPost]
        public ActionResult Registrar(Usuarios model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var db = new CargueHonorariosContext())
                    {
                        var datos = new Usuarios();

                        datos.Codigo = model.Codigo;
                        datos.Nombre = model.Nombre;
                        datos.Correo = model.Correo;
                        datos.Clave = model.Clave;
                        datos.Telefono = model.Telefono;
                        datos.EmpresaId = model.EmpresaId;
                        datos.TipoUsuarioId = model.TipoUsuarioId;

                        Maestros maestros = new Maestros();

                        maestros = db.Maestros.FirstOrDefault(e => e.Codigo == datos.Codigo);

                        if (maestros != null)
                        {

                            db.Usuarios.Add(datos);
                            db.SaveChanges();
                        }

                    }

                }
                return RedirectToAction("Registrar");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        
        // GET: /Home/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Home/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Home/Create

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
        // GET: /Home/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Home/Edit/5

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
        // GET: /Home/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Home/Delete/5

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
