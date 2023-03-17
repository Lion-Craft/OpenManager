using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
namespace OpenManager
{
	
	public partial class Form2 : Form
	{
		//	Makes Public Variables for appdata path and nuser.
		public string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
		public bool nuser = false;

		//	Does stuffs when program is started.
		public Form2()
		{
			InitializeComponent();
			
			//	Decides if you're creating a new Account or Logging into a existing one (defined in uinf.dat).
			//	This implementation is awful because it just checks if uinf.dat exists and doesn't give a fuck if it actually contains something or not.
			System.Diagnostics.Debug.WriteLine(appdata);
			if (File.Exists(appdata + @"\OpenManager\uinf.dat"))
			{
				nuser = false;
				label1.Text = "Welcome to OpenManager!\n\nPlease enter your Login Credentials.";
				textBox3.Visible = false;
				label2.Text = "Username:\n\nPassword:";
			}
			else
			{
				nuser = true;
				//Form2.ActiveForm.Height += 10;	This would fix the text issue but it causes a System.NullReferenceException.	What the fuck.
				label1.Text = "Welcome to OpenManager!\n\nNo account found! \nIf you already have a account make sure\nuinf.dat is located in " + appdata + @"\OpenManager\" + "\n\nIf you do not have a account yet please create one below:";
				button1.Text = "Create Account";
				label2.Text = "Username:\n\nPassword:\n\nConfirm:";
			}
		}
		//	Shows entered Password when "Show" Button is pressed.
		public bool show = false;
		private void button2_Click(object sender, EventArgs e)
		{
			if (show == true)
			{
				textBox2.UseSystemPasswordChar = true;
				show = false;
			}
			else
			{												//	This seems stupidly complex but works so I couldn't care less.
				textBox2.UseSystemPasswordChar = false;
				show = true;
			}
		}
		//	Does stuff when "Login" Button is pressed
		private void button1_Click(object sender, EventArgs e)
		{
			if ((textBox2.Text != textBox3.Text || textBox2.Text == "" || textBox3.Text == "") && nuser == true)
			{
				label3.Visible = true;
			}
			else if ((textBox2.Text == textBox3.Text || textBox2.Text != "" || textBox3.Text != "") && nuser == true)
			{
				label3.Visible = false;
				Directory.CreateDirectory(appdata + @"\OpenManager\");
				File.WriteAllText(appdata + @"\OpenManager\uinf.dat", GetHashString(textBox3.Text) + "\n" + GetHashString(textBox1.Text));
				MessageBox.Show("Account successfully created.");
				Application.Restart();
			}
			//	Opens Form1 when nuser is false and the User's PWD & Username Hash equals
			//	the stored Hash for the Account and makes Form2 not visible. 
			//	Someone help me PLEASE
			//	P.S. This seems incredebly insecure and stupid.
			if (nuser == false && File.ReadAllText(appdata + @"\OpenManager\uinf.dat") == GetHashString(textBox2.Text) + "\n" + GetHashString(textBox1.Text))
			{
				var mainForm = new Form1();
				mainForm.Show();
				this.Hide();    //	This is completely and utterly fucking retarded and 
								//	causes the program to remain open when closing it with
								//	the Windows close button in Form1 instead of using
								//	File -> Quit...		Too bad!
								//
								//	P.S. Yes, this does cause the memory to fill up if the user opens
								//	and closes the program incorrectly a lot.
								//	And no, I don't know how to fix it yet.
			}
		}
		//	Everything below crates Hashes. I don't quite know how it works but again, I couldn't care less.
		public static byte[] GetHash(string inputString)
		{
			using (HashAlgorithm algorithm = SHA512.Create())
				return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
		}
		public static string GetHashString(string inputString)
		{
			StringBuilder sb = new StringBuilder();
			foreach (byte b in GetHash(inputString))
				sb.Append(b.ToString("X2"));

			return sb.ToString();
		}
	}
}
