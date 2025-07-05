using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PresentationLayer.Global.clsGlobalData;
using static PresentationLayer.Helpers.Logger.clsRegistry;
namespace PresentationLayer.Helpers.Colors
{
    public struct stTheme
    {
        public Color Primary { get; set; }
        public Color Secondary { get; set; }
        public Color Background { get; set; }
        public Color Text { get; set; }
        public Color Success { get; set; }
        public Color Error { get; set; }
    }
    public class clsThemeManager
    {
        public stTheme Values { get; private set; }
        public enThemeMode Mode { get; set; }
        public clsThemeManager()
        {
            Mode = GetUserThemeFromRegistry(out enThemeMode mode)?mode:enThemeMode.Dark;
            LoadTheme(Mode);
        }
        public void LoadTheme(enThemeMode mode)
        {
            switch (mode)
            {
                case enThemeMode.Dark:
                    Values = new stTheme
                    {
                        Primary = ColorTranslator.FromHtml("#3B5775"),  
                        Secondary = ColorTranslator.FromHtml("#2E2E2E"),
                        Background = ColorTranslator.FromHtml("#2B2B3A"),
                        Text = ColorTranslator.FromHtml("#E0E0E0"),  
                        Success = ColorTranslator.FromHtml("#81C784"),  
                        Error = ColorTranslator.FromHtml("#EF5350"), 

                    };
                    Mode = enThemeMode.Dark;
                    break;

                case enThemeMode.Admin:
                    Values = new stTheme
                    {
                        Primary = ColorTranslator.FromHtml("#FFE3E3"),
                        Secondary = ColorTranslator.FromHtml("#FFF0F5"),
                        Background = ColorTranslator.FromHtml("#FFF8FA"),
                        Text = ColorTranslator.FromHtml("#4B2C2C"),
                        Success = ColorTranslator.FromHtml("#A5D6A7"),
                        Error = ColorTranslator.FromHtml("#F8BBD0")
                    };
                    Mode = enThemeMode.Admin;
                    break;

                case enThemeMode.Default:
                default:
                    Values = new stTheme
                    {
                        Primary = ColorTranslator.FromHtml("#F5F5F5"),
                        Secondary = ColorTranslator.FromHtml("#E0E0E0"),
                        Background = Color.White,
                        Text = Color.FromArgb(30, 30, 30),
                        Success = ColorTranslator.FromHtml("#4CAF50"),
                        Error = ColorTranslator.FromHtml("#F44336")
                    };
                    Mode = enThemeMode.Default;
                    break;
            }
        }

    }
}
