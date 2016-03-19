using System;
using System.Windows.Forms;

using Bau.Applications.TFSWorkTimeSheet.Classes;
using Bau.Libraries.LibTeamFoundationServer.Model.Projects;

namespace Bau.Applications.TFSWorkTimeSheet.UC.Tasks
{
	/// <summary>
	///		Control con la lista de tares
	/// </summary>
	public partial class ctlListTasks : UserControl
	{
		public ctlListTasks()
		{ InitializeComponent();
		}

		/// <summary>
		///		Inicializa el control
		/// </summary>
		internal void InitControl()
		{ // Limpia la lista
				lswTasks.Clear();
			// Añade las columnas
				lswTasks.AddColumn(300, "Tarea");
				lswTasks.AddColumn(100, "Tipo");
				lswTasks.AddColumn(200, "Asignado");
				lswTasks.AddColumn(150, "Alta");
				lswTasks.AddColumn(150, "Modificación");
				lswTasks.AddColumn(150, "Aprobación");

				lswTasks.AddColumn(150, "NodeName");
				lswTasks.AddColumn(150, "LinkType");
				lswTasks.AddColumn(150, "RelatedLinkCount");


				lswTasks.AddColumn(150, "BoardColumn");
				lswTasks.AddColumn(150, "BoardLane");
				lswTasks.AddColumn(150, "BoardColumnDone");
		}

		/// <summary>
		///		Carga la lista de tareas
		/// </summary>
		internal void LoadTasks(TaskModelCollection objColTasks)
		{ // Inicializa la lista
				InitControl();
			// Carga la lista
				foreach (TaskModel objTask in objColTasks)
					{ ListViewItem lsiItem = lswTasks.AddRecord(objTask.ID.ToString(), objTask.Name);

							// Añade los elementos
								lsiItem.SubItems.Add(objTask.Type);
								lsiItem.SubItems.Add(objTask.AssignedTo);
								lsiItem.SubItems.Add(FormatHelper.Format(objTask.DateNew));
								lsiItem.SubItems.Add(FormatHelper.Format(objTask.DateUpdate));
								lsiItem.SubItems.Add(FormatHelper.Format(objTask.DateAuthorized));

								lsiItem.SubItems.Add(objTask.NodeName);
								lsiItem.SubItems.Add(objTask.LinkType);
								lsiItem.SubItems.Add(objTask.RelatedLinkCount.ToString());
								lsiItem.SubItems.Add(objTask.BoardColumn);
								lsiItem.SubItems.Add(objTask.BoardLane);
								lsiItem.SubItems.Add(objTask.BoardColumnDone);
          }
		}
	}
}
