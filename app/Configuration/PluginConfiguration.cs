using MediaBrowser.Model.Plugins;

namespace EmbyRecs.Configuration
{
    public class PluginConfiguration : BasePluginConfiguration
    {
        public bool EnableExtractionDuringLibraryScan { get; set; }
        public bool EnableLocalMediaFolderSaving { get; set; }
    }
}