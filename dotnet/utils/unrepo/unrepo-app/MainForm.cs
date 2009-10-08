/*
 * Created by SharpDevelop.
 * User: jcoffman
 * Date: 9/15/2008
 * Time: 3:11 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace unrepoapp
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
        private string[] folderNames;

		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
            folderNames = new string[] { ".svn", "CVS" };
		}

        private void btnSelect_Click(object sender, EventArgs e)
        {
            //get the folder path
            DialogResult dlgresult = this.folderBrowserDialog1.ShowDialog();

            if (dlgresult == DialogResult.OK || dlgresult == DialogResult.Yes)
                txtPath.Text = folderBrowserDialog1.SelectedPath;
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            string path = txtPath.Text.Trim();

            //check if txtPath has a path
            if (path.Length == 0)
            {
                MessageBox.Show("Please select a path");
                return;
            }

            //check if path exists
            if (!Directory.Exists(path))
            {
                MessageBox.Show("Please select a valid folder");
                return;
            }

            //confirm that deleting the source control files
            DialogResult confirmResult = MessageBox.Show(this, "Are you sure you wish to remove source control for this folder and its subfolders?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2 );

            if (confirmResult == DialogResult.Yes)
            {
                //remove source control files...
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                
                //recursively delete
                DirectoryInfo dirinfo = new DirectoryInfo(path);
                Cleaner cleaner = new Cleaner();
                cleaner.CleanDirectory(dirinfo, folderNames);                
                this.Cursor = System.Windows.Forms.Cursors.Default;

                //inform the user
                txtPath.Text = String.Empty;
                MessageBox.Show("Done");
            }
        }
        
        /// <summary>
        /// recursively clean up directories
        /// </summary>
        /// <param name="dirInfo"></param>
        private void CleanDir(DirectoryInfo dirInfo)
        {
        	//get list of directories
        	DirectoryInfo[] dirs = dirInfo.GetDirectories();
        	
        	//loop each
        	foreach( DirectoryInfo dir in dirs )
        	{
        		if(dir.Name==".cvs" || dir.Name ==".svn")
        			Directory.Delete(dir.FullName, true);
        		else
        			CleanDir(dir);
        	}
        }
	}
}
