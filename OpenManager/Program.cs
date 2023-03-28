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
			Application.EnableVisualStyles();						//	Probably doesn't break compatibility
			Application.SetCompatibleTextRenderingDefault(false);	//	
			Application.Run(new Login());	//	Finally runs the program.
		}
	}
}