using System;
using System.Net;
using System.Windows.Forms;

using Bau.Controls.Forms;
using Bau.Libraries.LibHelper.Extensors;

namespace Bau.Applications.TFSWorkTimeSheet
{
	/// <summary>
	///		Formulario principal de la aplicación
	/// </summary>
	public partial class frmLogin : Form
	{ 
		public frmLogin()
		{	InitializeComponent();
		}

		/// <summary>
		///		Inicializa el formulario
		/// </summary>
		private void InitForm()
		{ // Inicializa los controles
				txtUrl.Text = Configuration.Server;
				txtCollection.Text = Configuration.Collection;
				txtLogin.Text = Configuration.User;
				txtPassword.Text = Configuration.Password;
		}

		/// <summary>
		///		Comprueba los datos introducidos
		/// </summary>
		private bool ValidateData()
		{ bool blnValidate = false;

				// Comprueba los datos
					if (txtUrl.Text.IsEmpty())
						Helper.ShowMessage(this, "Introduzca la Url del servidor");
					else if (txtCollection.Text.IsEmpty())
						Helper.ShowMessage(this, "Introduzca la colección predeterminada");
					else if (txtLogin.Text.IsEmpty())
						Helper.ShowMessage(this, "Introduzca el código de usuario");
					else if (txtPassword.Text.IsEmpty())
						Helper.ShowMessage(this, "Introduzca la contraseña del usuario");
					else
						blnValidate = true;
				// Devuelve el valor que indica si es correcto
					return blnValidate;
		}

		/// <summary>
		///		Conecta con el servidor TFS
		/// </summary>
		private void Connect()
		{	if (ValidateData())
				{	// Graba la configuración
						SaveConfiguration();
					// Cierra el formulario
						DialogResult = DialogResult.OK;
						Close();
			}
		}

		/// <summary>
		///		Graba la configuración
		/// </summary>
		private void SaveConfiguration()
		{ // Asigna los valores de los cuadros de texto a la configuración
				Configuration.Server = txtUrl.Text;
				Configuration.Collection = txtCollection.Text;
				Configuration.User = txtLogin.Text;
				Configuration.Password = txtPassword.Text;
			// Graba la configuración
				Configuration.Save();
		}

		private void cmdConnect_Click(Object sender, EventArgs e)
		{ Connect();
		}

		private void frmMain_Load(Object sender, EventArgs e)
		{ InitForm();
		}
	}
}
