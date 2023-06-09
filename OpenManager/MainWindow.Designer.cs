﻿
namespace OpenManager
{
	partial class MainWindow
	{
		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Verwendete Ressourcen bereinigen.
		/// </summary>
		/// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Vom Windows Form-Designer generierter Code

		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung.
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
			this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.Show = new System.Windows.Forms.DataGridViewButtonColumn();
			this.Account = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Password = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataSet1 = new System.Data.DataSet();
			this.dataTable1 = new System.Data.DataTable();
			this.dataColumn1 = new System.Data.DataColumn();
			this.dataColumn2 = new System.Data.DataColumn();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem2,
            this.menuItem3,
            this.menuItem7,
            this.menuItem5,
            this.menuItem4});
			this.menuItem1.Text = "File";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 0;
			this.menuItem2.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
			this.menuItem2.Text = "Open";
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 1;
			this.menuItem3.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
			this.menuItem3.Text = "Save";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// menuItem7
			// 
			this.menuItem7.Index = 2;
			this.menuItem7.Text = "Settings";
			this.menuItem7.Click += new System.EventHandler(this.menuItem8_Click);
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 3;
			this.menuItem5.Shortcut = System.Windows.Forms.Shortcut.F1;
			this.menuItem5.Text = "About";
			this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 4;
			this.menuItem4.Shortcut = System.Windows.Forms.Shortcut.AltF4;
			this.menuItem4.Text = "Quit";
			this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToOrderColumns = true;
			this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLight;
			this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Show,
            this.Account,
            this.Password});
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
			this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView1.Location = new System.Drawing.Point(0, 0);
			this.dataGridView1.MultiSelect = false;
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(800, 408);
			this.dataGridView1.TabIndex = 2;
			this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
			// 
			// Show
			// 
			this.Show.HeaderText = "Show";
			this.Show.Name = "Show";
			this.Show.ReadOnly = true;
			this.Show.Text = "Show";
			this.Show.UseColumnTextForButtonValue = true;
			this.Show.Width = 42;
			// 
			// Account
			// 
			this.Account.DataPropertyName = "account";
			this.Account.HeaderText = "Account";
			this.Account.Name = "Account";
			this.Account.ToolTipText = "Enter or read a Account name or similar here";
			this.Account.Width = 74;
			// 
			// Password
			// 
			this.Password.DataPropertyName = "password";
			this.Password.HeaderText = "Password";
			this.Password.Name = "Password";
			this.Password.ToolTipText = "Enter or Read a Password here";
			this.Password.Width = 81;
			// 
			// dataSet1
			// 
			this.dataSet1.CaseSensitive = true;
			this.dataSet1.DataSetName = "MainTable";
			this.dataSet1.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1});
			// 
			// dataTable1
			// 
			this.dataTable1.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2});
			this.dataTable1.TableName = "Primary";
			// 
			// dataColumn1
			// 
			this.dataColumn1.Caption = "Account";
			this.dataColumn1.ColumnName = "account";
			this.dataColumn1.DefaultValue = " ";
			// 
			// dataColumn2
			// 
			this.dataColumn2.Caption = "Password";
			this.dataColumn2.ColumnName = "password";
			this.dataColumn2.DefaultValue = " ";
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
			this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(800, 25);
			this.toolStrip1.TabIndex = 3;
			this.toolStrip1.Text = "toolStrip1";
			this.toolStrip1.Visible = false;
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton1.Image = global::OpenManager.Properties.Resources.Saveico1;
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton1.Text = "Save";
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.DefaultExt = "pwf";
			this.saveFileDialog1.Filter = "OpenManager Password File|*.pwf|All Files|*.*";
			this.saveFileDialog1.RestoreDirectory = true;
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 408);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.dataGridView1);
			this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Menu = this.mainMenu1;
			this.Name = "MainWindow";
			this.Text = "OpenManager";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton toolStripButton1;
		private System.Data.DataSet dataSet1;
		private System.Data.DataTable dataTable1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Data.DataColumn dataColumn1;
		private System.Data.DataColumn dataColumn2;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.DataGridViewButtonColumn Show;
		private System.Windows.Forms.DataGridViewTextBoxColumn Account;
		private System.Windows.Forms.DataGridViewTextBoxColumn Password;
	}
}

