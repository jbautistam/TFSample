using System;

using Bau.Libraries.LibHelper.Extensors;

namespace Bau.Applications.TFSWorkTimeSheet
{
	/// <summary>
	///		Clase con los datos de configuración
	/// </summary>
	public static class Configuration
	{
		/// <summary>
		///		Graba la configuración
		/// </summary>
		public static void Save()
		{ Properties.Settings.Default.Save();
		}

		/// <summary>
		///		Servidor
		/// </summary>
		public static string Server 
		{ get { return Properties.Settings.Default.Server; }
			set { Properties.Settings.Default.Server = value; }
		}

		/// <summary>
		///		Colección
		/// </summary>
		public static string Collection
		{ get 
				{ string strCollection = Properties.Settings.Default.Collection; 

						// Obtiene la colección predetermianda si no existía
							if (strCollection.IsEmpty())
								strCollection = "DefaultCollection";
						// Devuelve la colección 
							return strCollection;
				}
			set { Properties.Settings.Default.Collection = value; }
		}

		/// <summary>
		///		Usuario
		/// </summary>
		public static string User
		{ get { return Properties.Settings.Default.User; }
			set { Properties.Settings.Default.User = value; }
		}

		/// <summary>
		///		Contraseña
		/// </summary>
		public static string Password
		{ get { return Properties.Settings.Default.Password; }
			set { Properties.Settings.Default.Password = value; }
		}

		/// <summary>
		///		Código del último proyecto seleccionado
		/// </summary>
		public static int IDLastProject
		{ get { return Properties.Settings.Default.IDLastProject; }
			set { Properties.Settings.Default.IDLastProject = value; }
		}
	}
}
