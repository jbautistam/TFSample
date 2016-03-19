using System;

namespace Bau.Applications.TFSWorkTimeSheet.Classes
{
	/// <summary>
	///		Formato
	/// </summary>
	public static class FormatHelper
	{
		/// <summary>
		///		Formatea una fecha
		/// </summary>
		public static string Format(DateTime? dtmValue, bool blnWithHours = true)
		{ if (dtmValue == null)
				return "-";
			else if (blnWithHours)
				return string.Format("{0:dd-MM-yyyy HH:mm}", dtmValue);
			else
				return string.Format("{0:dd-MM-yyyy}", dtmValue);
		}
	}
}
