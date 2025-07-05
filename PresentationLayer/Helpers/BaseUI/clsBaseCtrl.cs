using PresentationLayer.Helpers.Colors;
using System.Drawing;
using static PresentationLayer.Global.clsGlobalData;
using static BusinessLayer.Core.clsUsersPermissions;
namespace PresentationLayer.Helpers.BaseUI
{
    public partial class clsBaseCtrl : UserControl,IThemeable
    {
        public clsBaseCtrl()
        {
            InitializeComponent();
        }
        internal static Boolean CheckUserAccess(byte Access)
        {
            // == is faster than &
            if (CurrentUser.Permissions == GetPermissions("Admin"))
                return true;
            if ((CurrentUser.Permissions & (byte)Access) == (byte)Access)
                return true;
            ShowAccessDeniedScreen();
            return false;
        }
        internal static void ShowAccessDeniedScreen()
        {
            MessageBox.Show("Access is Denied !\nPlease Contact Your Admin.", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void SetTheme(HashSet<Control> controls)
        {
            foreach (var control in controls)
            {
                if (control is TreeView treeView)
                {
                    treeView.BackColor = CurrentTheme.Values.Background;
                    treeView.ForeColor = CurrentTheme.Values.Text;
                    treeView.LineColor = ControlPaint.Dark(CurrentTheme.Values.Text, 0.4f);
                    treeView.ShowLines = true;
                    treeView.FullRowSelect = true;
                    treeView.HideSelection = false;
                    treeView.BorderStyle = BorderStyle.FixedSingle;

                    treeView.DrawMode = TreeViewDrawMode.OwnerDrawText;

                    treeView.DrawNode += (s, e) =>
                    {
                        var isSelected = (e.State & TreeNodeStates.Selected) == TreeNodeStates.Selected;

                        Color bgColor = isSelected
                            ? ControlPaint.Dark(CurrentTheme.Values.Primary, 0.3f)
                            : treeView.BackColor;

                        Color textColor = isSelected
                            ? CurrentTheme.Values.Background.GetBrightness() < 0.5 ? Color.White : Color.Black
                            : treeView.ForeColor;

                        using (SolidBrush backgroundBrush = new SolidBrush(bgColor))
                            e.Graphics.FillRectangle(backgroundBrush, e.Bounds);

                        TextRenderer.DrawText(e.Graphics, e.Node.Text, treeView.Font, e.Bounds, textColor, TextFormatFlags.GlyphOverhangPadding);
                    };
                }

                if (control is Button btn)
                {
                    if (btn.Tag?.ToString() == "Fetch")
                    {

                        btn.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                        btn.ForeColor = Color.Black;
                    }
                    else
                    {

                        btn.BackColor = CurrentTheme.Values.Primary;
                        btn.ForeColor = Color.White;
                    }

                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.FlatAppearance.MouseOverBackColor = CurrentTheme.Values.Secondary;
                }
                if (control is PictureBox || control is RadioButton || control is Label)
                {
                    if (control.Parent != null)
                        control.BackColor = control.Parent.BackColor;
                    control.ForeColor = CurrentTheme.Values.Text;

                    if (control is Label lbl)
                    {
                        lbl.ForeColor = CurrentTheme.Values.Text;

                        if (lbl.Parent is Panel || lbl.Parent is GroupBox || lbl.Parent is TabPage)
                        {
                            lbl.BackColor = lbl.Parent.BackColor;
                        }
                        else if (lbl.Parent is Form frm)
                        {
                            lbl.BackColor = frm.BackColor;
                        }
                        else
                        {
                            lbl.BackColor = CurrentTheme.Values.Background;
                        }

                        if (lbl.Tag?.ToString() == "MainTitle")
                        {
                            lbl.ForeColor = CurrentTheme.Values.Background.GetBrightness() < 0.5
                                ? Color.White
                                : ColorTranslator.FromHtml("#1A1A1A");

                            lbl.Font = new Font(lbl.Font.FontFamily, lbl.Font.Size + 2, FontStyle.Bold);
                        }
                    }

                }
                else if (control is MenuStrip menu)
                {
                    Color menuBackColor;
                    Color menuTextColor;

                    if (CurrentTheme.Mode == enThemeMode.Admin)
                    {

                        menuBackColor = ColorTranslator.FromHtml("#FFE5EC");
                        menuTextColor = ColorTranslator.FromHtml("#880E4F");

                    }
                    else
                    {
                        menuBackColor = CurrentTheme.Values.Primary;
                        menuTextColor = CurrentTheme.Values.Text;
                    }

                    menu.BackColor = menuBackColor;
                    menu.ForeColor = menuTextColor;

                    foreach (ToolStripMenuItem item in menu.Items)
                    {
                        ApplyMenuItemTheme(item, menuBackColor, menuTextColor);
                    }
                }

                else if (control is TextBox txt)
                {
                    txt.BackColor = Color.White;
                    txt.ForeColor = ColorTranslator.FromHtml("#222222");
                    txt.BorderStyle = BorderStyle.FixedSingle;
                }

                else if (control is ComboBox cmb)
                {
                    cmb.BackColor = CurrentTheme.Values.Secondary;
                    cmb.ForeColor = CurrentTheme.Values.Text;
                    cmb.FlatStyle = FlatStyle.Flat;
                    cmb.DrawMode = DrawMode.OwnerDrawFixed;
                    cmb.DrawItem += (s, e) =>
                    {
                        e.DrawBackground();
                        if (e.Index >= 0)
                        {
                            e.Graphics.DrawString(
                                cmb.Items[e.Index].ToString(),
                                cmb.Font,
                                new SolidBrush(CurrentTheme.Values.Text),
                                e.Bounds
                            );
                        }
                        e.DrawFocusRectangle();
                    };
                }

                else if (control is CheckBox chk)
                {
                    chk.ForeColor = CurrentTheme.Values.Text;
                    chk.BackColor = Color.Transparent;
                }

                else if (control is Panel pnl)
                {
                    pnl.BackColor = CurrentTheme.Values.Background;

                    foreach (Control subControl in pnl.Controls)
                    {
                        subControl.ForeColor = CurrentTheme.Values.Text;
                    }
                }
                else if (control is GroupBox grp)
                {
                    grp.BackColor = CurrentTheme.Values.Background;
                    grp.ForeColor = CurrentTheme.Values.Text;

                    foreach (Control subControl in grp.Controls)
                    {
                        subControl.ForeColor = CurrentTheme.Values.Text;
                    }
                }

                else if (control is TabControl tab)
                {
                    tab.BackColor = CurrentTheme.Values.Background;
                    tab.ForeColor = CurrentTheme.Values.Text;
                }


                else if (control is DataGridView dgv)
                {
                    dgv.EnableHeadersVisualStyles = false;
                    var cms = dgv.ContextMenuStrip;
                    cms.ForeColor = CurrentTheme.Values.Text;
                    if (cms != null)
                    {
                        cms.Renderer = new ToolStripProfessionalRenderer(new clsColorTable());
                        cms.BackColor = CurrentTheme.Values.Background;
                        cms.ForeColor = CurrentTheme.Values.Text;

                        foreach (ToolStripItem item in cms.Items)
                        {
                            item.BackColor = CurrentTheme.Values.Background;
                            item.ForeColor = CurrentTheme.Values.Text;
                        }
                    }

                    if (CurrentTheme.Mode == enThemeMode.Admin)
                    {
                        dgv.BackgroundColor = ColorTranslator.FromHtml("#FFF5FA"); // خلفية فاتحة جدًا
                        dgv.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFF5FA");
                        dgv.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#4B1E1E"); // بني واضح

                        dgv.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#FFB6C1"); // وردي
                        dgv.DefaultCellStyle.SelectionForeColor = Color.Black;

                        dgv.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFDEE9");
                        dgv.ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#4B1E1E");

                        dgv.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFDEE9");
                        dgv.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#4B1E1E");

                        dgv.GridColor = Color.LightGray;
                    }
                    else if (CurrentTheme.Mode == enThemeMode.Dark)
                    {
                        dgv.BackgroundColor = CurrentTheme.Values.Background;

                        dgv.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#3C3F41");
                        dgv.DefaultCellStyle.ForeColor = CurrentTheme.Values.Text;

                        dgv.DefaultCellStyle.SelectionBackColor = CurrentTheme.Values.Primary;
                        dgv.DefaultCellStyle.SelectionForeColor = Color.White;

                        dgv.ColumnHeadersDefaultCellStyle.BackColor = CurrentTheme.Values.Secondary;
                        dgv.ColumnHeadersDefaultCellStyle.ForeColor = CurrentTheme.Values.Text;

                        dgv.RowHeadersDefaultCellStyle.BackColor = CurrentTheme.Values.Secondary;
                        dgv.RowHeadersDefaultCellStyle.ForeColor = CurrentTheme.Values.Text;

                        dgv.GridColor = ColorTranslator.FromHtml("#4A4A4A");
                    }
                    else
                    {
                        dgv.BackgroundColor = Color.White;
                        dgv.DefaultCellStyle.BackColor = Color.White;
                        dgv.DefaultCellStyle.ForeColor = Color.FromArgb(30, 30, 30);

                        dgv.DefaultCellStyle.SelectionBackColor = Color.LightGray;
                        dgv.DefaultCellStyle.SelectionForeColor = Color.Black;

                        dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro;
                        dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

                        dgv.RowHeadersDefaultCellStyle.BackColor = Color.Gainsboro;
                        dgv.RowHeadersDefaultCellStyle.ForeColor = Color.Black;

                        dgv.GridColor = Color.LightGray;
                    }
                }

                else //Any another control
                {
                    control.BackColor = CurrentTheme.Values.Background;
                    control.ForeColor = CurrentTheme.Values.Text;
                }
                //Special Handling
                if (CurrentTheme.Mode == enThemeMode.Default)
                {
                    if (control is ComboBox cBox)
                    {
                        cBox.BackColor = Color.White;
                        cBox.ForeColor = Color.FromArgb(30, 30, 30);
                        cBox.FlatStyle = FlatStyle.Standard;
                    }

                }
                if (CurrentTheme.Mode == enThemeMode.Dark)
                {
                    if (control is Form frm)
                    {
                        frm.BackColor = ColorTranslator.FromHtml("#1E1E2F");
                        frm.ForeColor = ColorTranslator.FromHtml("#F0F0F0");
                    }
                    if (control is LinkLabel link)
                    {
                        link.LinkColor = ColorTranslator.FromHtml("#33B5E5");
                        link.ActiveLinkColor = ColorTranslator.FromHtml("#66D9EF");
                        link.VisitedLinkColor = ColorTranslator.FromHtml("#3399CC");
                    }
                    if (control is Button btnDark)
                    {
                        btnDark.BackColor = CurrentTheme.Values.Primary;
                        btnDark.ForeColor = ColorTranslator.FromHtml("#F1F1F1");
                        btnDark.FlatStyle = FlatStyle.Flat;
                        btnDark.FlatAppearance.BorderSize = 0;
                        btnDark.FlatAppearance.MouseOverBackColor = CurrentTheme.Values.Secondary;

                    }
                }

                if (control.HasChildren)
                {
                    var childControls = new HashSet<Control>();
                    foreach (Control child in control.Controls)
                        childControls.Add(child);

                    SetTheme(childControls);
                }
            }
        }
        public HashSet<Control> GetAllFormControls(Control UserControl)
        {
            HashSet<Control> controls = new HashSet<Control>();
            controls?.Add(UserControl);
            foreach (Control ctrl in UserControl.Controls)
                controls?.Add(ctrl);
            return controls;
        }
        public void SetTheme(Control UserControl)
        {
            HashSet<Control> controls = GetAllFormControls(UserControl);
            SetTheme(controls);
        }
        public void ApplyMenuItemTheme(ToolStripMenuItem item, Color backColor, Color textColor)
        {
            item.BackColor = backColor;
            item.ForeColor = textColor;

            foreach (ToolStripItem subItem in item.DropDownItems)
            {
                if (subItem is ToolStripMenuItem subMenuItem)
                {
                    subMenuItem.BackColor = ColorTranslator.FromHtml("#3A3A3D");
                    subMenuItem.ForeColor = textColor;

                    ApplyMenuItemTheme(subMenuItem, backColor, textColor);
                }
            }
        }
    }
}
