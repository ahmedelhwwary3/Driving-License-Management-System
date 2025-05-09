using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Global
{
    public class clsUtil
    {
        public static string ComputeHash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                try
                {
                    byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                    return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
                }
                catch (Exception ex)
                {
                    clsGlobal.LogError(ex);
                    return string.Empty;
                }
            }
        }
        public static string GenerateGuid()
        {
            try
            {
                Guid newGuid = Guid.NewGuid();
                return newGuid.ToString();
            }
            catch (Exception ex)
            {
                clsGlobal.LogError(ex);
                return string.Empty;
            }
        }

        public static bool CreateFoulderIfNotExisted(string FoulderPath)
        {
            if (!Directory.Exists(FoulderPath))
            {
                try
                {
                    Directory.CreateDirectory(FoulderPath);
                    return true;
                }
                catch(Exception ex)
                {
                    clsGlobal.LogError(ex);
                    return false;
                }
            }
            else
                return true;
        }

        public static string ReplaceFileNameWithGuidWithExt(string FileName)
        {
            try
            {
                //To seperate (Name , Ext) to replace Name with Guid then add Ext
                FileInfo fi = new FileInfo(FileName);
                string ext = fi.Extension;
                FileName = GenerateGuid() + ext;
                return FileName;
            }
            catch (Exception ex)
            {
                clsGlobal.LogError(ex);
                return "";
            }
        }
        public static bool CopyImageToImagesFile(ref string SourceFilePath)
        {
            string DestinationFile = @"F:\Images\";
            if (!CreateFoulderIfNotExisted(DestinationFile))
                return false;
            //SourceFilePath must be updated after checking Copy Success first
            string ImagePath = DestinationFile + ReplaceFileNameWithGuidWithExt(SourceFilePath);

            try
            {
                File.Copy(SourceFilePath, ImagePath);
            }
            catch
            {
                return false;
            }
            SourceFilePath = ImagePath;
            return true;

        }







    }
}
