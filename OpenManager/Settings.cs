using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;

namespace OpenManager
{
	public partial class Settings : Form
	{
		public static string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
		public string theme = File.ReadAllText(appdata + @"\OpenManager\uset.dat");
		public Settings()
		{
			InitializeComponent();

			//	Load Theme info
			theme = File.ReadAllText(appdata + @"\OpenManager\uset.dat");   //	Color loading is fixed now thanks to this
			Debug.WriteLine(theme);
			if (theme == "0")
			{
				//	Set Classic Theme.
				radioButton1.Checked = true;
				this.BackColor = Color.FromName("Control");
				button1.BackColor = Color.FromName("Control");
				this.ForeColor = Color.FromName("ControlText");
				Debug.WriteLine("theme 0");
			} else if (theme == "1")
			{
				//	Set Light theme.
				radioButton2.Checked = true;
				this.BackColor = Color.White;
				button1.BackColor = Color.White;
				this.ForeColor = Color.Black;
				Debug.WriteLine("theme 1");
			} else if (theme == "2")
			{
				//	Set Dark theme.
				radioButton3.Checked = true;
				this.BackColor = Color.DimGray;
				button1.BackColor = Color.DimGray;
				this.ForeColor = Color.White;
				Debug.WriteLine("theme 2");
			}
		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			//	Classic mode button
			this.BackColor = Color.FromName("Control");
			button1.BackColor = Color.FromName("Control");
			this.ForeColor = Color.FromName("ControlText");
			theme = "0";
		}

		private void radioButton2_CheckedChanged(object sender, EventArgs e)
		{
			//	Light mode button
			this.BackColor = Color.White;
			button1.BackColor = Color.White;
			this.ForeColor = Color.Black;
			theme = "1";
		}

		private void radioButton3_CheckedChanged(object sender, EventArgs e)
		{
			//	Dark mode button
			this.BackColor = Color.DimGray;
			button1.BackColor = Color.DimGray;
			this.ForeColor = Color.White;
			theme = "2";
		}

		private void button1_Click(object sender, EventArgs e)
		{
			//	Save Button
			File.WriteAllText(appdata + @"\OpenManager\uset.dat", theme);
		}
	}
}
