using PresentationLayer.Login;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Json;
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
                       clsGlobalData.WindownsEventLog.Log(ex);
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
                   clsGlobalData.WindownsEventLog.Log(ex);
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
                       clsGlobalData.WindownsEventLog.Log(ex);
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
                   clsGlobalData.WindownsEventLog.Log(ex);
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




        internal static MemoryStream SerializeObjectJSONformat<T>(T obj)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            MemoryStream stream = new MemoryStream();
            serializer.WriteObject(stream, obj);
            return stream;
        }
        internal static T DeserializeObjectJSONformat<T>(MemoryStream stream)
        {
            //Pointer after writing became on the end of data
            //We here move it back to the begin of data to read it in deserializtion
            if (stream != null)
                stream.Position = 0;
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            T deserializedObject = (T)serializer.ReadObject(stream);
            return deserializedObject;
        }


        [Conditional("DEBUG")]
        internal static void ShowDocumentationScreen()
        {
            frmDocumentation frm = new frmDocumentation();
            //No permissions needed
            frm.ShowDialog();
        }
        internal static HashSet<string> GetClassDescriptionAttributeData(Type type)
        {
            HashSet<string> lst = new HashSet<string>();
            object[] classAttributes = type.GetCustomAttributes(typeof(DescriptionAttribute), false);

            foreach (DescriptionAttribute attribute in classAttributes)
            {
                if (attribute != null)
                    lst?.Add("Class Name:" + type.Name + "  " + "Description:" + attribute.Description);
            }
            return lst;
        }
        internal static HashSet<string> GetClassMethodsParameters(Type type)
        {
            HashSet<string> lst = new HashSet<string>();
            string MethodLine = "";
            var methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            foreach (var method in methods)
            {
                MethodLine = method.Name + ": ";
                var parameters = method.GetParameters();
                foreach (var param in parameters)
                    MethodLine += param.Name + " ,";
                lst?.Add(MethodLine.Substring(0, MethodLine.Length - 2));
            }
            return lst ?? new HashSet<string>();
        }
        internal static HashSet<string> GetClassProberties(Type type)
        {
            HashSet<string> lst = new HashSet<string>();
            var properties = type.GetProperties();
            string ProbertyLine = "";
            foreach (var prop in properties)
                lst?.Add(prop.Name);
            return lst ?? new HashSet<string>();
        }
        internal static List<Type> ListAllCustomClasses()
        {
            Assembly bizLayerAssembly = typeof(BusinessLayer.Core.clsPerson).Assembly;

            List<Type> classes = bizLayerAssembly.GetTypes()
                .Where(t => t.IsClass &&
                            t.Namespace != null &&
                            t.Namespace.StartsWith("BusinessLayer"))
                .ToList();
            return classes;
        }
      
    }
}
