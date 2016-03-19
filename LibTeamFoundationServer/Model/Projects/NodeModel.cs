using System;

namespace Bau.Libraries.LibTeamFoundationServer.Model.Projects
{
	/// <summary>
	///		Clase con los datos de un nodo
	/// </summary>
	public class NodeModel : LibDomain.Model.Base.BaseExtendedModel
	{
		public NodeModel(NodeModel objParent, int intID, string strName, LibDomain.Model.Base.BaseModel objTag, string strDescription = null)
		{ Parent = objParent;
			ID = intID;
			Name = strName;
			Tag = objTag;
			Description = strDescription;
		}

		/// <summary>
		///		Nodo padre
		/// </summary>
		public NodeModel Parent { get; }

		/// <summary>
		///		Elemento asociado al nodo
		/// </summary>
		public LibDomain.Model.Base.BaseModel Tag { get; }

		/// <summary>
		///		Nodos hijo
		/// </summary>
		public NodeModelCollection Childs { get; } = new NodeModelCollection();
	}
}
