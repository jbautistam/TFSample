using System;

namespace Bau.Libraries.LibTeamFoundationServer.Model.Projects
{
	/// <summary>
	///		Datos de una categoría
	/// </summary>
	public class CategoryModel : LibDomain.Model.Base.BaseExtendedModel
	{
		/// <summary>
		///		Tipos de tareas
		/// </summary>
		public CategoryModelCollection TaskTypes { get; } = new CategoryModelCollection();
	}
}
