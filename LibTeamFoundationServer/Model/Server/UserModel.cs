using System;

namespace Bau.Libraries.LibTeamFoundationServer.Model.Server
{
	/// <summary>
	///		Clase con los datos de un usuario
	/// </summary>
	public class UserModel : LibDomain.Model.Base.BaseExtendedModel
	{
		/// <summary>
		///		Login
		/// </summary>
		public string Login { get; set; }

		/// <summary>
		///		Contraseña
		/// </summary>
		public string Pasword { get; set; }
	}
}
