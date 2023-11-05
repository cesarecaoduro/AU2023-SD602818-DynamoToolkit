using Nuke.Common.ProjectModel;
using Nuke.Common.Tools.MSBuild;
using System;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Linq;

partial class Build
{
    string[] Configurations;
    public IEnumerable<string> SolutionConfigurations { get; private set; }

    protected override void OnBuildInitialized()
    {
        Configurations = new[]
        {
            "Release*",
        };
        SolutionConfigurations = GlobBuildConfigurations();
    }

    IEnumerable<string> GlobBuildConfigurations()
    {
        var solConf = Solution.Configurations;
        var configurations = Solution.Configurations
            .Select(pair => pair.Key)
            .Select(config => config.Remove(config.LastIndexOf('|')))
            .Where(config => Configurations.Any(wildcard => FileSystemName.MatchesSimpleExpression(wildcard, config)))
            .ToList();

        if (configurations.Count == 0)
            throw new Exception($"No solution configurations have been found. Pattern: {string.Join(" | ", Configurations)}");

        return configurations;
    }
}
