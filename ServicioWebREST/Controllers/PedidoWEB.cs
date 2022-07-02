using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ServicioWebREST.Controllers
{
    public class Enumeradores
    {
        public enum EstadoTarea { NINGUNO, PENDIENTE, REALIZADO }
    }
    public class PedidoWEB
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "NombreDelSolicitante es obligatorio")]
        public string NombreSolicitante { get; set; }
        [Required(ErrorMessage = "NombreDelArea es obligatorio")]
        public string NombreDelArea { get; set; }
        [Required(ErrorMessage = "La descripcion es obligatoria")]
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
    }

    public class TareaWEB
    {
        public int Id { get; set; }
        public decimal CostoMateriales { get; set; }
        public decimal CostoManoDeObra { get; set; }
        public decimal CostoTotal { get { return CostoManoDeObra + CostoMateriales; } }
        public PedidoWEB PedidoAsociado { get; set; }
        public Enumeradores.EstadoTarea EstadoDeLaTarea { get; set; }
    }
}