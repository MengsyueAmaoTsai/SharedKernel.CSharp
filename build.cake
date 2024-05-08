var solutionFile = "./RichillCapital.SharedKernel.sln";
var release = Argument("Configuration", "Release");

Task("Restore")
    .Does(() =>
    {
        DotNetRestore(solutionFile);
    });

Task("Build")
    .IsDependentOn("Restore")
    .Does(() =>
    {
        DotNetBuild(solutionFile, new DotNetBuildSettings()
        {
            Configuration = release,
            NoRestore = true,
        });
    });

Task("Test")
    .IsDependentOn("Build")
    .Does(() =>
    {
        DotNetTest(solutionFile, new DotNetTestSettings()
        {
            Configuration = release,
            NoBuild = true,
            NoRestore = true,
        });
    });

Task("Pack")
    .IsDependentOn("Test")
    .Does(() =>
    {
        DotNetPack(solutionFile, new DotNetPackSettings()
        {
            Configuration = release,
            NoBuild = true,
            NoRestore = true,
            OutputDirectory = "./artifacts",
        });
    });

Task("Default")
    .IsDependentOn("Pack")
    .Does(() =>
    {
    });

// Run this target with no specified target
var target = Argument("target", "Default");
RunTarget(target);