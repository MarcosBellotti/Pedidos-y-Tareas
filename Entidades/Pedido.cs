using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Enumeradores
    {
        public enum EstadoTarea { NINGUNO, PENDIENTE, REALIZADO}
    }
    public class Pedido
    {
        public int Id { get; set; }
        public string NombreSolicitante { get; set; }
        public string NombreDelArea { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; private set; }

        public Pedido() { }
        public Pedido(int id, string nombreSolicitante, string nombreDelArea, string descripcion) 
        {
            Id = id;
            NombreSolicitante = nombreSolicitante;
            NombreDelArea = nombreDelArea;
            Descripcion = descripcion;
            FechaCreacion = DateTime.Now;
        }


    }

    public class Tarea
    {
        public int Id { get; set; }
        public decimal CostoMateriales { get; set; }
        public decimal CostoManoDeObra { get; set; }
        public decimal CostoTotal { get { return CostoManoDeObra + CostoMateriales; } }
        public Pedido PedidoAsociado { get; set; }
        public Enumeradores.EstadoTarea EstadoDeLaTarea { get; set; }

        public Tarea() { }
        public Tarea(int id, decimal costoMateriales, decimal costoManoDeObra, Pedido pedidoAsociado) 
        {
            id = Id;
            CostoMateriales = costoMateriales;
            CostoManoDeObra = costoManoDeObra;
            EstadoDeLaTarea = Enumeradores.EstadoTarea.PENDIENTE;
            PedidoAsociado = pedidoAsociado;
        }
    }

}
