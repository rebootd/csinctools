/*
 * Created by SharpDevelop.
 * User: josh
 * Date: 9/15/2008
 * Time: 11:32 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using MbUnit.Framework;
using unrepoapp;

namespace unrepo_tests
{
	/// <summary>
	/// Description of DirectoryTest.
	/// </summary>
	[TestFixture]
	public class DirectoryTest
	{
        private string testPath;
        private DirectoryInfo dirInfo;
        private string[] folderNames;
		private Cleaner cleaner;
		
		public DirectoryTest()
		{
            testPath = @"C:\Dev\Dependencies";
            folderNames = new string[] {".svn", "CVS"};
            dirInfo = new DirectoryInfo(testPath);
            cleaner = new Cleaner();
		}
		
		[Test]
		public void clean_test_directory()
		{
            //call code
            bool success = cleaner.CleanDirectory(dirInfo, folderNames);

			Assert.IsTrue(success);
		}
	}
}
