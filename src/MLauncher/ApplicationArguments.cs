using CommandLine;

namespace MLauncher
{
    public class ApplicationArguments
    {
        [Option('d', "working-directory")]
        public string WorkingDirectory { get; set; }

        [Option("offline-mode")]
        public bool OfflineMode { get; set; }
    }
}
