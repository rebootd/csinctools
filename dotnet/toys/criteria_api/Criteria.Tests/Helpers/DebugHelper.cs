using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Criteria.Tests.Helpers
{
    public class DebugHelper
    {
        public static void WriteToConsole(string output)
        {
            System.Diagnostics.Debug.WriteLine(output);
        }

        public static void WriteToFile(string filePath, string output)
        {
            StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8);

            writer.WriteLine(output);
            writer.Flush();

            writer.Close();
        }
    }
}
