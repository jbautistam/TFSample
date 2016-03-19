using System;

namespace Bau.Libraries.LibTeamFoundationServer.Model.Projects
{
	/// <summary>
	///		Clase con los datos de un proyecto
	/// </summary>
	public class ProjectModel : LibDomain.Model.Base.BaseExtendedModel
	{
		/// <summary>
		///		Tipos de tareas
		/// </summary>
		public System.Collections.Generic.List<string> TaskTypes { get; } = new System.Collections.Generic.List<string>();

		/// <summary>
		///		Categorías
		/// </summary>
		public CategoryModelCollection Categories { get; set; } = new CategoryModelCollection();
	
		/// <summary>
		///		Iteraciones
		/// </summary>
		public NodeModelCollection Iterations { get; } = new NodeModelCollection();

		/// <summary>
		///		Tareas del proyecto (Lazy)
		/// </summary>
		public LibDomain.Model.Base.LazyObject<TaskModelCollection> LazyTasks { get; } = new LibDomain.Model.Base.LazyObject<TaskModelCollection>();

		/// <summary>
		///		Tareas del proyecto
		/// </summary>
		public TaskModelCollection Tasks
		{ get { return LazyTasks.Data; }
			set { CheckProperty<TaskModelCollection, TaskModel>(LazyTasks, value); }
		}
	}
}
