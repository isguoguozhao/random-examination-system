using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

class IconConverter
{
    static void Main()
    {
        string inputPath = @"d:\project\接单\单位抽考win7软件\LOGO.png";
        string outputPath = @"d:\project\接单\单位抽考win7软件\LOGO.ico";

        try
        {
            using (Image image = Image.FromFile(inputPath))
            {
                // 创建 256x256 的图标
                using (Bitmap bitmap = new Bitmap(256, 256))
                {
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        g.DrawImage(image, 0, 0, 256, 256);
                    }

                    // 保存为 PNG 格式（作为图标使用）
                    bitmap.Save(outputPath.Replace(".ico", "_256.png"), ImageFormat.Png);
                }

                // 创建 64x64 的图标
                using (Bitmap bitmap = new Bitmap(64, 64))
                {
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        g.DrawImage(image, 0, 0, 64, 64);
                    }
                    bitmap.Save(outputPath.Replace(".ico", "_64.png"), ImageFormat.Png);
                }

                // 创建 32x32 的图标
                using (Bitmap bitmap = new Bitmap(32, 32))
                {
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        g.DrawImage(image, 0, 0, 32, 32);
                    }
                    bitmap.Save(outputPath.Replace(".ico", "_32.png"), ImageFormat.Png);
                }

                // 创建 16x16 的图标
                using (Bitmap bitmap = new Bitmap(16, 16))
                {
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        g.DrawImage(image, 0, 0, 16, 16);
                    }
                    bitmap.Save(outputPath.Replace(".ico", "_16.png"), ImageFormat.Png);
                }

                Console.WriteLine("图标文件已生成!");
                Console.WriteLine($"- {outputPath.Replace(".ico", "_256.png")}");
                Console.WriteLine($"- {outputPath.Replace(".ico", "_64.png")}");
                Console.WriteLine($"- {outputPath.Replace(".ico", "_32.png")}");
                Console.WriteLine($"- {outputPath.Replace(".ico", "_16.png")}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"错误: {ex.Message}");
        }
    }
}
