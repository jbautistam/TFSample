namespace Bau.Applications.TFSWorkTimeSheet.UC.Tasks
{
	partial class ctlTreeProject
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
			this.trvProject = new Bau.Controls.Tree.TreeViewExtended();
			this.SuspendLayout();
			// 
			// trvProject
			// 
			this.trvProject.CheckRecursive = false;
			this.trvProject.Dock = System.Windows.Forms.DockStyle.Fill;
			this.trvProject.Location = new System.Drawing.Point(0, 0);
			this.trvProject.Name = "trvProject";
			this.trvProject.ShowNodeToolTips = true;
			this.trvProject.Size = new System.Drawing.Size(384, 493);
			this.trvProject.TabIndex = 0;
			this.trvProject.LoadChilds += new Bau.Controls.Tree.TreeViewExtended.LoadChildsHandler(this.trvProject_LoadChilds);
			// 
			// ctlTreeProject
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.trvProject);
			this.Name = "ctlTreeProject";
			this.Size = new System.Drawing.Size(384, 493);
			this.ResumeLayout(false);

		}

		#endregion

		private Controls.Tree.TreeViewExtended trvProject;
	}
}
