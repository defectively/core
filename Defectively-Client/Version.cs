using Defectively.Compatibility;

namespace DefectivelyClient
{
    public class Version : Defectively.Compatibility.Version
    {
        public override int Major { get; set; } = 2;
        public override int Minor { get; set; } = 2;
        public override int Patch { get; set; } = 42;
        public override VersioningProfiler.Suffixes Suffix { get; set; } = VersioningProfiler.Suffixes.none;
        public override string ReleaseDate { get; set; } = "17w05";
        public override string Commit { get; set; } = "5f510e5"; // #festival-version-control new
        public override string SupportedVersion { get; set; } = "2.2.0-alpha [b236067]";
    }
}
