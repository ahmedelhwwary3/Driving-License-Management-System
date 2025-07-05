using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PresentationLayer.Global.clsGlobalData;

namespace PresentationLayer.Helpers.Colors
{
    internal class clsColorTable:ProfessionalColorTable
    {
        public override Color ImageMarginGradientBegin => CurrentTheme.Values.Background;
        public override Color ImageMarginGradientMiddle => CurrentTheme.Values.Background;
        public override Color ImageMarginGradientEnd => CurrentTheme.Values.Background;

        public override Color ToolStripDropDownBackground => CurrentTheme.Values.Background;
        public override Color MenuItemSelected => CurrentTheme.Values.Primary;
        public override Color MenuItemBorder => CurrentTheme.Values.Primary;
    }
}
