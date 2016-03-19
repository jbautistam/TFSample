using System;
using System.Collections.Generic;

namespace Bau.Libraries.LibDomain.Model.Base.Comparers
{
	/// <summary>
	///		Comparador de <see cref="BaseExtendelModel"/>
	/// </summary>
	internal class BaseExtendedModelComparerByName : AbstractBaseComparer<BaseExtendedModel>
	{
		internal BaseExtendedModelComparerByName(bool blnAscending) : base(blnAscending) {}

		/// <summary>
		///		Compara dos elementos por nombre
		/// </summary>
		protected override int CompareData(BaseExtendedModel objFirst, BaseExtendedModel objSecond)
		{ return (objFirst.Name + "").CompareTo(objSecond.Name + "");
		}
	}
}