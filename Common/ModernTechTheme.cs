using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace 单位抽考win7软件.Common
{
    public static class ModernTechTheme
    {
        #region 颜色定义

        public static Color BackgroundDeep = Color.FromArgb(15, 23, 42);
        public static Color BackgroundCard = Color.FromArgb(30, 41, 59);
        public static Color BackgroundTertiary = Color.FromArgb(51, 65, 85);

        public static Color TextPrimary = Color.FromArgb(203, 213, 225);
        public static Color TextSecondary = Color.FromArgb(148, 163, 184);
        public static Color TextMuted = Color.FromArgb(100, 116, 139);
        public static Color TextWhite = Color.White;

        public static Color CyanStart = Color.FromArgb(6, 182, 212);
        public static Color CyanEnd = Color.FromArgb(14, 165, 233);
        public static Color CyanBright = Color.FromArgb(30, 144, 255);

        public static Color SuccessStart = Color.FromArgb(16, 185, 129);
        public static Color SuccessEnd = Color.FromArgb(5, 150, 105);

        public static Color WarningStart = Color.FromArgb(245, 158, 11);
        public static Color WarningEnd = Color.FromArgb(217, 119, 6);

        public static Color DangerStart = Color.FromArgb(239, 68, 68);
        public static Color DangerEnd = Color.FromArgb(220, 38, 38);

        public static Color BorderLight = Color.FromArgb(148, 163, 184, 26);
        public static Color BorderDark = Color.FromArgb(30, 41, 59);

        #endregion

        #region 字体定义

        public static Font TitleFont = new Font("微软雅黑", 18F, FontStyle.Bold);
        public static Font HeadingFont = new Font("微软雅黑", 16F, FontStyle.Bold);
        public static Font BodyFont = new Font("微软雅黑", 14F, FontStyle.Regular);
        public static Font SmallFont = new Font("微软雅黑", 12F, FontStyle.Regular);
        public static Font ButtonFont = new Font("微软雅黑", 12F, FontStyle.Regular);

        #endregion

        #region 主题应用方法

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
                    ApplyButtonStyle(btn);
                }
                else if (control is TextBox txt)
                {
                    ApplyTextBoxStyle(txt);
                }
                else if (control is DataGridView dgv)
                {
                    ApplyDataGridViewStyle(dgv);
                }
                else if (control is Panel pnl)
                {
                    ApplyPanelStyle(pnl);
                    ApplyToControls(pnl.Controls);
                }
                else if (control is GroupBox grp)
                {
                    ApplyGroupBoxStyle(grp);
                    ApplyToControls(grp.Controls);
                }
                else if (control is Label lbl)
                {
                    ApplyLabelStyle(lbl);
                }
                else if (control is TreeView tv)
                {
                    ApplyTreeViewStyle(tv);
                }
                else if (control is ComboBox cmb)
                {
                    ApplyComboBoxStyle(cmb);
                }

                if (control.HasChildren)
                {
                    ApplyToControls(control.Controls);
                }
            }
        }

        #endregion

        #region 控件样式方法

        public static void ApplyButtonStyle(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Height = 44;
            btn.Font = ButtonFont;
            btn.ForeColor = TextWhite;
            btn.BackColor = CyanEnd;
            btn.Cursor = Cursors.Hand;

            btn.Paint += (s, e) =>
            {
                var rect = new Rectangle(0, 0, btn.Width, btn.Height);
                using (var brush = new LinearGradientBrush(rect, CyanStart, CyanEnd, LinearGradientMode.Horizontal))
                {
                    e.Graphics.FillRectangle(brush, rect);
                }

                TextRenderer.DrawText(e.Graphics, btn.Text, btn.Font, rect, btn.ForeColor,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            };

            btn.MouseEnter += (s, e) => btn.Invalidate();
            btn.MouseLeave += (s, e) => btn.Invalidate();
        }

        public static void ApplySecondaryButtonStyle(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = CyanBright;
            btn.FlatAppearance.BorderSize = 1;
            btn.Height = 40;
            btn.Font = ButtonFont;
            btn.ForeColor = CyanBright;
            btn.BackColor = Color.Transparent;
            btn.Cursor = Cursors.Hand;
        }

        public static void ApplyDangerButtonStyle(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Height = 40;
            btn.Font = ButtonFont;
            btn.ForeColor = TextWhite;
            btn.BackColor = DangerEnd;
            btn.Cursor = Cursors.Hand;
        }

        public static void ApplyTextBoxStyle(TextBox txt)
        {
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.Height = 44;
            txt.Font = BodyFont;
            txt.BackColor = BackgroundCard;
            txt.ForeColor = TextPrimary;
        }

        public static void ApplyDataGridViewStyle(DataGridView dgv)
        {
            dgv.BackgroundColor = BackgroundDeep;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = BorderDark;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.RowTemplate.Height = 56;
            dgv.ColumnHeadersHeight = 48;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = BackgroundCard;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = TextSecondary;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("微软雅黑", 11F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.EnableHeadersVisualStyles = false;

            dgv.DefaultCellStyle.BackColor = BackgroundDeep;
            dgv.DefaultCellStyle.ForeColor = TextPrimary;
            dgv.DefaultCellStyle.SelectionBackColor = BackgroundCard;
            dgv.DefaultCellStyle.SelectionForeColor = CyanBright;
            dgv.DefaultCellStyle.Font = BodyFont;
            dgv.DefaultCellStyle.Padding = new Padding(8, 0, 8, 0);
        }

        public static void ApplyPanelStyle(Panel pnl)
        {
            pnl.BackColor = BackgroundCard;
        }

        public static void ApplyGlassCardStyle(Panel pnl)
        {
            pnl.BackColor = Color.FromArgb(153, 30, 41, 59);
            pnl.Padding = new Padding(24);
        }

        public static void ApplyGroupBoxStyle(GroupBox grp)
        {
            grp.BackColor = Color.Transparent;
            grp.ForeColor = TextPrimary;
            grp.Font = HeadingFont;
        }

        public static void ApplyLabelStyle(Label lbl)
        {
            lbl.BackColor = Color.Transparent;
            lbl.ForeColor = TextPrimary;
        }

        public static void ApplyTitleLabelStyle(Label lbl)
        {
            lbl.BackColor = Color.Transparent;
            lbl.ForeColor = TextWhite;
            lbl.Font = TitleFont;
        }

        public static void ApplyTreeViewStyle(TreeView tv)
        {
            tv.BackColor = BackgroundDeep;
            tv.ForeColor = TextPrimary;
            tv.BorderStyle = BorderStyle.None;
            tv.Font = BodyFont;
        }

        public static void ApplyComboBoxStyle(ComboBox cmb)
        {
            cmb.FlatStyle = FlatStyle.Flat;
            cmb.BackColor = BackgroundCard;
            cmb.ForeColor = TextPrimary;
            cmb.Font = BodyFont;
            cmb.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        #endregion

        #region 渐变绘制辅助方法

        public static void DrawGradientBackground(Graphics g, Rectangle rect, Color startColor, Color endColor)
        {
            using (var brush = new LinearGradientBrush(rect, startColor, endColor, LinearGradientMode.Horizontal))
            {
                g.FillRectangle(brush, rect);
            }
        }

        public static void DrawRoundedRectangle(Graphics g, Rectangle rect, int radius, Color color)
        {
            using (var pen = new Pen(color, 1))
            using (var path = new GraphicsPath())
            {
                path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
                path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
                path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
                path.CloseFigure();
                g.DrawPath(pen, path);
            }
        }

        public static void FillRoundedRectangle(Graphics g, Rectangle rect, int radius, Color color)
        {
            using (var brush = new SolidBrush(color))
            using (var path = new GraphicsPath())
            {
                path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
                path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
                path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
                path.CloseFigure();
                g.FillPath(brush, path);
            }
        }

        #endregion
    }
}
