using System;

using Bau.Libraries.LibHelper.Extensors;

namespace Bau.Libraries.LibDomain.Model.Base
{
	/// <summary>
	///		Colección de <see cref="BaseExtendedModel"/>
	/// </summary>
	public class BaseExtendedModelCollection<TypeData> : BaseModelCollection<TypeData> where TypeData : BaseExtendedModel
	{
		/// <summary>
		///		Ordena por nombre
		/// </summary>
		public void SortByName(bool blnAscending = true)
		{ Sort(new Comparers.BaseExtendedModelComparerByName(blnAscending));
		}

		/// <summary>
		///		Busca un registro en la colección a partir del nombre (si no lo encuentra devuelve un registro vacío, no un nulo)
		/// </summary>
		public virtual TypeData SearchByName(string strName, bool blnIgnoreAccents = true) 
		{ // Normaliza el nombre a buscar
				if (!string.IsNullOrEmpty(strName))
					strName = strName.Trim();
			// Busca el nombre en la colección
				foreach (TypeData objRecord in this)
					if (objRecord.Name.EqualsIgnoreCase(strName))
						return objRecord;
					else if (blnIgnoreAccents && objRecord.Name.NormalizeAccents().EqualsIgnoreCase(strName.NormalizeAccents()))
						return objRecord;
			// Si ha llegado hasta aquí es porque no ha encontrado nada
				return null;
		}
	}
}
