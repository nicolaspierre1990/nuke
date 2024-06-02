using JetBrains.Annotations;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.CI.GitLab.Configuration;

[PublicAPI]
public class GitLabConfiguration : ConfigurationEntity
{
    public (string Key, string Value)[] Variables { get; set; } = [];
    public string[] Stages { get; set; } = [];
    public GitLabPipelineJob[] Jobs { get; set; }

    public override void Write(CustomFileWriter writer)
    {
        if(Stages.Length > 0)
        {
            writer.WriteLine("# List of stages for jobs, and their order of execution");
            writer.WriteLine("stages:");
            using (writer.Indent())
            {
                Stages.ForEach(x => writer.WriteLine($"- {x}"));
            }
        }

        if (Variables.Length > 0)
        {
            writer.WriteLine("variables:");
            using (writer.Indent())
            {
                Variables.ForEach(x => writer.WriteLine($"{x.Key}: {x.Value}"));
            }
        }

        if (Jobs.Length > 0)
        {
            writer.WriteLine("jobs:");
            using (writer.Indent())
            {
                Jobs.ForEach(x => x.Write(writer));
            }
        }
    }
}
