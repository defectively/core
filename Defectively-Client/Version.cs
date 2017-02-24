using Defectively.Compatibility;

namespace DefectivelyClient
{
    public class Version : Defectively.Compatibility.Version
    {
        public override int Major { get; set; } = 0;
        public override int Minor { get; set; } = 0;
        public override int Patch { get; set; } = 1;
        public override VersioningProfiler.Suffixes Suffix { get; set; } = VersioningProfiler.Suffixes.none;
        public override string ReleaseDate { get; set; } = "17w08";
        public override string Commit { get; set; } = "68db94d";
        public override string SupportedVersion { get; set; } = "0.0.1 [48d4440]";
    }
}
