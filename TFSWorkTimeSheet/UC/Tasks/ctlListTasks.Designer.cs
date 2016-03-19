namespace Bau.Applications.TFSWorkTimeSheet.UC.Tasks
{
	partial class ctlListTasks
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.lswTasks = new Bau.Controls.List.ListUpdatable();
			this.SuspendLayout();
			// 
			// lswTasks
			// 
			this.lswTasks.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lswTasks.Location = new System.Drawing.Point(0, 0);
			this.lswTasks.MultiSelect = true;
			this.lswTasks.Name = "lswTasks";
			this.lswTasks.ShowItemToolTips = false;
			this.lswTasks.Size = new System.Drawing.Size(549, 361);
			this.lswTasks.TabIndex = 0;
			this.lswTasks.WithDelete = false;
			this.lswTasks.WithNew = false;
			this.lswTasks.WithUpdate = false;
			// 
			// ctlListTasks
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.lswTasks);
			this.Name = "ctlListTasks";
			this.Size = new System.Drawing.Size(549, 361);
			this.ResumeLayout(false);

		}

		#endregion

		private Controls.List.ListUpdatable lswTasks;
	}
}
