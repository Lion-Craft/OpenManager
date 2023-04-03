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
				this.BackColor = Color.FromName("Window");
				button1.BackColor = Color.FromName("Window");
				this.ForeColor = Color.FromName("ControlText");
				Debug.WriteLine("theme 1");
			} else if (theme == "2")
			{
				//	Set Dark theme.
				radioButton3.Checked = true;
				this.BackColor = Color.FromName("ControlDarkDark");
				button1.BackColor = Color.FromName("ControlDarkDark");
				this.ForeColor = Color.FromName("HighlightText");
				Debug.WriteLine("theme 2");
				//	Why the fuck does it not set the correct color? WHYYYYYYYY
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
			this.BackColor = Color.FromName("Window");
			button1.BackColor = Color.FromName("Window");
			this.ForeColor = Color.FromName("ControlText");
			theme = "1";
		}

		private void radioButton3_CheckedChanged(object sender, EventArgs e)
		{
			//	Dark mode button
			this.BackColor = Color.FromName("ControlDarkDark");
			button1.BackColor = Color.FromName("ControlDarkDark");
			this.ForeColor = Color.FromName("HighlightText");
			theme = "2";
		}

		private void button1_Click(object sender, EventArgs e)
		{
			//	Save Button
			File.WriteAllText(appdata + @"\OpenManager\uset.dat", theme);
		}
	}
}
