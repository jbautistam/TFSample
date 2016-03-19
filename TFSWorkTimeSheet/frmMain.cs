using System;
using System.Windows.Forms;

using Bau.Libraries.LibHelper.Extensors;
using Bau.Libraries.LibTeamFoundationServer.Services;
using Bau.Libraries.LibTeamFoundationServer.Model.Projects;

namespace Bau.Applications.TFSWorkTimeSheet
{
	/// <summary>
	///		Formulario principal
	/// </summary>
	public partial class frmMain : Form
	{	
		public frmMain()
		{	InitializeComponent();
		}

		/// <summary>
		///		Inicializa el formulario
		/// </summary>
		private void InitForm()
		{ // Conecta al servidor
				if (!ConnectServer())
					Close();
				else
					{ // Carga los proyectos
							LoadProjects();
						// Inicializa la pantalla
							SelectProject(Configuration.IDLastProject);
					}
		}

		/// <summary>
		///		Conecta al servidor
		/// </summary>
		private bool ConnectServer()
		{ bool blnConnected = false;
			frmLogin frmNewLogin = new frmLogin();

				// Muestra la ventana de login
					frmNewLogin.ShowDialog();
				// Conecta al servidor
					if (frmNewLogin.DialogResult == DialogResult.OK)
						{	// Crea la conexión y conecta
								udtProject.InitControl(new TeamServerConnection(Configuration.Server, Configuration.Collection, 
																																	Configuration.User, Configuration.Password));
								udtProject.Connection.Connect();
							// Indica que se ha conectado corretamente
								blnConnected = true;
						}
				// Devuelve el valor que indica si está conectado
					return blnConnected;
		}

		/// <summary>
		///		Carga los proyectos
		/// </summary>
		private void LoadProjects()
		{ // Limpia el combo
				cboProjects.Enabled = true;
				cboProjects.Items.Clear();
			// Asigna los proyectos
				if (udtProject.Connection.Projects != null && udtProject.Connection.Projects.Count > 0)
					foreach (ProjectModel objProject in udtProject.Connection.Projects)
						cboProjects.AddItem(objProject.ID, objProject.Name);
				else
					cboProjects.Enabled = false;
		}

		/// <summary>
		///		Selecciona un proyecto
		/// </summary>
		private void SelectProject(int? intIDProject)
		{ // Selecciona el proyecto en el combo
				if ((intIDProject ?? 0) < 1)
					cboProjects.SelectedIndex = 0;
				else if (cboProjects.SelectedID != intIDProject)
					cboProjects.SelectedID = intIDProject;
			// Guarda la configuración
				Configuration.IDLastProject = cboProjects.SelectedID ?? 0;
				Configuration.Save();
			// Carga la lista de tarea
				udtProject.LoadProject(intIDProject);
		}

		private void frmMain_Load(Object sender, EventArgs e)
		{ InitForm();
		}

		private void cmdConnect_Click(Object sender, EventArgs e)
		{ ConnectServer();
		}

		private void cboProjects_SelectedIndexChanged(Object sender, EventArgs e)
		{ SelectProject(cboProjects.SelectedID);
		}
	}
}
