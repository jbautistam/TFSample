using System;
using System.Windows.Forms;

using Bau.Libraries.LibTeamFoundationServer.Model.Projects;

namespace Bau.Applications.TFSWorkTimeSheet.UC.Tasks
{
	/// <summary>
	///		Control con un árbol de proyecto
	/// </summary>
	public partial class ctlTreeProject : UserControl
	{ // Enumerados privados
			private enum NodeType
				{ CategoryRoot,
					Category,
					TaskTypeRoot,
					TaskType,
					IterationsRoot,
					Iteration,
					Sprint,
					Task
				}

		public ctlTreeProject()
		{ InitializeComponent();
		}

		/// <summary>
		///		Inicializa el control
		/// </summary>
		public void InitControl()
		{	trvProject.Nodes.Clear();
		}

		/// <summary>
		///		Carga los datos de un proyecto
		/// </summary>
		public void LoadProject(ProjectModel objProject)
		{ // Asigna el projecto
				Project = objProject;
			// Limpia
				InitControl();
			// Carga los datos
				trvProject.BeginUpdate();
				trvProject.AddNode(null, GetNodeKey(NodeType.CategoryRoot, 0), "Categorías", true, 0, System.Drawing.Color.Red, true);
				LoadTaskTypes(objProject);
				LoadIterations(objProject);
				trvProject.EndUpdate();
		}

		/// <summary>
		///		Carga los nodos hijo de un árbol
		/// </summary>
		private void LoadChildNodes(TreeNode trnNode)
		{ Controls.Tree.TreeNodeKey objKey = trvProject.GetKey(trnNode);

				// Dependiendo del tipo de nodo ...
					switch ((NodeType) objKey.IDType)	
						{	case NodeType.CategoryRoot:
									LoadCategories(trnNode);
								break;
							case NodeType.Iteration:
									LoadTasksByIteration(trnNode, objKey.ID ?? 0);
								break;
						}	
		}

		/// <summary>
		///		Muestra los nodos de categorías
		/// </summary>
		private void LoadCategories(TreeNode trnParent)
		{ foreach (CategoryModel objCategory in Project.Categories)
				{ TreeNode trnCategory = trvProject.AddNode(trnParent, GetNodeKey(NodeType.Category, objCategory.ID), 
																										objCategory.Name, false, 0, System.Drawing.Color.Navy, true);

						// Añade los tipos
							foreach (CategoryModel objTaskType in objCategory.TaskTypes)
								trvProject.AddNode(trnCategory, GetNodeKey(NodeType.TaskType, objTaskType.ID),
																		objTaskType.Name, false, 0, System.Drawing.Color.Maroon, true);
				}
		}

		/// <summary>
		///		Añade los tipos de tareas
		/// </summary>
		private void LoadTaskTypes(ProjectModel objProject)
		{ TreeNode trnNode = trvProject.AddNode(null, GetNodeKey(NodeType.TaskTypeRoot, 0), "Tipos de tareas", false, 0, System.Drawing.Color.Red, true);

				// Añade las categorías
					foreach (string strTaskType in objProject.TaskTypes)
						trvProject.AddNode(trnNode, GetNodeKey(NodeType.TaskType, 0), strTaskType, false);
		}

		/// <summary>
		///		Muestra los nodos de iteraciones
		/// </summary>
		private void LoadIterations(ProjectModel objProject)
		{ TreeNode trnNode = trvProject.AddNode(null, GetNodeKey(NodeType.IterationsRoot, 0), "Iteraciones", false, 0, System.Drawing.Color.Red, true);

				// Añade las categorías
					foreach (NodeModel objIteration in objProject.Iterations)
						trvProject.AddNode(trnNode, GetNodeKey(NodeType.Iteration, objIteration.ID), 
															 objIteration.Name, true, 0, System.Drawing.Color.Navy, true);
		}

		/// <summary>
		///		Carga las tareas de una iteración
		/// </summary>
		private void LoadTasksByIteration(TreeNode trnParent, int intID)
		{ NodeModel objNode = Project.Iterations.SearchRecursive(intID);

				// Si hay alguna iteración
					if (objNode != null)
						{ IterationModel objIteration = objNode.Tag as IterationModel;

								if (objIteration != null)
									foreach (TaskModel objTask in objIteration.Tasks)
										trvProject.AddNode(trnParent, GetNodeKey(NodeType.Task, objTask.ID),
																			 objTask.Name, true, 0, System.Drawing.Color.Black, false);
						}
		}

		/// <summary>
		///		Obtiene una clave de nodo
		/// </summary>
		private Controls.Tree.TreeNodeKey GetNodeKey(NodeType intIDNode, int? intID)
		{ return new Controls.Tree.TreeNodeKey((int) intIDNode, intID);
		}

		/// <summary>
		///		Proyecto que se está visualizando en el control
		/// </summary>
		private ProjectModel Project { get; set; }

		private void trvProject_LoadChilds(object objSender, Controls.Tree.TreeViewExtendedEventArgs evnArgs)
		{ LoadChildNodes(evnArgs.Node);
		}
	}
}
