using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CargueHonorarios.Models
{
    public class SD
    {
        public int Id { get; set; }
        public string Mes { get; set; }
        public string anio { get; set; }
        public string Acreedor { get; set; }
        public string Nombre1 { get; set; }
        public string Factura { get; set; }
        public string Pagador { get; set; }
        public string Solicitante { get; set; }
        public string Precio_credito { get; set; }
        public string CAI { get; set; }
        public string PAGO { get; set; }
        public DateTime Fecha_factura { get; set; }
        public string Numero_de_material { get; set; }
        public string CeBe { get; set; }
        public string Ce_coste { get; set; }
        public string Ctd_facturada { get; set; }
        public string Mon { get; set; }
        public string Nombre2 { get; set; }
        public string Nombre3 { get; set; }
        public string Cliente { get; set; }
        public string Pagador1 { get; set; }
        public string Pos { get; set; }
        public string Prc_neto { get; set; }
        public string Soc { get; set; }
        public string Clase_de_factura { get; set; }
        public string Texto_Número_de_cuenta_del_proveedor_o_a { get; set; }
        public string CeBe1 { get; set; }
        public string CIFac { get; set; }
        public string Doc_venta { get; set; }
        public string An { get; set; }
        public DateTime Fecha_doc { get; set; }
        public string Func { get; set; }
        public string Mon1 { get; set; }
        public string Tipo_de_factura { get; set; }
        public string TpFac { get; set; }
        public string UMB { get; set; }
        public string UM { get; set; }
        public string Valor_neto { get; set; }
        public string Solic { get; set; }
        public string Valorneto1 { get; set; }
        public string Material { get; set; }
       

        public int Usuario_Id { get; set; }
        [ForeignKey("Usuario_Id")]
        public Usuarios Usuario { get; set; }

        [NotMapped]
        public long pagoSD { get; set; }
        public virtual List<SD> ListadoHonorarios { get; set; }
        public List<ISH> InformeSD { get; set; }
    }
}