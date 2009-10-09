/*
 * Created by SharpDevelop.
 * User: josh
 * Date: 9/15/2008
 * Time: 11:38 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Management;

namespace unrepoapp
{
	/// <summary>
	/// Description of Cleaner.
	/// </summary>
	public class Cleaner
	{
		public Cleaner()
		{
		}
		
		public bool CleanDirectory(DirectoryInfo dirInfo, string[] folderNames)
		{
            //get list of directories
            DirectoryInfo[] dirs = dirInfo.GetDirectories();

            //loop each
            foreach (DirectoryInfo dir in dirs)
            {
                bool istarget = false;
                foreach (string fname in folderNames)
                {
                    istarget = (dir.Name == fname);
                    if (istarget) break;
                }

                if (istarget)
                {
                    //dir.Attributes = FileAttributes.Normal;
                    //Directory.Delete(dir.FullName, true);
                    using (ManagementObject mo = new ManagementObject(String.Format("win32_Directory.Name='{0}'", dir.FullName)))
                    {
                        mo.Get();
                        ManagementBaseObject outParams = mo.InvokeMethod("Delete", null, null);
                        if (Convert.ToInt32(outParams.Properties["ReturnValue"].Value) != 0) return false;
                    }
                }
                else if (!CleanDirectory(dir, folderNames))
                    return false;
            }

            return true;
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
            foreach (DirectoryInfo dir in dirs)
            {
                if (dir.Name == ".cvs" || dir.Name == ".svn")
                    Directory.Delete(dir.FullName, true);
                else
                    CleanDir(dir);
            }
        }

	}
}
