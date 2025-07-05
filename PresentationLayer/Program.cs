using PresentationLayer.Login;
using PresentationLayer.Users;
using static PresentationLayer.Global.clsGlobalData;
namespace PresentationLayer
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
         
             

            ApplicationConfiguration.Initialize();
            Application.Run(new frmLogin());
        }
    }
}