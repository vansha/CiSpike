﻿#r "System.Xml"
#r "System.Xml.Linq"

using Nake;
using Nake.FS;
using Nake.Log;
using Nake.Env;
using Nake.Run;

using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Diagnostics;

const string RootPath = "$NakeScriptDirectory$";
const string OutputPath = RootPath + @"\output\build";

var MSBuildExe = @"$ProgramFiles(x86)$\MSBuild\12.0\Bin\MSBuild.exe";

/// Builds sources in debug mode 
[Task] void Default()
{
    Build();
}

/// Wipeout all build output and temporary build files 
[Step] void Clean(string path = OutputPath)
{
    Delete(@"{path}\*.*|-:*.vshost.exe");
    RemoveDir(@"**\bin|**\obj|{path}\*|-:*.vshost.exe");    
}

/// Builds sources using specified configuration and output path
[Step] void Build(string config = "Debug", string outDir = OutputPath)
{
    Clean(outDir);

    Exec(MSBuildExe, 
        "CiSpike.sln /p:Configuration={config};OutDir={outDir};ReferencePath={outDir} /m");
}

/// Runs unit tests 
[Step] void Test(string outputPath = OutputPath)
{
    Build("Debug", outputPath);

    var tests = new FileSet{@"{outputPath}\*.Tests.dll"}.ToString(" ");
    Cmd(@"Packages\NUnit.Runners.2.6.4\tools\nunit-console.exe /framework:net-4.0 /noshadow /nologo /xml:output\test-results.xml {tests}");
}

/// Installs dependencies (packages) from NuGet 
[Task] void Install()
{
    var packagesDir = @"{RootPath}\Packages";

    var configs = XElement
        .Load(packagesDir + @"\repositories.config")
        .Descendants("repository")
        .Select(x => x.Attribute("path").Value.Replace("..", RootPath)); 

    foreach (var config in configs)
        Cmd(@"Tools\NuGet.exe install {config} -o {packagesDir}");
}