var solutionFile = "./RichillCapital.SharedKernel.sln";
var release = Argument("Configuration", "Release");
var outputDirectory = "./artifacts";

// Load environment variables 
var API_KEY = EnvironmentVariable("API_KEY");

Task("Clean")
    .Does(() =>
    {
        CleanDirectory(outputDirectory);
    });

Task("Restore")
    .IsDependentOn("Clean")
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
            OutputDirectory = outputDirectory,
        });
    });

Task("Default")
    .IsDependentOn("Pack")
    .Does(() =>
    {
    });

Task("Release")
    .IsDependentOn("Pack")
    .Does(() =>
    {
        DotNetNuGetPush("./artifacts/*.nupkg", new DotNetNuGetPushSettings()
        {
            Source = "https://api.nuget.org/v3/index.json",
            ApiKey = EnvironmentVariable("NUGET_API_KEY"),
        });
    });

// Run this target with no specified target
var target = Argument("target", "Default");

RunTarget(target);