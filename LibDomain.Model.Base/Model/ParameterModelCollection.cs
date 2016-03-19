using System;
using System.Collections.Generic;

namespace Bau.Libraries.LibDomain.Model.Base
{
	/// <summary>
	///		Colección de <see cref="ParameterModel"/>
	/// </summary>
	public class ParameterModelCollection : List<ParameterModel>
	{
		/// <summary>
		///		Añade un parámetro a la colección
		/// </summary>
		public ParameterModel Add(string strName, string strValue)
		{ ParameterModel objParameter = new ParameterModel { Name = strName, Value = strValue };

				// Añade el parámetro
					Add(objParameter);
				// Devuelve el parámetro
					return objParameter;
		}
	}
}
