using System;

namespace Bau.Libraries.LibDomain.Model.Base
{
	/// <summary>
	///		Clase base
	/// </summary>
	public class BaseModel
	{	// Variables privadas
			private string strID;

		/// <summary>
		///		Comprueba si un objeto es nulo (o está vacío)
		/// </summary>
		public static bool IsNull(BaseModel objBase)
		{ return objBase == null || objBase.ID == null;
		}

		/// <summary>
		///		Asigna un valor a otro si no tienen la misma referencia y en su caso lanza el evento de 
		///	modificación de propiedad (para objetos LazyObject&lt;BaseModel&gt;)
		/// </summary>
		protected void CheckProperty<TypeData>(LazyObject<TypeData> objTarget, TypeData objValue) where TypeData : BaseModel, new()
		{	if (!objTarget.IsAssigned || !ReferenceEquals(objTarget.Data, objValue))
				objTarget.Data = objValue;
		}

		/// <summary>
		///		Asigna un valor a otro si no tienen la mismma referencia y en su caso lanza el evento de 
		///	modificación de propiedad (para objetos LazyObject&lt;BaseModelCollection&gt;)
		/// </summary>
		protected void CheckProperty<TypeCollection, TypeData>(LazyObject<TypeCollection> objColTarget, TypeCollection objColValue) 
												where TypeCollection : BaseModelCollection<TypeData>, new()
												where TypeData : BaseModel, new()
		{	if (!objColTarget.IsAssigned || !ReferenceEquals(objColTarget.Data, objColValue))
				objColTarget.Data = objColValue;
		}

		/// <summary>
		///		ID del elemento
		/// </summary>
		public int? ID { get; set; }

		/// <summary>
		///		ID global alfanumérico
		/// </summary>
		public string GlobalID
		{ get 
				{ // Si no se ha definido ningún ID se crea uno
						if (string.IsNullOrEmpty(strID))
							strID = Guid.NewGuid().ToString();
					// Devuelve el ID
						return strID;
				}
			set { strID = value; }
		}					

		/// <summary>
		///		Tipo de entidad
		/// </summary>
		public virtual int IDEntityType { get; }

		/// <summary>
		///		Indica si el elemento se considera vacío (aún no se ha grabado)
		/// </summary>
		public bool IsEmpty
		{ get { return ID == null; }
		}
	}
}
