; 脚本文件: Setup.iss
[Setup]
; 应用程序名称
AppName=单位抽考系统
; 应用程序版本
AppVersion=1.0
; 默认安装目录
DefaultDirName={autopf}\单位抽考系统
; 默认开始菜单文件夹
DefaultGroupName=单位抽考系统
; 输出目录
OutputDir=.\Output
; 输出文件名
OutputBaseFilename=单位抽考系统安装程序_v1.0
; 安装程序图标
SetupIconFile=LOGO.ico
; 压缩方式
Compression=lzma
SolidCompression=yes
; 管理员权限
PrivilegesRequired=admin
; 允许安装到用户目录
PrivilegesRequiredOverridesAllowed=dialog
; 最低 .NET Framework 版本要求
MinVersion=6.1sp1

[Languages]
Name: "chinesesimplified"; MessagesFile: "compiler:Languages\ChineseSimplified.isl"

[Files]
; 主程序
Source: "bin\Release\单位抽考win7软件.exe"; DestDir: "{app}"; Flags: ignoreversion
; DLL文件
Source: "bin\Release\*.dll"; DestDir: "{app}"; Flags: ignoreversion
; SQLite原生库 (x86)
Source: "bin\Release\x86\SQLite.Interop.dll"; DestDir: "{app}"; Flags: ignoreversion
; 配置文件
Source: "bin\Release\*.config"; DestDir: "{app}"; Flags: ignoreversion
; LOGO文件
Source: "LOGO.png"; DestDir: "{app}"; Flags: ignoreversion

[Dirs]
; 创建数据目录
Name: "{app}\data"

[Icons]
; 开始菜单快捷方式
Name: "{group}\单位抽考系统"; Filename: "{app}\单位抽考win7软件.exe"; IconFilename: "{app}\单位抽考win7软件.exe"
Name: "{group}\卸载"; Filename: "{uninstallexe}"
; 桌面快捷方式
Name: "{commondesktop}\单位抽考系统"; Filename: "{app}\单位抽考win7软件.exe"; IconFilename: "{app}\单位抽考win7软件.exe"

[Run]
; 安装完成后可选运行
Filename: "{app}\单位抽考win7软件.exe"; Description: "立即运行单位抽考系统"; Flags: nowait postinstall skipifsilent