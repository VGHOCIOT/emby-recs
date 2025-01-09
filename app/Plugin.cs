using System;
using MediaBrowser.Common.Configuration;
using MediaBrowser.Common.Plugins;
using MediaBrowser.Model.Plugins;
using MediaBrowser.Model.Serialization;
using EmbyRecs.Configuration;

namespace EmbyRecs
{
    public class Plugin : BasePlugin<PluginConfiguration>
    {
        public Plugin(IApplicationPaths applicationPaths, IXmlSerializer xmlSerializer) 
            : base(applicationPaths, xmlSerializer) 
        {
            Instance = this;
        }

        private Guid _id = new Guid("b67ac8d0-efd6-4dbb-94a7-00aed19c0292");
        public override Guid Id
        {
            get { return _id; }
        }

        public static string PluginName = "Emby Recs";
        public static string PluginDescription = "A custom Emby plugin.";

        // <summary>
        // Gets the name of the plugin
        // </summary>
        // <value>The name.</value>
        public override string Name
        {
            get { return PluginName; }
        }

        // <summary>
        // Gets the description.
        // </summary>
        // <value>The description.</value>
        public override string Description
        {
            get { return PluginDescription; }
        }

        // <summary>
        // Gets the instance.
        // </summary>
        // <value>The instance.</value>
        public static Plugin Instance { get; private set; }
    }
}