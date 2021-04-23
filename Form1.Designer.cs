
using System.Windows.Forms;

namespace KeyboardRecord {
	partial class Form1 {
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.clear = new System.Windows.Forms.Button();
			this.status = new System.Windows.Forms.Button();
			this.explore = new System.Windows.Forms.Button();
			this.keyList = new System.Windows.Forms.ListView();
			this.id = new System.Windows.Forms.ColumnHeader();
			this.keyName = new System.Windows.Forms.ColumnHeader();
			this.key = new System.Windows.Forms.ColumnHeader();
			this.count = new System.Windows.Forms.ColumnHeader();
			this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.show = new System.Windows.Forms.ToolStripMenuItem();
			this.exit = new System.Windows.Forms.ToolStripMenuItem();
			this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.contextMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// clear
			// 
			resources.ApplyResources(this.clear, "clear");
			this.clear.Name = "clear";
			this.clear.UseVisualStyleBackColor = true;
			this.clear.Click += new System.EventHandler(this.clear_Click);
			// 
			// status
			// 
			resources.ApplyResources(this.status, "status");
			this.status.Name = "status";
			this.status.UseVisualStyleBackColor = true;
			this.status.Click += new System.EventHandler(this.status_Click);
			// 
			// explore
			// 
			resources.ApplyResources(this.explore, "explore");
			this.explore.Name = "explore";
			this.explore.UseVisualStyleBackColor = true;
			this.explore.Click += new System.EventHandler(this.explore_Click);
			// 
			// keyList
			// 
			resources.ApplyResources(this.keyList, "keyList");
			this.keyList.AutoArrange = false;
			this.keyList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.keyName,
            this.key,
            this.count});
			this.keyList.HideSelection = false;
			this.keyList.Name = "keyList";
			this.keyList.UseCompatibleStateImageBehavior = false;
			this.keyList.View = System.Windows.Forms.View.Details;
			this.keyList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.keyList_SelectedIndexChanged);
			// 
			// id
			// 
			resources.ApplyResources(this.id, "id");
			// 
			// keyName
			// 
			resources.ApplyResources(this.keyName, "keyName");
			// 
			// key
			// 
			resources.ApplyResources(this.key, "key");
			// 
			// count
			// 
			resources.ApplyResources(this.count, "count");
			// 
			// contextMenu
			// 
			resources.ApplyResources(this.contextMenu, "contextMenu");
			this.contextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.show,
            this.exit});
			this.contextMenu.Name = "contextMenu";
			// 
			// show
			// 
			resources.ApplyResources(this.show, "show");
			this.show.Name = "show";
			// 
			// exit
			// 
			resources.ApplyResources(this.exit, "exit");
			this.exit.Name = "exit";
			// 
			// notifyIcon
			// 
			resources.ApplyResources(this.notifyIcon, "notifyIcon");
			this.notifyIcon.ContextMenuStrip = this.contextMenu;
			this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.IconDoubleClick);
			// 
			// Form1
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.keyList);
			this.Controls.Add(this.status);
			this.Controls.Add(this.explore);
			this.Controls.Add(this.clear);
			this.Name = "Form1";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormClosing);
			this.Load += new System.EventHandler(this.MainLoad);
			this.SizeChanged += new System.EventHandler(this.MainSizeChanged);
			this.contextMenu.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button clear;
		private System.Windows.Forms.Button explore;
		private System.Windows.Forms.Button status;
		public System.Windows.Forms.ListView keyList;
		private System.Windows.Forms.ColumnHeader id;
		private System.Windows.Forms.ColumnHeader keyName;
		private System.Windows.Forms.ColumnHeader key;
		private System.Windows.Forms.ColumnHeader count;
		private System.Windows.Forms.ContextMenuStrip contextMenu;
		private System.Windows.Forms.ToolStripMenuItem exit;
		private System.Windows.Forms.NotifyIcon notifyIcon;
		private System.Windows.Forms.ToolStripMenuItem show;


	}
}

