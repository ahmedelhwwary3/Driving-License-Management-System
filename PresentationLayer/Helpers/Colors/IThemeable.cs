using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PresentationLayer.Global.clsGlobalData;

namespace PresentationLayer.Helpers.Colors
{
    public interface IThemeable
    {
        void SetTheme(HashSet<Control> controls);
        HashSet<Control> GetAllFormControls(Control control);
        void ApplyMenuItemTheme(ToolStripMenuItem item, Color backColor, Color textColor);
        void SetTheme(Control control);
    }
}
