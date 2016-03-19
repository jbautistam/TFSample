using System;

using Bau.Libraries.LibHelper.Extensors;

namespace Bau.Libraries.LibTeamFoundationServer.Model.Server
{
	/// <summary>
	///		Clase con los datos de un servidor
	/// </summary>
	public class ServerModel : LibDomain.Model.Base.BaseExtendedModel
	{
		/// <summary>
		///		Url de conexión
		/// </summary>
		public string Url { get; set; }

		/// <summary>
		///		Colección
		/// </summary>
		public string Collection { get; set; }

		/// <summary>
		///		Url completa de conexión
		/// </summary>
		public Uri FullUrl 
		{ get
				{ string strUrl = Url;
					string strCollection = Collection;

						// Normaliza la URL
							if (!strUrl.IsEmpty())
								{ // Sustituye las \ por /
										strUrl = strUrl.Replace('\\', '/');
									// Quita las / finales
										while (!strUrl.IsEmpty() && strUrl.EndsWith("/"))
											strUrl = strUrl.Left(strUrl.Length - 1);
								}
						// Normaliza la colección
							if (!strCollection.IsEmpty())
								{ // Sustituyue las \ por /
										strCollection = strCollection.Replace('\\', '/');
									// quita las / iniciales
										while (!strCollection.IsEmpty() && strCollection.StartsWith("/"))
											strCollection = strCollection.Right(strCollection.Length - 1);
								}
						// Devuelve la Url
							return new Uri(strUrl.AddWithSeparator(strCollection, "/", false));
				}
		}
	}
}
