using System.Drawing;
using System.Windows.Forms;

namespace 单位抽考win7软件.Common
{
    /// <summary>
    /// SunnyUI 主题配置类
    /// 配色方案：深蓝(#003366) + 米黄(#F5F5DC)
    /// </summary>
    public static class SunnyUITheme
    {
        // 主色调 - 深蓝
        public static Color PrimaryColor = Color.FromArgb(0, 51, 102);      // #003366
        public static Color PrimaryLight = Color.FromArgb(51, 102, 153);  // #336699
        public static Color PrimaryDark = Color.FromArgb(0, 34, 68);      // #002244

        // 辅助色 - 米黄
        public static Color SecondaryColor = Color.FromArgb(245, 245, 220); // #F5F5DC
        public static Color SecondaryLight = Color.FromArgb(255, 255, 240); // #FFFFF0
        public static Color SecondaryDark = Color.FromArgb(220, 220, 195);  // #DCDCC3

        // 功能色
        public static Color SuccessColor = Color.FromArgb(92, 184, 92);     // 成功绿
        public static Color WarningColor = Color.FromArgb(240, 173, 78);    // 警告橙
        public static Color DangerColor = Color.FromArgb(217, 83, 79);      // 危险红
        public static Color InfoColor = Color.FromArgb(91, 192, 222);       // 信息蓝

        // 文字颜色
        public static Color TextPrimary = Color.FromArgb(51, 51, 51);       // 主要文字
        public static Color TextSecondary = Color.FromArgb(102, 102, 102);  // 次要文字
        public static Color TextLight = Color.FromArgb(255, 255, 255);      // 浅色文字

        // 边框颜色
        public static Color BorderColor = Color.FromArgb(200, 200, 200);

        // 字体配置
        public static Font DefaultFont = new Font("微软雅黑", 10.5F);
        public static Font TitleFont = new Font("微软雅黑", 14F, FontStyle.Bold);
        public static Font ButtonFont = new Font("微软雅黑", 12F);

        /// <summary>
        /// 应用主题到按钮
        /// </summary>
        public static void ApplyButtonStyle(Button btn)
        {
            btn.BackColor = PrimaryColor;
            btn.ForeColor = TextLight;
            btn.Font = ButtonFont;
            btn.Height = 40;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = Cursors.Hand;

            // 添加鼠标悬停效果
            btn.MouseEnter += (s, e) => btn.BackColor = PrimaryLight;
            btn.MouseLeave += (s, e) => btn.BackColor = PrimaryColor;
        }

        /// <summary>
        /// 应用主题到窗体
        /// </summary>
        public static void ApplyFormStyle(Form form)
        {
            form.BackColor = SecondaryColor;
            form.Font = DefaultFont;
            
            // 设置窗体标题栏颜色（通过自定义绘制实现）
            // 注意：WinForms原生不支持直接修改标题栏颜色
        }

        /// <summary>
        /// 应用主题到面板
        /// </summary>
        public static void ApplyPanelStyle(Panel panel)
        {
            panel.BackColor = SecondaryLight;
            panel.BorderStyle = BorderStyle.None;
        }

        /// <summary>
        /// 应用主题到文本框
        /// </summary>
        public static void ApplyTextBoxStyle(TextBox txt)
        {
            txt.BackColor = Color.White;
            txt.ForeColor = TextPrimary;
            txt.Font = DefaultFont;
            txt.BorderStyle = BorderStyle.FixedSingle;
        }

        /// <summary>
        /// 应用主题到下拉框
        /// </summary>
        public static void ApplyComboBoxStyle(ComboBox cmb)
        {
            cmb.BackColor = Color.White;
            cmb.ForeColor = TextPrimary;
            cmb.Font = DefaultFont;
            cmb.FlatStyle = FlatStyle.Flat;
        }

        /// <summary>
        /// 应用主题到数据表格
        /// </summary>
        public static void ApplyDataGridViewStyle(DataGridView dgv)
        {
            dgv.BackgroundColor = SecondaryColor;
            dgv.BorderStyle = BorderStyle.None;
            
            // 列标题样式
            dgv.ColumnHeadersDefaultCellStyle.BackColor = PrimaryColor;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = TextLight;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("微软雅黑", 11F, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 40;
            
            // 行样式
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = TextPrimary;
            dgv.DefaultCellStyle.Font = DefaultFont;
            dgv.DefaultCellStyle.SelectionBackColor = PrimaryLight;
            dgv.DefaultCellStyle.SelectionForeColor = TextLight;
            
            // 交替行颜色
            dgv.AlternatingRowsDefaultCellStyle.BackColor = SecondaryLight;
            
            // 其他设置
            dgv.RowTemplate.Height = 35;
            dgv.EnableHeadersVisualStyles = false;
        }

        /// <summary>
        /// 创建主按钮（深蓝色）
        /// </summary>
        public static Button CreatePrimaryButton(string text, int width = 100)
        {
            var btn = new Button
            {
                Text = text,
                Width = width,
                Height = 40,
                BackColor = PrimaryColor,
                ForeColor = TextLight,
                Font = ButtonFont,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btn.FlatAppearance.BorderSize = 0;
            
            // 悬停效果
            btn.MouseEnter += (s, e) => btn.BackColor = PrimaryLight;
            btn.MouseLeave += (s, e) => btn.BackColor = PrimaryColor;
            
            return btn;
        }

        /// <summary>
        /// 创建成功按钮（绿色）
        /// </summary>
        public static Button CreateSuccessButton(string text, int width = 100)
        {
            var btn = new Button
            {
                Text = text,
                Width = width,
                Height = 40,
                BackColor = SuccessColor,
                ForeColor = TextLight,
                Font = ButtonFont,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btn.FlatAppearance.BorderSize = 0;
            return btn;
        }

        /// <summary>
        /// 创建危险按钮（红色）
        /// </summary>
        public static Button CreateDangerButton(string text, int width = 100)
        {
            var btn = new Button
            {
                Text = text,
                Width = width,
                Height = 40,
                BackColor = DangerColor,
                ForeColor = TextLight,
                Font = ButtonFont,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btn.FlatAppearance.BorderSize = 0;
            return btn;
        }
    }
}
