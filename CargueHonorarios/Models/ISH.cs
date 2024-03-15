using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CargueHonorarios.Models
{
    public class ISH
    {
    

        public int Id { get; set; }
        public string Mes { get; set; }
        public string Anio { get; set; }
        public string Acreedor { get; set; }
        public string Nombre_Acreedor { get; set; }
        public string Documento_comercial { get; set; }
        public string Nombre_paciente { get; set; }
        public string No_Documento { get; set; }
        public string Nombre_aseguradora { get; set; }
        public string Valor_neto { get; set; }
        public string Porcentaje_de_Honorario_Medico { get; set; }
        public string Imp_Final_Hon_Med { get; set; }
        public DateTime Fe_inic_R { get; set; }
        public string Desc_Prestacion_Fact { get; set; }
        public string Episodio { get; set; }
        public string Variación_Precio { get; set; }
        public string Aseguradora { get; set; }
        public string Cantidad_facturada { get; set; }
        public string Catal_facturacion { get; set; }
        public string Catalogo_prestac { get; set; }
        public string Centro_de_coste { get; set; }
        public string Centro_sanitario { get; set; }
        public string Clase_de_facturacion { get; set; }
        public string Cortesia { get; set; }
        public string Ctd_prestaciones { get; set; }
        public string Denom_funcion { get; set; }
        public string Desc_Interlocutor { get; set; }
        public string Desc_Prestacion { get; set; }
        public string Documento_modelo { get; set; }
        public string Ejercicio { get; set; }
        public string Estado { get; set; }
        public string Estado_NA30N { get; set; }
        public DateTime Fe_contabilizacion { get; set; }
        public string Funcion { get; set; }
        public string Hora_de { get; set; }
        public string Importe_de_Honorario_Medico { get; set; }
        public string Importe_de_Honorarios_Medicos { get; set; }
        public string Ind { get; set; }
        public string Interlocutor { get; set; }
        public string Moneda_del_documento { get; set; }
        public string NIT_acreedor { get; set; }
        public string N_actual_prestacion { get; set; }
        public string N_documento { get; set; }
        public string Numero_de_Contr { get; set; }
        public string Numero_de_version_del_contrato { get; set; }
        public string Observacion_Cortesia { get; set; }
        public string Orden_destinatario { get; set; }
        public string Paciente { get; set; }
        public string Porcentaje_Acreedor { get; set; }
        public string Porcentaje_Base { get; set; }
        public string Porcentaje_Retencion_de_honorario_medico { get; set; }
        public string Posicion { get; set; }
        public string Posicion_modelo { get; set; }
        public string Prestacion { get; set; }
        public string Prestacion1 { get; set; }
        public string QX_Sin_Costo { get; set; }
        public string Sociedad { get; set; }
        public string Status_Transferencia_FI { get; set; }
        public string Tipo_de_prestacion { get; set; }
        public string Un_organiz_gestora { get; set; }
        public string Unidad_medida_base { get; set; }
        public string UO_de_enferm_solic { get; set; }
        public string UO_medica_solicit { get; set; }
        public string Wissenschaftl_Code { get; set; }


        public int UsuarioId { get; set; }
        [ForeignKey("UsuarioId")]
        public Usuarios Usuario { get; set; }

        [NotMapped]
        public long pago { get; set; }
        
        public List<ISH> ListadoHonorariosISH { get; set; }
        public List<ISH> InformeISH { get; set; }
      
    }
}