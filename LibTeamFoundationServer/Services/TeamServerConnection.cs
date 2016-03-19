using System;
using System.Net;

using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using Bau.Libraries.LibHelper.Extensors;
using Bau.Libraries.LibTeamFoundationServer.Model.Projects;
using Bau.Libraries.LibTeamFoundationServer.Model.Server;

namespace Bau.Libraries.LibTeamFoundationServer.Services
{
	/// <summary>
	///		Conexión a un servidor Team Foundation Server
	/// </summary>
	public class TeamServerConnection : IDisposable
	{ // Variables privadas
			private TfsTeamProjectCollection tfsTeamProject = null;
			private ProjectModelCollection objColProjects = null;


		public TeamServerConnection(string strUrl, string strCollection, string strLogin, string strPassword)
		{ Server = new ServerModel { Url = strUrl, Collection = strCollection };
			User = new UserModel { Login = strLogin, Pasword = strPassword };
		}

		public TeamServerConnection(ServerModel objServer, UserModel objUser)
		{ Server = objServer;
			User = objUser;
		}

		/// <summary>
		///		Conecta a un servidor
		/// </summary>
		public void Connect()
		{ WindowsCredential objWindowsCredentials = new WindowsCredential(new NetworkCredential(User.Login, User.Pasword));
			TfsClientCredentials objCredentials = new TfsClientCredentials(objWindowsCredentials);

				// Cierra la conexión
					Close();
				// Crea una conexión
					tfsTeamProject = new TfsTeamProjectCollection(Server.FullUrl, objCredentials);
				// Autentifica
					tfsTeamProject.Authenticate();
		}

		/// <summary>
		///		Obtiene los proyectos
		/// </summary>
		private ProjectModelCollection GetProjects()
		{ ProjectModelCollection objColProjects = new ProjectModelCollection();
			WorkItemStore objWorkItemStore = tfsTeamProject.GetService<WorkItemStore>();

				// Carga los proyectos
					foreach (Project objTfsProject in objWorkItemStore.Projects)
						{ ProjectModel objNewProject = new ProjectModel();

								// Asigna los datos
									objNewProject.ID = objTfsProject.Id;
									objNewProject.Name = objTfsProject.Name;
								// Asigna los objetos lazy
									objNewProject.Categories.AddRange(LoadCategories(objTfsProject));
								// Añade los tipos de tareas
									for (int intIndex = 0; intIndex < objTfsProject.WorkItemTypes.Count; intIndex++)
										objNewProject.TaskTypes.Add(objTfsProject.WorkItemTypes[intIndex].Name);
								// Recorre las iteraciones
									for (int intIndex = 0; intIndex < objTfsProject.IterationRootNodes.Count; intIndex++)
										{ NodeModel objNode;
											IterationModel objIteration = new IterationModel();

												// Añade el nodo
													objNode = objNewProject.Iterations.Add(null, objTfsProject.IterationRootNodes[intIndex].Id,
																																 objTfsProject.IterationRootNodes[intIndex].Name, objIteration);
												// Asigna los objetos Lazy
													objIteration.LazyTasks.LazyData = new Lazy<TaskModelCollection>(() => LoadTasksIteration(objNewProject, objNode.ID ?? 0));
										}
								// Añade los objetos Lazy
									objNewProject.LazyTasks.LazyData = new Lazy<TaskModelCollection>(() => LoadTasks(objNewProject));
								// Y lo añade a la colección
									objColProjects.Add(objNewProject);
						}
				// Devuelve los proyectos
					return objColProjects;
		}

