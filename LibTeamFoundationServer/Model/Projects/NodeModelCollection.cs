using System;

namespace Bau.Libraries.LibTeamFoundationServer.Model.Projects
{
	/// <summary>
	///		Colección de <see cref="NodeModel"/>
	/// </summary>
	public class NodeModelCollection : LibDomain.Model.Base.BaseExtendedModelCollection<NodeModel>
	{
		/// <summary>
		///		Añade un nodo
		/// </summary>
		public NodeModel Add(NodeModel objParent, int intID, string strName, LibDomain.Model.Base.BaseModel objTag, string strDescription = null)
		{ NodeModel objNode = new NodeModel(objParent, intID, strName, objTag, strDescription);

				// Añade el nodo a la colección
					Add(objNode);
				// Devuelve el nodo añadido
					return objNode;
		}

		/// <summary>
		///		Busca recursivamente un nodo
		/// </summary>
		public NodeModel SearchRecursive(int intID)
		{ NodeModel objFound = null;

				// Busca el nodo
					foreach (NodeModel objNode in this)
						if (objFound == null)
							{ if (objNode.ID == intID)
									objFound = objNode;
								else
									objFound = objNode.Childs.SearchRecursive(intID);
							}
				// Devuelve el nodo encontrado
					return objFound;
		}
	}
}
