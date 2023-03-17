using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenManager
{
	public partial class Form3 : Form
	{
		public Form3()
		{
			InitializeComponent();
			label1.Text = "OpenManager v" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version + "\n\nCopyright \u00A9 2023 Leon Frommholz";
		}
	}
}
