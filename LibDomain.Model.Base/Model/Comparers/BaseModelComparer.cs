using System;
using System.Collections.Generic;

namespace Bau.Libraries.LibDomain.Model.Base.Comparers
{
	/// <summary>
	///		Comparador de <see cref="CallModel"/>
	/// </summary>
	internal class BaseModelComparer : AbstractBaseComparer<BaseModel>
	{
		internal BaseModelComparer(bool blnAscending) : base(blnAscending) {}

		/// <summary>
		///		Compara dos elementos por ID
		/// </summary>
		protected override int CompareData(BaseModel objFirst, BaseModel objSecond)
		{ return (objFirst.ID ?? 0).CompareTo(objSecond.ID ?? 0);
		}
	}
}