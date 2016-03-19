using System;

namespace Bau.Libraries.LibDomain.Model.Base.Interfaces
{
	/// <summary>
	///		Interface genérico para las clases de Repository
	/// </summary>
	public interface IRepository<TypeData>
	{
		/// <summary>
		///		Carga un registro a partir de su ID
		/// </summary>
		TypeData Load(int? intID);

		/// <summary>
		///		Graba un registro
		/// </summary>
		void Save(TypeData objData);

		/// <summary>
		///		Comprueba si puede borrar un objeto
		/// </summary>
		bool CanDelete(int? intID);

		/// <summary>
		///		Borra un objeto
		/// </summary>
		void Delete(int? intID);
	}
}
