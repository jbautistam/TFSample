namespace Bau.Applications.TFSWorkTimeSheet.UC.Tasks
{
	partial class ctlProjectController
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
			this.udtTreeProjects = new Bau.Applications.TFSWorkTimeSheet.UC.Tasks.ctlTreeProject();
			this.collapsiblePanelSplitter1 = new Bau.Controls.Split.CollapsiblePanelSplitter();
			this.udtListTasks = new Bau.Applications.TFSWorkTimeSheet.UC.Tasks.ctlListTasks();
			((System.ComponentModel.ISupportInitialize)(this.collapsiblePanelSplitter1)).BeginInit();
			this.collapsiblePanelSplitter1.Panel1.SuspendLayout();
			this.collapsiblePanelSplitter1.Panel2.SuspendLayout();
			this.collapsiblePanelSplitter1.SuspendLayout();
			this.SuspendLayout();
			// 
			// udtTreeProjects
			// 
			this.udtTreeProjects.Dock = System.Windows.Forms.DockStyle.Fill;
			this.udtTreeProjects.Location = new System.Drawing.Point(0, 0);
			this.udtTreeProjects.Name = "udtTreeProjects";
			this.udtTreeProjects.Size = new System.Drawing.Size(196, 582);
			this.udtTreeProjects.TabIndex = 0;
			// 
			// collapsiblePanelSplitter1
			// 
			this.collapsiblePanelSplitter1.BackColorSplitter = System.Drawing.SystemColors.Control;
			this.collapsiblePanelSplitter1.CollapseAction = Bau.Controls.Split.CollapsiblePanelSplitter.CollapseMode.CollapsePanel1;
			this.collapsiblePanelSplitter1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.collapsiblePanelSplitter1.Location = new System.Drawing.Point(0, 0);
			this.collapsiblePanelSplitter1.Name = "collapsiblePanelSplitter1";
			// 
			// collapsiblePanelSplitter1.Panel1
			// 
			this.collapsiblePanelSplitter1.Panel1.Controls.Add(this.udtTreeProjects);
			this.collapsiblePanelSplitter1.Panel1MinSize = 0;
			// 
			// collapsiblePanelSplitter1.Panel2
			// 
			this.collapsiblePanelSplitter1.Panel2.Controls.Add(this.udtListTasks);
			this.collapsiblePanelSplitter1.Panel2MinSize = 0;
			this.collapsiblePanelSplitter1.Size = new System.Drawing.Size(589, 582);
			this.collapsiblePanelSplitter1.SplitterDistance = 196;
			this.collapsiblePanelSplitter1.SplitterStyle = Bau.Controls.Split.CollapsiblePanelSplitter.VisualStyles.Mozilla;
			this.collapsiblePanelSplitter1.SplitterWidth = 8;
			this.collapsiblePanelSplitter1.TabIndex = 1;
			// 
			// udtListTasks
			// 
			this.udtListTasks.Dock = System.Windows.Forms.DockStyle.Fill;
			this.udtListTasks.Location = new System.Drawing.Point(0, 0);
			this.udtListTasks.Name = "udtListTasks";
			this.udtListTasks.Size = new System.Drawing.Size(385, 582);
			this.udtListTasks.TabIndex = 0;
			// 
			// ctlProjectController
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.collapsiblePanelSplitter1);
			this.Name = "ctlProjectController";
			this.Size = new System.Drawing.Size(589, 582);
			this.collapsiblePanelSplitter1.Panel1.ResumeLayout(false);
			this.collapsiblePanelSplitter1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.collapsiblePanelSplitter1)).EndInit();
			this.collapsiblePanelSplitter1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private ctlTreeProject udtTreeProjects;
		private Controls.Split.CollapsiblePanelSplitter collapsiblePanelSplitter1;
		private ctlListTasks udtListTasks;
	}
}
