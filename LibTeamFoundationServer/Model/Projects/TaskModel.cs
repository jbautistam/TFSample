using System;

namespace Bau.Libraries.LibTeamFoundationServer.Model.Projects
{
	/// <summary>
	///		Clase con los datos de una tarea
	/// </summary>
	public class TaskModel : LibDomain.Model.Base.BaseExtendedModel
	{
		/// <summary>
		///		Usuario al que está asignada la tarea
		/// </summary>
		public string AssignedTo { get; set; }

		/// <summary>
		///		ID de iteración
		/// </summary>
		public int? IdIteration { get; set; }

		/// <summary>
		///		Nombre del proyecto
		/// </summary>
		public string Project { get; set; }

		/// <summary>
		///		Tipo de la tarea
		/// </summary>
		public string Type { get; internal set; }

		/// <summary>
		///		Estado
		/// </summary>
		public string State { get; internal set; }

		/// <summary>
		///		Etiquetas
		/// </summary>
		public string Tags { get; internal set; }

		/// <summary>
		///		Columna
		/// </summary>
		public string BoardColumn { get; internal set; }

		/// <summary>
		///		Indica si está en la columna de hecho
		/// </summary>
		public string BoardColumnDone { get; internal set; }

		/// <summary>
		///		Línea del tablero
		/// </summary>
		public string BoardLane { get; internal set; }

		/// <summary>
		///		Tipo de vínculo
		/// </summary>
		public string LinkType { get; internal set; }

		/// <summary>
		///		Nombre del nodo
		/// </summary>
		public string NodeName { get; internal set; }

		/// <summary>
		///		Razón
		/// </summary>
		public string Reason { get; internal set; }

		/// <summary>
		///		Fecha de alta
		/// </summary>
		public DateTime? DateNew { get; internal set; }

		/// <summary>
		///		Usuario de alta
		/// </summary>
		public string UserNew { get; internal set; }

		/// <summary>
		///		Fecha de modificación
		/// </summary>
		public DateTime? DateUpdate { get; internal set; }

		/// <summary>
		///		Usuario de modificación
		/// </summary>
		public string UserUpdate { get; internal set; }

		/// <summary>
		///		Fecha de aprobación
		/// </summary>
		public DateTime? DateAuthorized { get; internal set; }

		/// <summary>
		///		Usuario de aprobación
		/// </summary>
		public string UserAuthorized { get; internal set; }

		/// <summary>
		///		Número de vínculos
		/// </summary>
		public int RelatedLinkCount { get; internal set; }
	}
}
