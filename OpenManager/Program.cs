using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace OpenManager
{
	static class Program
	{
		[STAThread]
		static void Main()
		{
			Properties.Settings.Default.LoggedIn = false;	//
			Properties.Settings.Default.Save();				//	I have no idea why these two lines for settings exist, but they do.
			Application.EnableVisualStyles();						//	Probably doesn't break compatibility
			Application.SetCompatibleTextRenderingDefault(false);	//	
			Application.Run(new Form2());	//	Finally runs the program.
		}
	}
}
