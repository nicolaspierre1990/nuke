using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Nuke.Common.CI.GitLab.Configuration;

[PublicAPI]
public abstract class GitLabPipelineConfiguration: ConfigurationEntity
{
    public string Name { get; set; }
}
