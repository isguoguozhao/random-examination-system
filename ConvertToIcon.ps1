# 将 LOGO.jpg 转换为 LOGO.ico
Add-Type -AssemblyName System.Drawing

$inputPath = "d:\project\接单\单位抽考win7软件\LOGO.png"
$outputPath = "d:\project\接单\单位抽考win7软件\LOGO.ico"

# 加载图片
$image = [System.Drawing.Image]::FromFile($inputPath)

# 创建多个尺寸的图标
$sizes = @(16, 32, 48, 64, 128, 256)
$bitmaps = @()
0
foreach ($size in $sizes) {
    $bitmap = New-Object System.Drawing.Bitmap($size, $size)
    $graphics = [System.Drawing.Graphics]::FromImage($bitmap)
    $graphics.InterpolationMode = [System.Drawing.Drawing2D.InterpolationMode]::HighQualityBicubic
    $graphics.DrawImage($image, 0, 0, $size, $size)
    $graphics.Dispose()
    $bitmaps += $bitmap
}

# 保存为 ICO 文件
$fs = [System.IO.FileStream]::new($outputPath, [System.IO.FileMode]::Create)
$writer = [System.IO.BinaryWriter]::new($fs)

# ICO 文件头
$writer.Write([byte]0)  # 保留
$writer.Write([byte]0)  # 保留
$writer.Write([byte]1)  # 类型 (1 = 图标)
$writer.Write([byte]0)  # 类型高位
$writer.Write([byte]$bitmaps.Count)  # 图像数量
$writer.Write([byte]0)  # 数量高位

# 计算偏移量
$offset = 6 + ($bitmaps.Count * 16)

# 写入图像目录
for ($i = 0; $i -lt $bitmaps.Count; $i++) {
    $width = $bitmaps[$i].Width
    $height = $bitmaps[$i].Height
    if ($width -eq 256) { $width = 0 }
    if ($height -eq 256) { $height = 0 }
    
    $writer.Write([byte]$width)  # 宽度
    $writer.Write([byte]$height)  # 高度
    $writer.Write([byte]0)  # 颜色数 (0 = 真彩色)
    $writer.Write([byte]0)  # 保留
    $writer.Write([byte]1)  # 颜色平面数
    $writer.Write([byte]0)  # 颜色平面数高位
    $writer.Write([byte]32)  # 每像素位数
    $writer.Write([byte]0)  # 每像素位数高位
    
    # 计算图像大小
    $ms = [System.IO.MemoryStream]::new()
    $bitmaps[$i].Save($ms, [System.Drawing.Imaging.ImageFormat]::Png)
    $size = $ms.Length
    $writer.Write([int]$size)
    $writer.Write([int]$offset)
    $offset += $size
    $ms.Dispose()
}

# 写入图像数据
for ($i = 0; $i -lt $bitmaps.Count; $i++) {
    $ms = [System.IO.MemoryStream]::new()
    $bitmaps[$i].Save($ms, [System.Drawing.Imaging.ImageFormat]::Png)
    $writer.Write($ms.ToArray())
    $ms.Dispose()
    $bitmaps[$i].Dispose()
}

$writer.Close()
$fs.Close()
$image.Dispose()

Write-Host "图标文件已生成: $outputPath"
