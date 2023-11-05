using System;
using System.Linq;
using Nuke.Common;
using Nuke.Common.Git;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Serilog;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Tools.MSBuild;
using Nuke.Common.Tools.PowerShell;
using static Nuke.Common.Tools.DotNet.DotNetTasks;
using System.IO.Compression;
using Nuke.Common.Utilities.Collections;

partial class Build : NukeBuild
{
    [Parameter("The build version")] string Version;
    [Solution(GenerateProjects = true)] Solution Solution;

    readonly AbsolutePath ArtifactsDirectory = RootDirectory / "artifacts";
    readonly AbsolutePath DynamoDistDirectory = RootDirectory / "src" / "distDyn";

    string DynAppName = "AU 2023 Dynamo Toolkit";
    string DynAppShortName = "AU2023DynamoToolkit";

    public static int Main () => Execute<Build>(x => x.Clean);

    Target Clean => _ => _
        .OnlyWhenStatic(() => IsLocalBuild)
        .Executes(() =>
        {
            ArtifactsDirectory.CreateOrCleanDirectory();
            DynamoDistDirectory.CreateOrCleanDirectory();

            foreach (var project in Solution.AllProjects.Where(project => project != Solution.AU2023DynamoToolkitBuild))
            {
                var path = project.Directory / "bin";
                Log.Information("Cleaning directory: {Directory}", path);
                path.CreateOrCleanDirectory();
            }
        });

    Target Compile => _ => _
        .TriggeredBy(Clean)
        .Executes(() =>
        {
            var configurations = SolutionConfigurations
            .Where(s => s.Contains("Release R")).ToList();

            //compile all the build
            foreach (var configuration in configurations)
            {
                DotNetBuild(settings => settings
                    .SetConfiguration(configuration)
                    .SetProjectFile(Solution.AU2023DynamoToolkitUI)
                    .SetVersion(Version)
                    .SetVerbosity(DotNetVerbosity.Minimal));
            }
        });

    Target CreateArtifacts => _ => _
        .TriggeredBy(Compile)
        .OnlyWhenStatic(() => IsLocalBuild || GitRepository.IsOnMainBranch())
        .Executes(() =>
        {
            Log.Information($"Creating Dynamo zip file...");
            DynamoDistDirectory.ZipTo(ArtifactsDirectory / $"{DynAppShortName}-{Version}.zip",
                compressionLevel: CompressionLevel.Optimal
                );
        });

    Target CleanLocal => _ => _
        .TriggeredBy(CreateArtifacts)
        .OnlyWhenStatic(() => IsLocalBuild)
        .Executes(() =>
        {
            Log.Information("Cleaning local Directories");

            var dynamoLocalPath = ((AbsolutePath)Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)) /
                    "Dynamo";

            var versionDirs = dynamoLocalPath.GlobDirectories("**/2.*");

            versionDirs.ForEach(dir =>
            {
                var packageFodler = dir / "packages" / DynAppShortName;
                packageFodler.DeleteDirectory();
            });
        });

}
