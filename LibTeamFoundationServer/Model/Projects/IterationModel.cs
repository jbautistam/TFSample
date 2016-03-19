using System;

namespace Bau.Libraries.LibTeamFoundationServer.Model.Projects
{
	/// <summary>
	///		Clase con los datos de una iteración
	/// </summary>
	public class IterationModel : LibDomain.Model.Base.BaseModel
	{
		/// <summary>
		///		Tareas asociadas a la iteración (Lazy)
		/// </summary>
		public LibDomain.Model.Base.LazyObject<TaskModelCollection> LazyTasks { get; } = new LibDomain.Model.Base.LazyObject<TaskModelCollection>();

		/// <summary>
		///		Tareas asociadas a la iteración
		/// </summary>
		public TaskModelCollection Tasks
		{ get { return LazyTasks.Data; }
			set { CheckProperty<TaskModelCollection, TaskModel>(LazyTasks, value); }
		}
	}
}
