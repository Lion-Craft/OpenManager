using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using System.Diagnostics;

namespace OpenManager
{
	public partial class Form1 : Form
	{
		public Form1()
			// fun fact: i'm getting paid in kisses and cuddles :#
		{
			InitializeComponent();
			string original = "Here is some data to encrypt!";

			// Create a new instance of the Aes
			// class.  This generates a new key and initialization
			// vector (IV).
			using (Aes myAes = Aes.Create())
			{

				// Encrypt the string to an array of bytes.
				byte[] encrypted = EncryptStringToBytes_Aes(original, myAes.Key, myAes.IV);

				// Decrypt the bytes to a string.
				string roundtrip = DecryptStringFromBytes_Aes(encrypted, myAes.Key, myAes.IV);

				//Display the original data and the decrypted data.
				Debug.WriteLine("Original:   {0}", original);
				Debug.WriteLine("Round Trip: {0}", roundtrip);
			}
		}
		public void Form_FormClosing(object sender, FormClosedEventArgs e)
		{
			if (true)
			{
				Application.Exit();
			}
		}
		public static byte[] GetHash(string inputString)
		{
			using (HashAlgorithm algorithm = SHA256.Create())
				return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
		}
		public static string GetHashString(string inputString)
		{
			StringBuilder sb = new StringBuilder();
			foreach (byte b in GetHash(inputString))
				sb.Append(b.ToString("X2"));

			return sb.ToString();
		}
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

		private void menuItem3_Click(object sender, EventArgs e)
		{
			// "Save" button in Menu Bar under "File".

			//	TODO: Implement Save, Load and in general the main part of the program
		}

		private void menuItem4_Click(object sender, EventArgs e)
		{
			//	"Quit" button in Menu Bar under "File".
			MessageBox.Show("Exiting...");	//	Why is this MessageBox still here?
			Application.Exit();
		}

		private void menuItem5_Click(object sender, EventArgs e)
		{
			//	"About" button in Menu Bar under "File".
			var aboutform = new Form3();
			aboutform.Show();
		}
		//	Supposed to show PWD in row the button is in	
		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			MessageBox.Show("pressed something" + e.RowIndex);
			
		}

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you really want to exit?", "Dialog Title", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
    
}
