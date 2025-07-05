using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Helpers.Logger
{
    internal class clsFileLogger
    {


        internal static bool RememberCredentialsTotxtFile(string UserName, string Password)
        {
            string FilePath = @"F:\Programming\C#\Course19 (Full Project)\Credentials.txt";
            if (!File.Exists(FilePath))
            {
                return false;
            }
            using (StreamWriter sw = new StreamWriter(FilePath))
            {
                sw.WriteLine(UserName);
                sw.WriteLine(Password);
                sw.Close();
            }
            return true;
        }
        public static void GetStoredCredentialsFromFile(ref string UserName, ref string Password)
        {
            string FilePath = @"F:\Programming\C#\Course19 (Full Project)\Credentials.txt";
            if (!File.Exists(FilePath))
            {
                Directory.CreateDirectory(FilePath);
            }
            using (StreamReader sr = new StreamReader(FilePath))
            {
                UserName = sr.ReadLine();
                Password = sr.ReadLine();
                sr.Close();
            }
        }

    }
}
