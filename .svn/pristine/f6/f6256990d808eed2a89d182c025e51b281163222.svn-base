



#####DEL  /S /Q  D:\YAOHUA_内网SVN\项目代码\JKY.TEST\发布\*.*


DEL  /S /Q  D:\YAOHUA_内网SVN\项目代码\JKY.TEST\JKY.TEST\Bin\*.*
DEL  /S /Q  D:\YAOHUA_内网SVN\项目代码\JKY.TEST\JKY.TEST.BLL\bin\*.*
DEL  /S /Q  D:\YAOHUA_内网SVN\项目代码\JKY.TEST\JKY.TEST.CONSOLE\bin\*.*
DEL  /S /Q  D:\YAOHUA_内网SVN\项目代码\JKY.TEST\JKY.TEST.INTF\bin\*.*
DEL  /S /Q  D:\YAOHUA_内网SVN\项目代码\JKY.TEST\JKY.TEST.WINFORM\bin\*.*



#################################
C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild "D:\YAOHUA_内网SVN\项目代码\JKY.TEST\JKY.TEST.BLL\JKY.TEST.BLL.csproj"  /t:ReBuild /p:Configuration=Release  /p:VisualStudioVersion=14.0  /tv:14.0


C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild "D:\YAOHUA_内网SVN\项目代码\JKY.TEST\JKY.TEST\JKY.TEST.csproj"  /t:ReBuild /p:Configuration=Release  /p:VisualStudioVersion=14.0  /tv:14.0
#################################


C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild "D:\YAOHUA_内网SVN\项目代码\JKY.TEST\JKY.TEST.INTF\JKY.TEST.INTF.csproj"  /t:ReBuild /p:Configuration=Release  /p:VisualStudioVersion=14.0  /tv:14.0


C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild "D:\YAOHUA_内网SVN\项目代码\JKY.TEST\JKY.TEST.CONSOLE\JKY.TEST.CONSOLE.csproj"  /t:ReBuild /p:Configuration=Release  /p:VisualStudioVersion=14.0  /tv:14.0


#################################


C:\Windows\Microsoft.NET\Framework\v4.0.30319\msbuild  D:\YAOHUA_内网SVN\项目代码\JKY.TEST\JKY.TEST\JKY.TEST.csproj  /t:ResolveReferences;Compile /t:_WPPCopyWebApplication /p:Configuration=Release     /p:VisualStudioVersion=14.0       /tv:14.0     /p:WebProjectOutputDir=D:\YAOHUA_内网SVN\项目代码\JKY.TEST\发布\



C:\Windows\Microsoft.NET\Framework\v4.0.30319\msbuild  D:\YAOHUA_内网SVN\项目代码\JKY.TEST\JKY.TEST.INTF\JKY.TEST.INTF.csproj  /t:ResolveReferences;Compile /t:_WPPCopyWebApplication /p:Configuration=Release     /p:VisualStudioVersion=14.0     /tv:14.0       /p:WebProjectOutputDir=D:\YAOHUA_内网SVN\项目代码\JKY.TEST\发布INTF\







#################################








DEL D:\YAOHUA_内网SVN\项目代码\JKY.TEST\发布\Web.config
RD /S /Q "D:\YAOHUA_内网SVN\项目代码\JKY.TEST\发布\_Config\"

DEL D:\YAOHUA_内网SVN\项目代码\JKY.TEST\发布\BIN\*.PDB

#################################





DEL D:\YAOHUA_内网SVN\项目代码\JKY.TEST\发布INTF\Web.config
RD /S /Q "D:\YAOHUA_内网SVN\项目代码\JKY.TEST\发布INTF\_Config\"

DEL D:\YAOHUA_内网SVN\项目代码\JKY.TEST\发布INTF\BIN\*.PDB

#################################






DEL  /S /Q D:\YAOHUA_内网SVN\项目代码\JKY.TEST\发布\FormTemplate\

XCOPY /E /C /Y  D:\YAOHUA_内网SVN\项目代码\JKY.TEST\JKY.TEST\FormTemplate\*.*  D:\YAOHUA_内网SVN\项目代码\JKY.TEST\发布\FormTemplate\
XCOPY /E /C /Y  D:\YAOHUA_内网SVN\项目代码\JKY.TEST\JKY.TEST\_js\*.*  D:\YAOHUA_内网SVN\项目代码\JKY.TEST\发布\_js\
XCOPY /E /C /Y  D:\YAOHUA_内网SVN\项目代码\JKY.TEST\JKY.TEST\_css\*.*  D:\YAOHUA_内网SVN\项目代码\JKY.TEST\发布\_css\
XCOPY /E /C /Y  D:\YAOHUA_内网SVN\项目代码\JKY.TEST\JKY.TEST\css\*.*  D:\YAOHUA_内网SVN\项目代码\JKY.TEST\发布\css\
XCOPY /E /C /Y  D:\YAOHUA_内网SVN\项目代码\JKY.TEST\JKY.TEST\_images\*.*  D:\YAOHUA_内网SVN\项目代码\JKY.TEST\发布\_images\
XCOPY /E /C /Y  D:\YAOHUA_内网SVN\项目代码\JKY.TEST\JKY.TEST\images\*.*  D:\YAOHUA_内网SVN\项目代码\JKY.TEST\发布\images\
XCOPY /E /C /Y  D:\YAOHUA_内网SVN\项目代码\JKY.TEST\JKY.TEST\key\*.*  D:\YAOHUA_内网SVN\项目代码\JKY.TEST\发布\key\

#################################


XCOPY /E /C /Y  D:\YAOHUA_内网SVN\项目代码\JKY.TEST\JKY.TEST.CONSOLE\bin\Release\*.exe  D:\YAOHUA_外网SVN\IIS站点\JKY.TEST.CONSOLE\
XCOPY /E /C /Y  D:\YAOHUA_内网SVN\项目代码\JKY.TEST\JKY.TEST.CONSOLE\bin\Release\*.dll  D:\YAOHUA_外网SVN\IIS站点\JKY.TEST.CONSOLE\



XCOPY /E /C /Y  D:\YAOHUA_内网SVN\项目代码\JKY.TEST\发布\*.*  D:\YAOHUA_外网SVN\IIS站点\JKY.TEST\

XCOPY /E /C /Y  D:\YAOHUA_内网SVN\项目代码\JKY.TEST\发布INTF\*.*  D:\YAOHUA_外网SVN\IIS站点\JKY.TEST.INTF\



#################################



D:
CD D:\YAOHUA_内网SVN\项目代码\JKY.TEST\Document\BAT
RENAME   外网发布.BAT   ____外网发布.BAT
DEL    外网发布.BAT

