using CargueHonorarios.Services;
using CargueHonorarios.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace CargueHonorarios.Controllers
{
    public class CargueHonorariosController : Controller
    {

        private HonorariosRepository _Repo;

        public CargueHonorariosController()
        {
            _Repo = new HonorariosRepository();
        }

        //
        // GET: /CargueHonorarios/

        public ActionResult Index()
        {
            
            var model = _Repo.ObtenerTodos();

            return View(model);
        }

        public ActionResult ListadoHonorarios(string Mes, string Anio, string Acreedor, string Sociedad)
        {
            var message = "";
            var message1 = "";
        try
        {
               if (Acreedor != "") {
                List<SD> Listado = new List<SD>();
                using (var db = new CargueHonorariosContext()) 
                {
                    long total = 0;
                    long pago = 0;
              
                    int IdUsuarioR = 0;
                    string registra = String.Format("{0}", Session["Usuario"]);
                    Int32.TryParse(registra, out IdUsuarioR);

                    Usuarios usuarios = new Usuarios();
                    ViewBag.Sociedad = db.Sociedad.ToList();
                    usuarios = db.Usuarios.FirstOrDefault(e => e.Id == IdUsuarioR);
                
                        Listado = db.SD.Where(e => e.Mes.Contains(Mes))
                        .Where(e => e.anio.Contains(Anio))
                        .Where(e => e.Acreedor.Contains(Acreedor))
                        .Where(e => e.Soc.Contains(Sociedad)).ToList();
                 
               


                        if (usuarios.TipoUsuarioId == 2)
                        {

                            ViewBag.acreedor = usuarios.Codigo;
                        }

                        ViewBag.tipousuario = usuarios.TipoUsuarioId;

                        var consulta = Listado.Select(z => z.PAGO).ToArray();

                        SD resul = new SD();

                        foreach (var n in consulta)
                        {

                            pago = pago + Convert.ToInt64(n);

                        }

                        resul.pagoSD = pago;
                        total = pago;
                        ViewBag.total = total;   


                }
                return View(Listado);

            }
            else
                {

                    message = "OK";
                    
                
                }
        }
            catch (SystemException EX)
            {

                message1 = "Ocurrio un error. " + EX.Message;
                
            }
            Session["message"] = message;
            Session["message1"] = message1;
            return RedirectToAction("ListadoHonorarios", "CargueHonorarios");
   
      }



        public ActionResult InformeSD(string Mes, string Anio, string Sociedad)

        {
         
            using (var db = new CargueHonorariosContext())
            {
                //ArrayList lst = new ArrayList();
                List<SD> InformesSD = new List<SD>();
                List<SD> resultados = new List<SD>();
                List<SD> result = new List<SD>();




                int IdUsuarioR = 0;
                string registra = String.Format("{0}", Session["Usuario"]);
                Int32.TryParse(registra, out IdUsuarioR);

                Usuarios usuarios = new Usuarios();
                ViewBag.Sociedad = db.Sociedad.ToList();
                usuarios = db.Usuarios.FirstOrDefault(e => e.Id == IdUsuarioR);

                if(Sociedad == "1"){
                     Sociedad = "1000";
                }else{
                     Sociedad = "2000";
                }

                InformesSD = db.SD.Where(e => e.Mes.Contains(Mes))
                        .Where(e => e.anio.Contains(Anio))
                        .Where(e => e.Soc == Sociedad).ToList();
                
                ViewBag.tipousuario = usuarios.TipoUsuarioId;
                


                //var pago = 0;
                var consulta = InformesSD.Select(z => z.Acreedor).Distinct().ToArray();
                string nombre = "";

                long total = 0;

                foreach (var n in consulta)
                {
                    long pago = 0;
                    var acreedor = n;

                    var importe = db.SD.Where(x => x.Acreedor == acreedor && x.Mes == Mes && x.anio == Anio && x.Soc == Sociedad).Select(x => x.PAGO).ToArray();
                    nombre = db.SD.FirstOrDefault(x => x.Acreedor == acreedor).Nombre1;
                    //var nombre  = db.ISH.Where(x => x.Acreedor == acreedor).Select(x => x.Nombre_Acreedor);

                    

                    foreach (var p in importe)
                    {
                        pago = pago + Convert.ToInt64(p);

                    }

                    SD resul = new SD();

                    resul.Acreedor = acreedor;
                    resul.Nombre1 = nombre;
                    resul.pagoSD = pago;

                    total = total + pago;
                    ViewBag.total = total;

                    result.Add(resul);
                    resultados = result;

                }

                return View(resultados);
            }

            //return RedirectToAction("InformeISH", "CargueHonorariosISH");

        }
         

        //

        // GET: /CargueHonorarios/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /CargueHonorarios/Create

        public ActionResult Create()
        {
            return View();
        }

       


        public ActionResult CargueHonorariosSD()
        {
            SD model = new SD();
            using (var db = new CargueHonorariosContext())
            {
               
                model.ListadoHonorarios = db.SD.ToList();
              

            }

            return View(model);
        }


        [HttpPost]
        public ActionResult CargueHonorariosSD(SD model, HttpPostedFileBase file)
        {

            var ruta = "";
            var contlin = 0;
            var message = "";
            var message1 = "";
            var message2 = "";
            var message3 = "";
            try
            {

                if (HttpContext.Request.Files.AllKeys.Any())
                {
                    //Get the uploaded image from the Files collection
                    var httpPostedFile = HttpContext.Request.Files[0];

                    if (httpPostedFile != null)
                    {
                        // Validate the uploaded image(optional)

                        // Get the complete file path
                        DateTime date1 = DateTime.Now;
                        var nombrearchivo = date1.ToString("yyyyMMddHHmmssffff").ToString() + "-" + httpPostedFile.FileName;
                        var fileSavePath = Path.Combine(HttpContext.Server.MapPath("~/AnexosHonorarios"), nombrearchivo);
                        ruta = fileSavePath;


                        // Save the uploaded file to "UploadedFiles" folder
                        httpPostedFile.SaveAs(fileSavePath);
                    }



                    SD honorarios = new SD();
                    string UsuarioId = String.Format("{0}", Session["Usuario"]);
                    int Usuario = 0;
                    Int32.TryParse(UsuarioId, out Usuario);
                    TextReader Leer = new StreamReader(ruta, Encoding.GetEncoding("iso-8859-1"));
                    string linea = Leer.ReadLine();
                    string datos = Leer.ReadToEnd();
                    var filas = datos.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var lineas in filas)
                    {
                        var linea1 = lineas.Split(';');
                        honorarios.Mes = model.Mes;
                        honorarios.anio = model.anio;
                        honorarios.Usuario_Id = Usuario;
                        honorarios.Acreedor = linea1[0];
                        honorarios.Nombre1 = linea1[1];
                        honorarios.Factura = linea1[2];
                        honorarios.Pagador = linea1[3];
                        honorarios.Solicitante = linea1[4];
                        honorarios.Precio_credito = linea1[5];
                        honorarios.CAI = linea1[6];
                        honorarios.PAGO = linea1[7];
                        honorarios.Fecha_factura = Convert.ToDateTime(linea1[8]);
                        honorarios.Numero_de_material = linea1[9];
                        honorarios.CeBe = linea1[10];
                        honorarios.Ce_coste = linea1[11];
                        honorarios.Ctd_facturada = linea1[12];
                        honorarios.Mon = linea1[13];
                        honorarios.Nombre2 = linea1[14];
                        honorarios.Nombre3 = linea1[15];
                        honorarios.Cliente = linea1[16];
                        honorarios.Pagador1 = linea1[17];
                        honorarios.Pos = linea1[18];
                        honorarios.Prc_neto = linea1[19];
                        honorarios.Soc = linea1[20];
                        honorarios.Clase_de_factura = linea1[21];
                        honorarios.Texto_Número_de_cuenta_del_proveedor_o_a = linea1[22];
                        honorarios.CeBe1 = linea1[23];
                        honorarios.CIFac = linea1[24];
                        honorarios.Doc_venta = linea1[25];
                        honorarios.An = linea1[26];
                        honorarios.Fecha_doc = Convert.ToDateTime(linea1[27]);
                        honorarios.Func = linea1[28];
                        honorarios.Mon1 = linea1[29];
                        honorarios.Tipo_de_factura = linea1[30];
                        honorarios.TpFac = linea1[31];
                        honorarios.UMB = linea1[32];
                        honorarios.UM = linea1[33];
                        honorarios.Valor_neto = linea1[34];
                        honorarios.Solic = linea1[35];
                        honorarios.Valorneto1 = linea1[36];
                        honorarios.Material = linea1[37];
                        contlin = contlin + 1;

                        using (var db = new CargueHonorariosContext())
                        {
                            db.SD.Add(honorarios);
                            db.SaveChanges();
                        }

                    }

                    message = "OK";
                    message2 = "Los datos fueron guardados correctamente. Se cargaron " + contlin + " lineas";
                    Session["message2"] = message2;
                    Leer.Close();
                    System.IO.File.Delete(ruta);



                }
            }
            catch (SystemException ex)
            {
                message3 = "Ocurrio un error. " + ex.Message;
                message1 = "Ocurrio un error. Se cargaron " + contlin + " lineas";
                Session["message1"] = message1;

            }

            Session["message"] = message;
            return RedirectToAction("Index","CargueHonorarios");
        }


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
        // GET: /CargueHonorarios/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /CargueHonorarios/Edit/5

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
        // GET: /CargueHonorarios/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /CargueHonorarios/Delete/5

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
