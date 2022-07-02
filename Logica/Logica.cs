using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Logica
{
    public class Logica
    {
        public static List<Pedido> Pedidos = new List<Pedido>();
        public static List<Tarea> Tareas = new List<Tarea>();

        public Pedido CargarPedido(Pedido pedido)
        {
            Pedidos.Add(new Pedido(GenerarIdAleatorio(), pedido.NombreSolicitante, pedido.NombreDelArea, pedido.Descripcion));
            return Pedidos.Last();
        }

        public Tarea CargarTarea(int idPedido, Tarea tarea)
        {
            Pedido pedido = BuscarPedido(idPedido);
            if(pedido != null)
            {
                Tareas.Add(new Tarea(GenerarIdAleatorio(), tarea.CostoMateriales, tarea.CostoManoDeObra, pedido));
                return Tareas.Last();
            }
            return null;
        }

        public List<Tarea> ObtenerListadoTareas(Enumeradores.EstadoTarea estado = Enumeradores.EstadoTarea.NINGUNO)
        {
            List<Tarea> ListaFiltradaDeTareas = Tareas;
            if(estado != Enumeradores.EstadoTarea.NINGUNO)
            {
                ListaFiltradaDeTareas = Tareas.Where(x=>x.EstadoDeLaTarea==estado).ToList();
            }
            return ListaFiltradaDeTareas;
        }

        public Tarea ObtenerTareaEspecifica(int id)
        {
            return BuscarTarea(id);
        }

        public Tarea ActualizarTarea(int id)
        {
            Tarea tarea = BuscarTarea(id);
            if(tarea != null)
            {
                tarea.EstadoDeLaTarea = Enumeradores.EstadoTarea.REALIZADO;
            }
            return tarea;
        }

        private Pedido BuscarPedido(int id)
        {
            return Pedidos.FirstOrDefault(x => x.Id == id);
        }

        private Tarea BuscarTarea(int id)
        {
            return Tareas.FirstOrDefault(x => x.Id == id);
        }

        private int GenerarIdAleatorio()
        {
            Random random = new Random();
            return random.Next(0, 100);
        }

    }

}
