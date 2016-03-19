using System;
using System.Windows.Forms;

using Bau.Libraries.LibTeamFoundationServer.Model.Projects;
using Bau.Libraries.LibTeamFoundationServer.Services;

namespace Bau.Applications.TFSWorkTimeSheet.UC.Tasks
{
	/// <summary>
	///		Control con los datos de un proyecto
	/// </summary>
	public partial class ctlProjectController : UserControl
	{
		public ctlProjectController()
		{ InitializeComponent();
		}

		/// <summary>
		///		Inicializa el control
		/// </summary>
		public void InitControl(TeamServerConnection objConnection)
		{ // Inicializa la conexión
				Connection = objConnection;
			// Inicializa los controles
				Clear();
		}

		/// <summary>
		///		Limpia los controles
		/// </summary>
		public void Clear()
		{	udtTreeProjects.InitControl();
			udtListTasks.InitControl();
		}

		/// <summary>
		///		Carga los datos del proyecto
		/// </summary>
		public void LoadProject(int? intIDProject)
		{ ProjectModel objProject = Connection.Projects.Search(intIDProject);

				if (!ProjectModel.IsNull(objProject))
					LoadProject(objProject);
				else
					Clear();
		}

		/// <summary>
		///		Carga el proyecto
		/// </summary>
		public void LoadProject(ProjectModel objProject)
		{ udtTreeProjects.LoadProject(objProject);
			udtListTasks.LoadTasks(objProject.Tasks);
		}

		/// <summary>
		///		Conexión
		/// </summary>
		public TeamServerConnection Connection { get; private set; }
	}
}