		/// <summary>
		///		Carga las categorías de un proyecto
		/// </summary>
		private CategoryModelCollection LoadCategories(Project objTfsProject)
		{ CategoryModelCollection objColCategories = new CategoryModelCollection();

				// Carga las categorías
					if (objTfsProject != null)
						{ // Asigna las categorías
								for (int intIndex = 0; intIndex < objTfsProject.Categories.Count; intIndex++)
									{ CategoryModel objCategory = new CategoryModel();

											// Asigna los datos de la categoría
												objCategory.ID = intIndex;
												objCategory.Name = objTfsProject.Categories[intIndex].Name;
												objCategory.Description = objTfsProject.Categories[intIndex].ReferenceName;
											// Añade la categoría a la colección
												objColCategories.Add(objCategory);
											// Añade los tipos de categorías
												foreach (WorkItemType objItemType in objTfsProject.Categories[intIndex].WorkItemTypes)
													objCategory.TaskTypes.Add(new CategoryModel { Name = objItemType.Name, Description = objItemType.Description });
									}
					}
				// Devuelve la colección de categorías
					return objColCategories;
		}

		/// <summary>
		///		Carga un proyecto de TFS
		/// </summary>
		private Project LoadProjectTfs(ProjectModel objProject)
		{ WorkItemStore objWorkItemStore = tfsTeamProject.GetService<WorkItemStore>();

				// Obtiene el proyecto
					foreach (Project objTfsProject in objWorkItemStore.Projects)
						if (objTfsProject.Id == objProject.ID)
							return objTfsProject;
				// Si ha llegado hasta aquí es porque no ha encontrado nada
					return null;
		}

		/// <summary>
		///		Obtiene los WorkItems
		/// </summary>
		private TaskModelCollection LoadTasks(ProjectModel objProject)
		{ return QueryWorkItems(objProject, $"SELECT * FROM WorkItems WHERE [System.TeamProject] = '{objProject.Name}'");
		}

		/// <summary>
		///		Carga las tareas de una iteración
		/// </summary>
		private TaskModelCollection LoadTasksIteration(ProjectModel objProject, int intIDIteration)
		{ return QueryWorkItems(objProject, $"SELECT * FROM WorkItems WHERE [System.TeamProject] = '{objProject.Name}' AND [System.IterationId] = '{intIDIteration}'");
		}

