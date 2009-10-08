/*
 * Created by SharpDevelop.
 * User: josh
 * Date: 9/15/2008
 * Time: 11:41 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;

namespace unrepo_app
{
	/// <summary>
	/// Description of ICleaner.
	/// </summary>
	public interface ICleaner
	{
		void CleanDir(DirectoryInfo dirInfo, string[] folderNames);
	}
}
