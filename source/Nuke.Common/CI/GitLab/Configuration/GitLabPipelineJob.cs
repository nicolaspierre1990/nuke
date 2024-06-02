using System;
using JetBrains.Annotations;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.GitLab.Configuration;

[PublicAPI]
public class GitLabPipelineJob : ConfigurationEntity
{
    public string Name { get; set; }
    public string StageName { get; set; }
    public GitLabPipelineConfiguration Step { get; set; }

    public override void Write(CustomFileWriter writer)
    {
        writer.WriteLine($"{Name}:");
        writer.Indent();
        writer.WriteLine($"stage: {StageName}");
        Step.Write(writer);
    }
}
