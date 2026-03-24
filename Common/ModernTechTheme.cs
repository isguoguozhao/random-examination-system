using System;
using System.Drawing;
using System.Windows.Forms;

namespace 单位抽考win7软件.Common
{
    public static class ModernTechTheme
    {
        public static Color BackgroundDeep = Color.FromArgb(15, 23, 42);
        public static Color BackgroundCard = Color.FromArgb(30, 41, 59);
        public static Color TextPrimary = Color.FromArgb(203, 213, 225);
        public static Color TextSecondary = Color.FromArgb(148, 163, 184);
        public static Color TextMuted = Color.FromArgb(100, 116, 139);
        public static Color CyanEnd = Color.FromArgb(14, 165, 233);
        public static Color CyanBright = Color.FromArgb(30, 144, 255);

        public static Font BodyFont = new Font("微软雅黑", 12F, FontStyle.Regular);
        public static Font ButtonFont = new Font("微软雅黑", 12F, FontStyle.Regular);
        public static Font TitleFont = new Font("微软雅黑", 24F, FontStyle.Bold);

        public static void ApplyTheme(Form form)
        {
            form.BackColor = BackgroundDeep;
            form.ForeColor = TextPrimary;
            form.Font = BodyFont;
            ApplyToControls(form.Controls);
        }

        private static void ApplyToControls(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is Button btn)
                {
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Font = ButtonFont;
                    btn.ForeColor = Color.White;
                    btn.BackColor = CyanEnd;
                    btn.Cursor = Cursors.Hand;
                }
                else if (control is TextBox txt)
                {
                    txt.Font = BodyFont;
                    txt.BackColor = BackgroundCard;
                    txt.ForeColor = TextPrimary;
                }
                else if (control is DataGridView dgv)
                {
                    dgv.BackgroundColor = BackgroundDeep;
                    dgv.GridColor = BackgroundCard;
                    dgv.RowHeadersVisible = false;
                    dgv.DefaultCellStyle.BackColor = BackgroundDeep;
                    dgv.DefaultCellStyle.ForeColor = TextPrimary;
                    dgv.DefaultCellStyle.SelectionBackColor = BackgroundCard;
                    dgv.DefaultCellStyle.SelectionForeColor = CyanBright;
                    dgv.ColumnHeadersDefaultCellStyle.BackColor = BackgroundCard;
                    dgv.ColumnHeadersDefaultCellStyle.ForeColor = TextSecondary;
                    dgv.EnableHeadersVisualStyles = false;
                }
                else if (control is Panel pnl)
                {
                    if (pnl.Name == "panelMain" || pnl.Name == "panelLeftNav" || pnl.Name == "panelTop" || 
                        pnl.Name == "panelNavContent" || pnl.Name == "panelNavHeader" || pnl.Name == "panelUserInfo")
                    {
                        ApplyToControls(pnl.Controls);
                    }
                    else
                    {
                        pnl.BackColor = BackgroundCard;
                        ApplyToControls(pnl.Controls);
                    }
                }
                else if (control is Label lbl)
                {
                    lbl.BackColor = Color.Transparent;
                    lbl.ForeColor = TextPrimary;
                }
                else if (control is GroupBox grp)
                {
                    grp.BackColor = Color.Transparent;
                    grp.ForeColor = TextPrimary;
                    ApplyToControls(grp.Controls);
                }

                if (control.HasChildren && !(control is Panel))
                {
                    ApplyToControls(control.Controls);
                }
            }
        }

        public static void ApplyGlassCardStyle(Control control)
        {
            if (control is Panel panel)
            {
                panel.BackColor = Color.FromArgb(179, 30, 41, 59);
                ApplyToControls(panel.Controls);
            }
        }

        public static void ApplyTitleLabelStyle(Label label)
        {
            label.Font = TitleFont;
            label.ForeColor = CyanBright;
            label.BackColor = Color.Transparent;
        }

        public static void ApplySecondaryButtonStyle(Button button)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Font = ButtonFont;
            button.ForeColor = TextPrimary;
            button.BackColor = BackgroundCard;
            button.Cursor = Cursors.Hand;
        }
    }
}
