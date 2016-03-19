using System;

namespace Bau.Libraries.LibDomain.Bussiness.Base
{
	/// <summary>
	///		Clase base para los objetos de negocio
	/// </summary>
	public abstract class BaseBussiness<TypeModel> where TypeModel : Model.Base.BaseModel, new()
	{
		/// <summary>
		///		Carga los datos de un objeto <see cref="TypeModel"/>
		/// </summary>
		public virtual TypeModel Load(int? intID)
		{ return Repository.Load(intID);
		}

		/// <summary>
		///		Graba los datos de un objeto <see cref="TypeModel"/>
		/// </summary>
		public virtual void Save(TypeModel objData)
		{ Repository.Save(objData);
		}

		/// <summary>
		///		Comprueba si se pueden borrar los datos de un objeto <see cref="TypeModel"/>
		/// </summary>
		public virtual bool CanDelete(TypeModel objData)
		{ return Repository.CanDelete(objData.ID);
		}

		/// <summary>
		///		Borra los datos de un objeto <see cref="TypeModel"/>
		/// </summary>
		public virtual void Delete(TypeModel objData)
		{ Repository.Delete(objData.ID);
		}

		/// <summary>
		///		Borra los datos de un registro
		/// </summary>
		public virtual void Delete(int? intID)
		{ Repository.Delete(intID);
		}

		/// <summary>
		///		Repository de <see cref="TypeModel"/>
		/// </summary>
		protected Model.Base.Interfaces.IRepository<TypeModel> Repository { get; set; }
	}
}
