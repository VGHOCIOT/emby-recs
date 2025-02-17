using System;
using System.Collections.Generic;
using MediaBrowser.Controller;
using MediaBrowser.Common.Configuration;
using MediaBrowser.Common.Plugins;
using MediaBrowser.Model.Plugins;
using MediaBrowser.Model.Serialization;
using EmbyRecs.Configuration;
using MediaBrowser.Model.Drawing;

namespace EmbyRecs
{
    public class Plugin : BasePlugin<PluginConfiguration>, IHasWebPages
    {
        private readonly IServerApplicationHost _appHost;
        public Plugin(IApplicationPaths applicationPaths, IXmlSerializer xmlSerializer, IServerApplicationHost appHost) 
            : base(applicationPaths, xmlSerializer) 
        {
            Instance = this;
            _appHost = appHost;
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

        public PluginConfiguration PluginConfiguration => Configuration;

        public IEnumerable<PluginPageInfo> GetPages()
        {
            return new[]
            {
                new PluginPageInfo
                {
                    Name = "EmbyRecs",
                    EmbeddedResourcePath = GetType().Namespace + ".Configuration.configPage.html",
                    EnableInMainMenu = true
                },
                new PluginPageInfo
                {
                    Name = "embyrecsjs",
                    EmbeddedResourcePath = GetType().Namespace + ".Configuration.embyrecs.js"
                }
            };
        }
    }
}