namespace Landorphan.BuildMap.Abstractions.VisualStudioSolutionFile
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Landorphan.BuildMap.Model.Support;
    using Microsoft.Build.Construction;

    public class ProjectInSolutionAbstraction : IProjectInSoltuion
    {
        private ProjectInSolution projectInSolution;

        public ProjectInSolutionAbstraction(ProjectInSolution projectInSolution)
        {
            this.projectInSolution = projectInSolution;
        }

        public IEnumerable<Guid> GetProjectsThisProjectDependsOn()
        {
            List<Guid> retval = new GuidList(
                (from g in projectInSolution.Dependencies
                    select new Guid(g)).ToList());
            return retval;
        }

        public Guid SlnGuid => new Guid(projectInSolution.ProjectGuid);
        public string AbsolutePath => projectInSolution.AbsolutePath;
        public string ProjectName => projectInSolution.ProjectName;
        public SolutionProjectType ProjectType => projectInSolution.ProjectType;
        public string RelativePath => projectInSolution.RelativePath;
    }
}