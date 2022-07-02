using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;


public interface IService
{
	[OperationContract]
	PedidoSOAP CargarPedido(PedidoSOAP pedido);

	[OperationContract]
	TareaSOAP CargarTarea(int idPedid, TareaSOAP tarea);

	[OperationContract]
	List<TareaSOAP> ObtenerListadoTareas(EnumeradoresWEB.EstadoTarea estado = EnumeradoresWEB.EstadoTarea.NINGUNO);

	[OperationContract]
	TareaSOAP ObtenerTarea(int id);

	[OperationContract]
	TareaSOAP ActualizarTarea(int id);
}


[DataContract]
public class PedidoSOAP
{
	[DataMember]
	public int Id { get; set; }
	[DataMember]
	public string NombreSolicitante { get; set; }
	[DataMember]
	public string NombreDelArea { get; set; }
	[DataMember]
	public string Descripcion { get; set; }
	[DataMember]
	public DateTime FechaCreacion { get; private set; }
}

[DataContract]
public class TareaSOAP
{
	[DataMember]
	public int Id { get; set; }
	[DataMember]
	public decimal CostoMateriales { get; set; }
	[DataMember]
	public decimal CostoManoDeObra { get; set; }
	[DataMember]
	public decimal CostoTotal { get { return CostoManoDeObra + CostoMateriales; } }
	[DataMember]
	public PedidoSOAP PedidoAsociado { get; set; }
	[DataMember]
	public EnumeradoresWEB.EstadoTarea EstadoDeLaTarea { get; set; }
}


[DataContract]
public class EnumeradoresWEB
{
	public enum EstadoTarea { NINGUNO, PENDIENTE, REALIZADO }
}
