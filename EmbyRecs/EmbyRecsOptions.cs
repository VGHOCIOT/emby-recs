using MediaBrowser.Model.Plugins;

namespace EmbyRecs
{
    public class EmbyRecsOptions : BasePluginConfiguration
    {
        public bool EnableExtractionDuringLibraryScan { get; set; } = true;
        public bool EnableLocalMediaFolderSaving { get; set; } = false;
    }
}