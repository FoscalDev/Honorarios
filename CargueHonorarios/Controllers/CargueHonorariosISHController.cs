using CargueHonorarios.Services;
using CargueHonorarios.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.Collections;


namespace CargueHonorarios.Controllers
{
    public class CargueHonorariosISHController : Controller
    {

        private HonorariosISHRepository _Repo;

        public CargueHonorariosISHController()
        
            {
                _Repo = new HonorariosISHRepository();
            }


        //
        // GET: /CargueHonorariosISH/

        public ActionResult IndexISH()
        {

            var model = _Repo.ObtenerTodo();

            return View(model);
        }


        public ActionResult  ListadoHonorariosISH(string Mes, string Anio, string Acreedor, string Sociedad)
        {
            var message = "";
            var message1 = "";
            try
            {
                if (Acreedor != "")
                {

                    List<ISH> ListadoISH = new List<ISH>();
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

                        ListadoISH = db.ISH.Where(e => e.Mes.Contains(Mes))
                            .Where(e => e.Anio.Contains(Anio))
                            .Where(e => e.Acreedor.Contains(Acreedor))
                            .Where(e => e.Sociedad.Contains(Sociedad)).ToList();

                        if (usuarios.TipoUsuarioId == 2)
                        {

                            ViewBag.acreedor = usuarios.Codigo;

                        }

                        ViewBag.tipousuario = usuarios.TipoUsuarioId;

                            var consulta = ListadoISH.Select(z => z.Imp_Final_Hon_Med).ToArray();

                            ISH resul = new ISH();

                            foreach (var n in consulta)
                            {

                                pago = pago + Convert.ToInt64(n);
                                
                            }

                            resul.pago = pago;
                            total =  pago;
                            ViewBag.total = total;                       
                        

                    }
                    return View(ListadoISH);
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
            return RedirectToAction("ListadoHonorariosISH", "CargueHonorariosISH");
   
        }




        //
        // GET: /CargueHonorariosISH/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /CargueHonorariosISH/Create

        public ActionResult Create()
        {
            return View();
        }

        //


        // POST: /CargueHonorariosISH/Create

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

        public ActionResult CargueHonorariosISH()
        {
            ISH model = new ISH();
            using (var db = new CargueHonorariosContext())
            {

                model.ListadoHonorariosISH = db.ISH.ToList();
                //ViewBag.Sociedad = db.Sociedad.ToList();
                 
            }
          
            

            return View(model);
        }
        //
        // POST: /CargueHonorarios/Create
        //controlador cargue honorarios ish
        [HttpPost]

        public ActionResult CargueHonorariosISH(ISH model, HttpPostedFileBase file )
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

                    ISH honorariosISH = new ISH();
                    string UsuarioId = String.Format("{0}", Session["Usuario"]);
                    int Usuario = 0;
                    Int32.TryParse(UsuarioId, out Usuario);
                    TextReader Leer = new StreamReader(ruta, Encoding.GetEncoding("iso-8859-1"));
                    string linea = Leer.ReadLine();
                    string datos = Leer.ReadToEnd();
                    var filas = datos.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var lineas in filas)
                    {
                        List<ISH> ListaISH = new List<ISH>();
                        var linea1 = lineas.Split(';');
                        honorariosISH.UsuarioId = Usuario;
                        honorariosISH.Mes = model.Mes;
                        honorariosISH.Anio = model.Anio;
                        honorariosISH.Acreedor = linea1[0];
                        honorariosISH.Nombre_Acreedor = linea1[1];
                        honorariosISH.Documento_comercial = linea1[2];
                        honorariosISH.Nombre_paciente = linea1[3];
                        honorariosISH.No_Documento = linea1[4];
                        honorariosISH.Nombre_aseguradora = linea1[5];
                        honorariosISH.Valor_neto = linea1[6];
                        honorariosISH.Porcentaje_de_Honorario_Medico = linea1[7];
                        honorariosISH.Imp_Final_Hon_Med = linea1[8];
                        honorariosISH.Fe_inic_R = Convert.ToDateTime(linea1[9]);
                        honorariosISH.Desc_Prestacion_Fact = linea1[10];
                        honorariosISH.Variación_Precio = linea1[12];
                        honorariosISH.Aseguradora = linea1[13];
                        honorariosISH.Cantidad_facturada = linea1[14];
                        honorariosISH.Catal_facturacion = linea1[15];
                        honorariosISH.Catalogo_prestac = linea1[16];
                        honorariosISH.Centro_de_coste = linea1[17];
                        honorariosISH.Centro_sanitario = linea1[18];
                        honorariosISH.Clase_de_facturacion = linea1[19];
                        honorariosISH.Cortesia = linea1[20];
                        honorariosISH.Ctd_prestaciones = linea1[21];
                        honorariosISH.Denom_funcion = linea1[22];
                        honorariosISH.Desc_Interlocutor = linea1[23];
                        honorariosISH.Desc_Prestacion = linea1[24];
                        honorariosISH.Documento_modelo = linea1[25];
                        honorariosISH.Ejercicio = linea1[26];
                        honorariosISH.Episodio = linea1[11];
                        honorariosISH.Estado = linea1[27];
                        honorariosISH.Estado_NA30N = linea1[28];
                        honorariosISH.Fe_contabilizacion = Convert.ToDateTime(linea1[29]);
                        honorariosISH.Funcion = linea1[30];
                        honorariosISH.Hora_de = linea1[31];
                        honorariosISH.Importe_de_Honorario_Medico = linea1[32];
                        honorariosISH.Importe_de_Honorarios_Medicos = linea1[33];
                        honorariosISH.Ind = linea1[34];
                        honorariosISH.Interlocutor = linea1[35];
                        honorariosISH.Moneda_del_documento = linea1[36];
                        honorariosISH.NIT_acreedor = linea1[37];
                        honorariosISH.N_actual_prestacion = linea1[38];
                        honorariosISH.N_documento = linea1[39];
                        honorariosISH.Numero_de_Contr = linea1[40];
                        honorariosISH.Numero_de_version_del_contrato = linea1[41];
                        honorariosISH.Observacion_Cortesia = linea1[42];
                        honorariosISH.Orden_destinatario = linea1[43];
                        honorariosISH.Paciente = linea1[44];
                        honorariosISH.Porcentaje_Acreedor = linea1[45];
                        honorariosISH.Porcentaje_Base = linea1[46];
                        honorariosISH.Porcentaje_Retencion_de_honorario_medico = linea1[47];
                        honorariosISH.Posicion = linea1[48];
                        honorariosISH.Posicion_modelo = linea1[49];
                        honorariosISH.Prestacion = linea1[50];
                        honorariosISH.Prestacion1 = linea1[51];
                        honorariosISH.QX_Sin_Costo = linea1[52];
                        honorariosISH.Sociedad = linea1[53];
                        honorariosISH.Status_Transferencia_FI = linea1[54];
                        honorariosISH.Tipo_de_prestacion = linea1[55];
                        honorariosISH.Un_organiz_gestora = linea1[56];
                        honorariosISH.Unidad_medida_base = linea1[57];
                        honorariosISH.UO_de_enferm_solic = linea1[58];
                        honorariosISH.UO_medica_solicit = linea1[59];
                        honorariosISH.Wissenschaftl_Code = linea1[60];
                        contlin = contlin + 1;

                        ListaISH.Add(honorariosISH);


                        using (var db = new CargueHonorariosContext())
                        {

                            db.ISH.Add(honorariosISH);
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

               
                message3 = "Ocurrio un error.  " + ex.Message ;
                message1 = "Ocurrio un error. Se cargaron " + contlin + " lineas";
                Session["message1"] = message1;

            }


            Session["message"] = message;
         
         
            return RedirectToAction("IndexISH", "CargueHonorariosISH");
            
                
        }

