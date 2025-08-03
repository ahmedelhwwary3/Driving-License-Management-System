using PresentationLayer.AddLogin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Outlook= Microsoft.Office.Interop.Outlook;
using static PresentationLayer.Global.clsGlobalData;
using Word=Microsoft.Office.Interop.Word;
using static PresentationLayer.Global.clsFormat;
using Excel = Microsoft.Office.Interop.Excel;
using BusinessLayer.Core;
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
                       logExceptions?.AddLog(ex);
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
                   logExceptions?.AddLog(ex);
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
                       logExceptions?.AddLog(ex);
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
                   logExceptions?.AddLog(ex);
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
            object[] classAttributes = type.GetCustomAttributes(typeof(clsDescriptionAttribute), false);

            foreach (clsDescriptionAttribute attribute in classAttributes)
            {
                if (attribute != null)
                    lst?.Add("Class Name:" + type.Name + "  " + "Description:" + attribute.Text);
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
        internal static bool SendEmailViaOutlook(string Subject,string To,string Body)
        {
            try
            {
                Outlook.Application outlookApp = new Outlook.Application();
                if(outlookApp==null)
                {
                    MessageBox.Show("Out Look is not installed on your device !","Error"
                        ,MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return false;
                }
                Outlook.MailItem mailItem = (Outlook.MailItem)outlookApp.CreateItem(Outlook.OlItemType.olMailItem);
                mailItem.Subject = Subject;
                mailItem.To = To;  
                mailItem.Body = Body;
                mailItem.Importance = Outlook.OlImportance.olImportanceNormal;
                mailItem.Display(false);
                mailItem.Send();
 
            }
            catch (Exception ex)
            {
                logExceptions?.AddLog(ex);
                return false;
            }
            return true;
        }
        internal static void SaveDataAsExcelSheet(List<clsOperationLog>lst,string filepath = @"F:ExcelSheet.xlsx")
        {
            Excel.Application excelApp = new Excel.Application();
            try
            {
                if (excelApp == null)
                    return;
                excelApp.Visible = false;  // Set to false to run Excel in the background

                // Create a new, empty workbook and add a worksheet
                Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets[1];
                worksheet.Name = $"Report";
                // Populate the worksheet with numbers 1 to 10
                for (int i = 0; i <= lst?.Count-1; i++)
                {
                    worksheet.Cells[i + 1, 1] = lst[i].LogID;
                    worksheet.Cells[i + 1, 2] = lst[i].Action;
                    worksheet.Cells[i + 1, 3] = lst[i].TableName;
                    worksheet.Cells[i + 1, 4] = lst[i].LoggedUserID;
                    worksheet.Cells[i + 1, 5] = lst[i].CreateDate;
                    worksheet.Cells[i + 1, 6] = lst[i].OldValues;
                    worksheet.Cells[i + 1, 7] = lst[i].NewValues;
                }
                workbook.SaveAs(filepath);
                workbook.Close(true);

            }
            catch (Exception ex)
            {
                logExceptions?.AddLog(ex);
            }
            finally
            {
                excelApp.Quit();  // Close Excel application
            }

        }
        internal static void SaveDataAsExcelSheet(clsOperationLog AddLog, string filepath = @"F:ExcelSheet.xlsx")
        {
            Excel.Application excelApp = new Excel.Application();
            try
            {
                if (excelApp == null)
                    return;
                excelApp.Visible = false;  // Set to false to run Excel in the background

                // Create a new, empty workbook and add a worksheet
                Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets[1];
                worksheet.Name = $"Report";
                worksheet.Cells[1 + 1, 1] = AddLog.LogID;
                worksheet.Cells[1 + 1, 2] = AddLog.Action;
                worksheet.Cells[1 + 1, 3] = AddLog.TableName;
                worksheet.Cells[1 + 1, 4] = AddLog.LoggedUserID;
                worksheet.Cells[1 + 1, 5] = AddLog.CreateDate;
                worksheet.Cells[1 + 1, 6] = AddLog.OldValues;
                worksheet.Cells[1 + 1, 7] = AddLog.NewValues;
                workbook.SaveAs(filepath);
                workbook.Close(true);

            }
            catch (Exception ex)
            {
                logExceptions?.AddLog(ex);
            }
            finally
            {
                excelApp.Quit();  // Close Excel application
            }

        }
        internal static void SaveDataAsWordFile(string data,string filepath= @"F:\Test.docx")
        {
            Word.Application wordApp = new Word.Application();
            try
            {
                wordApp.Visible = false;  // Set to true if you want to see Word while the document is being created
                Word.Document doc = wordApp.Documents.Add();  // Create a new document
                Word.Paragraph para = doc.Paragraphs.Add();   // Add a paragraph
                para.Range.Text = $"Report - {DateToShortString(DateTime.Now)}"+data;  // Your name goes here
                doc.SaveAs2(filepath);
                doc.Close();
            }
            catch (Exception ex)
            {
                logExceptions?.AddLog(ex);
            }
            finally
            {
                wordApp.Quit();  // Close Word application
            }
        }
    }
}