		/// <summary>
		///		Consulta los elementos de trabajo y los transforma en una colección de tareas
		/// </summary>
		private TaskModelCollection QueryWorkItems(ProjectModel objProject, string strQuery)
		{	Project objTfsProject = LoadProjectTfs(objProject);
			TaskModelCollection objColTasks = new TaskModelCollection();

				// Carga las tareas del proyecto
					if (objTfsProject != null)
						{ WorkItemStore objWorkItemStore = tfsTeamProject.GetService<WorkItemStore>();
							WorkItemCollection objColWorkItems = objWorkItemStore.Query(strQuery);

								// Transforma los elementos de trabajo en tareas
									foreach (WorkItem objWorkItem in objColWorkItems)
										{ TaskModel objTask = new TaskModel();

												// Asigna los datos
													objTask.ID = objWorkItem.Id;
													objTask.Name = objWorkItem.Title; // GetWorkItemField(objWorkItem, CoreField.Title);
													objTask.Description = objWorkItem.Description; // GetWorkItemField(objWorkItem, CoreField.Description);
													objTask.IdIteration = objWorkItem.IterationId; //  GetWorkItemField(objWorkItem, CoreField.IterationId).GetInt();
													objTask.Project = objWorkItem.Project.Name; // GetWorkItemField(objWorkItem, CoreField.TeamProject);
													objTask.AssignedTo = GetWorkItemField(objWorkItem, CoreField.AssignedTo);
													objTask.DateUpdate = objWorkItem.ChangedDate; // GetWorkItemField(objWorkItem, CoreField.ChangedDate).GetDateTime();
													objTask.UserUpdate = objWorkItem.ChangedBy; // GetWorkItemField(objWorkItem, CoreField.ChangedBy);
													objTask.DateNew = objWorkItem.CreatedDate; // GetWorkItemField(objWorkItem, CoreField.CreatedDate).GetDateTime();
													objTask.UserNew = objWorkItem.CreatedBy; // GetWorkItemField(objWorkItem, CoreField.CreatedBy);
													objTask.State = objWorkItem.State; // GetWorkItemField(objWorkItem, CoreField.State);
													objTask.Tags = objWorkItem.Tags; // GetWorkItemField(objWorkItem, CoreField.Tags);
													objTask.Type = objWorkItem.Type.ToString(); // GetWorkItemField(objWorkItem, CoreField.WorkItemType);
													objTask.DateAuthorized = objWorkItem.AuthorizedDate; // GetWorkItemField(objWorkItem, CoreField.AuthorizedDate).GetDateTime();
													objTask.UserAuthorized = GetWorkItemField(objWorkItem, CoreField.AuthorizedAs);
													objTask.BoardColumn = GetWorkItemField(objWorkItem, CoreField.BoardColumn);
													objTask.BoardColumnDone = GetWorkItemField(objWorkItem, CoreField.BoardColumnDone);
													objTask.BoardLane = GetWorkItemField(objWorkItem, CoreField.BoardLane);
													objTask.LinkType =  GetWorkItemField(objWorkItem, CoreField.LinkType);
													objTask.NodeName = objWorkItem.NodeName; // GetWorkItemField(objWorkItem, CoreField.NodeName);
													objTask.Reason = objWorkItem.Reason; // GetWorkItemField(objWorkItem, CoreField.Reason);

													objTask.RelatedLinkCount = GetWorkItemField(objWorkItem, CoreField.RelatedLinkCount).GetInt(0);
												// Añade la tarea a la colección
													objColTasks.Add(objTask);

													for (int intIndex = 0; intIndex < objWorkItem.Links.Count; intIndex++)
														{ RelatedLink objLink = objWorkItem.Links[intIndex] as RelatedLink;
																
																if (objLink != null)
																	System.Diagnostics.Debug.WriteLine(objWorkItem.Id + " - " + objLink.ArtifactLinkType.Name + " -- " + 
																																		 objLink.RelatedWorkItemId + " - " + objLink.LinkTypeEnd.Name);
														}
										}

						}
				// Devuelve la colección
					return objColTasks;
		}

		/// <summary>
		///		Obtiene un campo de una consulta de elementos de trabajo
		/// </summary>
		private string GetWorkItemField(WorkItem objWorkItem, CoreField intIDField)
		{ object objValue = null;
		
				// Obtiene el valor
					if (objWorkItem.Fields.Contains((int) intIDField))
						objValue = objWorkItem.Fields[intIDField].Value;
				// Convierte el valor a una cadena
					if (objValue == null)
						return null;
					else
						return objValue.ToString();
		}

		/// <summary>
		///		Cierra la conexión
		/// </summary>
		public void Close()
		{ if (tfsTeamProject != null)
				{	tfsTeamProject.Dispose();
					tfsTeamProject = null;
				}
		}

		/// <summary>
		///		Desconecta la conexión
		/// </summary>
		public void Dispose() 
		{	Dispose(true);
			GC.SuppressFinalize(this);
		}
	
		/// <summary>
		///		Desconecta la conexión
		/// </summary>
		private void Dispose(bool blnDispose) 
		{	if (blnDispose && tfsTeamProject != null) 
				Close();
		}

		/// <summary>
		///		Destruye el objeto
		/// </summary>
	  ~TeamServerConnection() 
	  {	Dispose(false);
		}

		/// <summary>
		///		Servidor
		/// </summary>
		public ServerModel Server { get; }

		/// <summary>
		///		Usuario
		/// </summary>
		public UserModel User { get; }

		/// <summary>
		///		Proyectos cargados
		/// </summary>
		public ProjectModelCollection Projects 
		{ get
				{ // Carga los proyectos si no estaban en memoria
						if (objColProjects == null)
							objColProjects = GetProjects();
					// Devuelve la colección de proyectos
						return objColProjects;
				}
		}
	}
}
