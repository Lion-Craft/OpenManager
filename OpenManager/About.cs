using System;
using System.Windows.Forms;

namespace OpenManager
{
	public partial class About : Form
	{
		public About()
		{
			//	Sets text with version number & Copyright when About page is opened.
			InitializeComponent();
			label1.Text = "OpenManager v" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version + "\n\nCopyright \u00A9 2023 Lion Craft and AcisSys";
		}
	}
}