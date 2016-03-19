using System;

namespace Bau.Libraries.LibDomain.Model.Base
{
	/// <summary>
	///		Objetos Lazy
	/// </summary>
	/// <remarks>
	///		TypeData desciende de class en lugar de <see cref="BaseModel"/>  porque también se pueden definir desde
	///	<see cref="BaseModelCollection"/> 
	/// </remarks>
	public class LazyObject<TypeData> where TypeData : class, new()
	{ // Variables privadas
			private int? intID;
			private int intIDEntityType;
			private TypeData objData;

		public LazyObject()
		{ IsAssigned = false;
		}

		/// <summary>
		///		ID asociada a un elemento Lazy
		/// </summary>
		public int? ID
		{ get
				{ if (IsAssigned)
						{ BaseModel objData = Data as BaseModel;

								if (objData != null)
									return objData.ID;
								else
									return null;
						}
					else
						return intID;
				}
			set { intID = value; }
		}

		/// <summary>
		///		Código del tipo de entidad
		/// </summary>
		public int IDEntityType
		{ get
				{ if (IsAssigned)
						{ BaseModel objData = Data as BaseModel;

								if (objData != null)
									return objData.IDEntityType;
								else
									return 0;
						}
					else
						return intIDEntityType;
				}
			set { intIDEntityType = value; }
		}

		/// <summary>
		///		Datos asociados (Lazy)
		/// </summary>
		public Lazy<TypeData> LazyData { get; set; }

		/// <summary>
		///		Datos asociados
		/// </summary>
		public TypeData Data
		{ get 
				{ // Carga los datos si no estaban en memoria
						if (!IsAssigned && objData == null)
							{ // Carga desde el objeto Lazy o lo crea de nuevo
									if (LazyData != null && LazyData.Value != null)
										objData = LazyData.Value;
									else
										objData = new TypeData();
								// Indica que se ha asignado el valor
									IsAssigned = true;
							}
					// Devuelve el objeto
						return objData;
				}
			set 
				{ // Asigna el valor
						objData = value;
					// Quita los métodos Lazy
						LazyData = null;
					// Indica que ya se ha asignado el valor
						IsAssigned = true;
				}
		}

		/// <summary>
		///		Indica si se han asignado los datos
		/// </summary>
		public bool IsAssigned { get; private set; }
	}
}