        public ActionResult InformeISH(string Mes, string Anio, string Sociedad)
        {
  
                            
                    using (var db = new CargueHonorariosContext())
                    {
                       //ArrayList lst = new ArrayList();
                       List<ISH> InformesISH = new List<ISH>();
                       List<ISH> resultados = new List<ISH>();
                       List<ISH> result = new List<ISH>();


               
                        int IdUsuarioR = 0;
                        string registra = String.Format("{0}", Session["Usuario"]);
                        Int32.TryParse(registra, out IdUsuarioR);

                        Usuarios usuarios = new Usuarios();
                        ViewBag.Sociedad = db.Sociedad.ToList();
                        usuarios = db.Usuarios.FirstOrDefault(e => e.Id == IdUsuarioR);

                        if (Sociedad == "1")
                        {
                            Sociedad = "1000";
                        }
                        else if (Sociedad == "2")
                        {
                            Sociedad = "2000";
                        }

                        InformesISH = db.ISH.Where(e => e.Mes.Contains(Mes))
                            .Where(e => e.Anio.Contains(Anio))
                            .Where(e => e.Sociedad.Contains(Sociedad)).ToList();

                        ViewBag.tipousuario = usuarios.TipoUsuarioId;


                        //var pago = 0;
                        var consulta = InformesISH.Select(z => z.Acreedor).Distinct().ToArray();
                        string nombre = "";
                        long total = 0;

                        foreach (var n in consulta)
                        {
                            long pago = 0;
                            var acreedor = n;
                            
                            var importe = db.ISH.Where(x => x.Acreedor == acreedor && x.Mes == Mes && x.Anio == Anio && x.Sociedad == Sociedad).Select(x => x.Imp_Final_Hon_Med).ToArray();
                            nombre = db.ISH.FirstOrDefault(x => x.Acreedor == acreedor).Nombre_Acreedor;
                            //var nombre  = db.ISH.Where(x => x.Acreedor == acreedor).Select(x => x.Nombre_Acreedor);
                            
                            foreach (var p in importe)
                            {
                                pago = pago + Convert.ToInt64(p);
                           
                            }


                            ISH resul = new ISH();
                            
                            resul.Acreedor = acreedor;
                            resul.Nombre_Acreedor = nombre;
                            resul.pago = pago;
                            
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
        // GET: /CargueHonorariosISH/Edit/5

        public ActionResult Edit(int Id)


        {         
               return View();
            
        }

        //
        // POST: /CargueHonorariosISH/Edit/5

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

            }
            return View();
        }

        //
        // GET: /CargueHonorariosISH/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /CargueHonorariosISH/Delete/5

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
