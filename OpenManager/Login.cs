using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using System.Diagnostics;
namespace OpenManager
{
	
	public partial class Login : Form
	{
		//	Makes Public Variables for appdata path and nuser.
		public string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
		public bool nuser = false;

		//	Does stuffs when program is started.
		public Login()
		{
			InitializeComponent();
			
			//	Decides if you're creating a new Account or Logging into a existing one (defined in uinf.dat).
			//	This implementation is awful because it just checks if uinf.dat exists and doesn't give a fuck if it actually contains something or not.
			if (File.Exists(appdata + @"\OpenManager\uinf1.dat") && File.Exists(appdata + @"\OpenManager\uinf2.dat"))
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
				//	Hide 2nd Password Textbox.
				label3.Visible = false;
				//	Create OpenManager Directory in appdata\roaming folder if it doesn't exist already.
				Directory.CreateDirectory(appdata + @"\OpenManager\");

				//	Create Aes stuff, Encrypt Password and Username and Write those in a file.
				using (Aes aes = Aes.Create())
				{
					//byte pass;
					//byte uName;
					//	Set Constant IV & Key for Encryption... Yes, this is stupid, especially since this is Open Source, but it's better than nothing.
					byte[] IV = { 0x17, 0x1b, 0x16, 0x09, 0x42, 0x15, 0x69, 0x35, 0x69, 0x42, 0x20, 0x16, 0x90, 0x78, 0x24, 0x19 };
					aes.IV = IV;

					byte[] Key = { 0x3A, 0x78, 0x52, 0x7a, 0x29, 0xb3, 0x3d, 0x62, 0x64, 0x57, 0xab, 0x37, 0x00, 0x74, 0xb5, 0x5a };
					aes.Key = Key;

					byte[] encryptedPassword = EncryptStringToBytes_Aes(GetHashString(textBox3.Text), aes.Key, aes.IV);
					byte[] encryptedUsername = EncryptStringToBytes_Aes(GetHashString(textBox1.Text), aes.Key, aes.IV);

					/*
					foreach (byte cryptPass in encryptedPassword)
					{
						pass += cryptPass;
						Debug.WriteLine(pass);
					}
					foreach (byte cryptUser in encryptedUsername)
					{
						uName += cryptUser;
						Debug.WriteLine(uName);
					}
					*/
					//	Write Password and Username into uinf.dat.
					File.WriteAllBytes(appdata + @"\OpenManager\uinf1.dat", encryptedPassword);
					File.WriteAllBytes(appdata + @"\OpenManager\uinf2.dat", encryptedUsername);
				}

				//	Show MessageBox to user.
				MessageBox.Show("Account successfully created.");
				//	Restart program so the user can log in.
				Application.Restart();
			}
			//	Opens Form1 when nuser is false and the User's PWD & Username Hash equals
			//	the stored Hash for the Account and makes Form2 not visible. 
			//	Someone help me PLEASE
			//	P.S. This seems incredebly insecure and stupid.

			//	Decrypts Password
			using (Aes aes = Aes.Create())
			{
				//	Set Constant IV & Key for Encryption... Yes, this is stupid, especially since this is Open Source, but it's better than nothing.
				byte[] IV = { 0x17, 0x1b, 0x16, 0x09, 0x42, 0x15, 0x69, 0x35, 0x69, 0x42, 0x20, 0x16, 0x90, 0x78, 0x24, 0x19 };
				aes.IV = IV;

				byte[] Key = { 0x3A, 0x78, 0x52, 0x7a, 0x29, 0xb3, 0x3d, 0x62, 0x64, 0x57, 0xab, 0x37, 0x00, 0x74, 0xb5, 0x5a };
				aes.Key = Key;

				string decrypted = DecryptStringFromBytes_Aes(File.ReadAllBytes(appdata + @"\OpenManager\uinf1.dat"), aes.Key, aes.IV) + "\n" + DecryptStringFromBytes_Aes(File.ReadAllBytes(appdata + @"\OpenManager\uinf2.dat"), aes.Key, aes.IV);

				if (nuser == false && decrypted == GetHashString(textBox2.Text) + "\n" + GetHashString(textBox1.Text))
				{
					var mainForm = new MainWindow();
					mainForm.Show();
					this.Hide();    //	This is completely and utterly fucking retarded.
									//	Update: Fixed the original issue now but is still a awful way to do this.
				}
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

		//	Encrypt a String
		static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
		{
			// Check arguments.
			if (plainText == null || plainText.Length <= 0)
				throw new ArgumentNullException("plainText");
			if (Key == null || Key.Length <= 0)
				throw new ArgumentNullException("Key");
			if (IV == null || IV.Length <= 0)
				throw new ArgumentNullException("IV");
			byte[] encrypted;

			// Create an Aes object
			// with the specified key and IV.
			using (Aes aesAlg = Aes.Create())
			{
				aesAlg.Key = Key;
				aesAlg.IV = IV;

				// Create an encryptor to perform the stream transform.
				ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

				// Create the streams used for encryption.
				using (MemoryStream msEncrypt = new MemoryStream())
				{
					using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
					{
						using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
						{
							//Write all data to the stream.
							swEncrypt.Write(plainText);
						}
						encrypted = msEncrypt.ToArray();
					}
				}
			}

			// Return the encrypted bytes from the memory stream.
			return encrypted;
		}

		//	Decrypt a String
		static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
		{
			// Check arguments.
			if (cipherText == null || cipherText.Length <= 0)
				throw new ArgumentNullException("cipherText");
			if (Key == null || Key.Length <= 0)
				throw new ArgumentNullException("Key");
			if (IV == null || IV.Length <= 0)
				throw new ArgumentNullException("IV");

			// Declare the string used to hold
			// the decrypted text.
			string plaintext = null;

			// Create an Aes object
			// with the specified key and IV.
			using (Aes aesAlg = Aes.Create())
			{
				aesAlg.Key = Key;
				aesAlg.IV = IV;

				// Create a decryptor to perform the stream transform.
				ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

				// Create the streams used for decryption.
				using (MemoryStream msDecrypt = new MemoryStream(cipherText))
				{
					using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
					{
						using (StreamReader srDecrypt = new StreamReader(csDecrypt))
						{

							// Read the decrypted bytes from the decrypting stream
							// and place them in a string.
							plaintext = srDecrypt.ReadToEnd();
						}
					}
				}
			}

			return plaintext;
		}
	}
}