using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.ComponentModel.DataAnnotations;

namespace ServicioWebREST.Controllers
{
    [RoutePrefix("Pedido")]
    public class PedidoController : ApiController
    {
        Logica.Logica logica = new Logica.Logica();

        [Route("CargarPedido")]
        public IHttpActionResult POST(PedidoWEB pedido)
        {
            if(ModelState.IsValid)
            {
                return Created("",logica.CargarPedido(pedido.PasarAPedidoLogica()).PasarAPedidoWEB());
            }
            return BadRequest();
        }
    }

    [RoutePrefix("Tarea")]
    public class TareaController : ApiController
    {
        Logica.Logica logica = new Logica.Logica();
        [Route("CargarTarea/{idPedido}")]
        public IHttpActionResult POST(TareaWEB tarea, int idPedido)
        {
            if (ModelState.IsValid)
            {
                TareaWEB tareaa = logica.CargarTarea(idPedido, tarea.PasarATareaLogica()).PasarATareaWEB();
                if(tareaa != null)
                    return Created("", tareaa);
            }
            return BadRequest();
        }

        [Route("ObternerListadoTareas")]
        public IHttpActionResult GETListado(Enumeradores.EstadoTarea estado = Enumeradores.EstadoTarea.NINGUNO)
        {
            List<TareaWEB> Tareas = new List<TareaWEB>();
            foreach (Entidades.Tarea tarea in logica.ObtenerListadoTareas())
            {
                Tareas.Add(tarea.PasarATareaWEB());
            }
            return Ok(Tareas);
        }

        [Route("ObtenerTarea/{id}")]
        public IHttpActionResult GETTarea(int id)
        {
            if(logica.ObtenerTareaEspecifica(id) == null)
            {
                return BadRequest();
            }
            return Ok(logica.ObtenerTareaEspecifica(id).PasarATareaWEB());
        }

        [Route("ActualizarTarea/{id}")]
        public IHttpActionResult PUT(int id)
        {
            if (logica.ObtenerTareaEspecifica(id)== null)
            {
                return BadRequest();
            }
            return Ok(logica.ObtenerTareaEspecifica(id).PasarATareaWEB());
        }

    }
    public static class Metodos
    {
        public static Entidades.Pedido PasarAPedidoLogica(this PedidoWEB pedido)
        {
            return new Entidades.Pedido()
            {
                NombreDelArea = pedido.NombreDelArea,
                NombreSolicitante = pedido.NombreSolicitante,
                Descripcion = pedido.Descripcion
            };
        }

        public static PedidoWEB PasarAPedidoWEB(this Entidades.Pedido pedido)
        {
            return new PedidoWEB()
            {
                Id= pedido.Id,
                NombreDelArea = pedido.NombreDelArea,
                NombreSolicitante = pedido.NombreSolicitante,
                Descripcion = pedido.Descripcion,
                FechaCreacion = pedido.FechaCreacion,
            };
        }

        public static Entidades.Tarea PasarATareaLogica(this TareaWEB tarea)
        {
            return new Entidades.Tarea()
            {
                CostoManoDeObra=tarea.CostoManoDeObra,
                CostoMateriales = tarea.CostoMateriales
            };
        }
        public static TareaWEB PasarATareaWEB(this Entidades.Tarea tarea)
        {
            return new TareaWEB()
            {
                Id= tarea.Id,
                CostoManoDeObra = tarea.CostoManoDeObra,
                CostoMateriales = tarea.CostoMateriales,
                PedidoAsociado = tarea.PedidoAsociado.PasarAPedidoWEB()
            };
        }
    }
}
