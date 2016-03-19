namespace Bau.Applications.TFSWorkTimeSheet
{
	partial class frmMain
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.cmdConnect = new System.Windows.Forms.ToolStripButton();
			this.cboProjects = new Bau.Controls.Combos.ComboBoxExtended();
			this.udtProject = new Bau.Applications.TFSWorkTimeSheet.UC.Tasks.ctlProjectController();
			this.statusStrip1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
			this.statusStrip1.Location = new System.Drawing.Point(0, 622);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(735, 22);
			this.statusStrip1.TabIndex = 0;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// lblStatus
			// 
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(65, 17);
			this.lblStatus.Text = "Conectado";
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdConnect});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(735, 25);
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// cmdConnect
			// 
			this.cmdConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.cmdConnect.Image = global::Bau.Applications.TFSWorkTimeSheet.Properties.Resources.Connect;
			this.cmdConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cmdConnect.Name = "cmdConnect";
			this.cmdConnect.Size = new System.Drawing.Size(23, 22);
			this.cmdConnect.Text = "Cambiar conexión";
			this.cmdConnect.Click += new System.EventHandler(this.cmdConnect_Click);
			// 
			// cboProjects
			// 
			this.cboProjects.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cboProjects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboProjects.FormattingEnabled = true;
			this.cboProjects.Location = new System.Drawing.Point(301, 4);
			this.cboProjects.Name = "cboProjects";
			this.cboProjects.SelectedID = null;
			this.cboProjects.Size = new System.Drawing.Size(422, 21);
			this.cboProjects.TabIndex = 3;
			this.cboProjects.SelectedIndexChanged += new System.EventHandler(this.cboProjects_SelectedIndexChanged);
			// 
			// udtProject
			// 
			this.udtProject.Dock = System.Windows.Forms.DockStyle.Fill;
			this.udtProject.Location = new System.Drawing.Point(0, 25);
			this.udtProject.Name = "udtProject";
			this.udtProject.Size = new System.Drawing.Size(735, 597);
			this.udtProject.TabIndex = 4;
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(735, 644);
			this.Controls.Add(this.udtProject);
			this.Controls.Add(this.cboProjects);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.statusStrip1);
			this.Name = "frmMain";
			this.Text = "WorkTimeSheet";
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel lblStatus;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton cmdConnect;
		private Controls.Combos.ComboBoxExtended cboProjects;
		private UC.Tasks.ctlProjectController udtProject;
	}
}