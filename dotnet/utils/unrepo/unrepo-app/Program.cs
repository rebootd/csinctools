/*
 * Created by SharpDevelop.
 * User: jcoffman
 * Date: 9/15/2008
 * Time: 3:11 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 * 
 * Purpose: a utility to remove code repository files from a directory and its children
 */

using System;
using System.Windows.Forms;

namespace unrepoapp
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
		
	}
}
