﻿using Newtonsoft.Json;

namespace dotMCLauncher.Profiling
{
    public class Profile
    {
        /// <summary>
        /// Profile's name. 
        /// </summary>
        [JsonProperty("name")]
        public string ProfileName { get; set; }

        /// <summary>
        /// Game's working directory. 
        /// </summary>
        [JsonProperty("gameDir")]
        public string WorkingDirectory { get; set; }

        /// <summary>
        /// Selected version ID.
        /// </summary>
        [JsonProperty("lastVersionId")]
        public string SelectedVersion { get; set; }

        /// <summary>
        /// Window size info.
        /// </summary>
        [JsonProperty("resolution")]
        public WindowInfo WindowInfo { get; set; }

        /// <summary>
        /// Allowed build types. 
        /// </summary>
        [JsonProperty("allowedReleaseTypes")]
        public string[] AllowedReleaseTypes { get; set; }

        /// <summary>
        /// Disallowed build types. Not used in official launcher.
        /// </summary>
        [JsonProperty("disallowedReleaseTypes")]
        public string[] DisallowedReleaseTypes { get; set; }

        /// <summary>
        /// Java executable file. 
        /// </summary>
        [JsonProperty("javaDir")]
        public string JavaExecutable { get; set; }

        /// <summary>
        /// Java arguments. 
        /// </summary>
        [JsonProperty("javaArgs")]
        public string JavaArguments { get; set; }

        /// <summary>
        /// The game will automatically connect to the selected server. 
        /// </summary>
        [JsonProperty("connectionOptions")]
        public ServerInfo ConnectionSettigs { get; set; }

        [JsonProperty("launcherVisibilityOnGameClose")]
        private string _launcherVisibilityOnGameClose { get; set; }

        /// <summary>
        /// Launcher state on  game closure. 
        /// </summary>
        [JsonIgnore]
        public LauncherVisibility LauncherVisibilityOnGameClose
        {
            get
            {
                switch (_launcherVisibilityOnGameClose)
                {
                    case null:
                        return LauncherVisibility.NULL;
                    case "hide launcher and re-open when game closes":
                        return LauncherVisibility.HIDDEN;
                    case "close launcher when game starts":
                        return LauncherVisibility.CLOSED;
                    default:
                        return LauncherVisibility.VISIBLE;
                }
            }
            set
            {
                // ReSharper disable once SwitchStatementMissingSomeCases
                switch (value)
                {
                    case LauncherVisibility.NULL:
                        _launcherVisibilityOnGameClose = null;
                        break;
                    case LauncherVisibility.HIDDEN:
                        _launcherVisibilityOnGameClose = "hide launcher and re-open when game closes";
                        break;
                    case LauncherVisibility.CLOSED:
                        _launcherVisibilityOnGameClose = "close launcher when game starts";
                        break;
                    default:
                        _launcherVisibilityOnGameClose = "keep the launcher open";
                        break;
                }
            }
        }

        public enum LauncherVisibility
        {
            /// <summary>
            /// Keep the launcher open
            /// </summary>
            VISIBLE,

            /// <summary>
            /// Hide launcher and re-open when game closes
            /// </summary>
            HIDDEN,

            /// <summary>
            /// Close launcher when game starts
            /// </summary>
            CLOSED,

            /// <summary>
            /// Use launcher's defaults
            /// </summary>
            NULL
        }

        /// <summary>
        /// Returns profile information in JSON format. 
        /// </summary>
        public override string ToString()
        {
            return ToString(Formatting.None);
        }

        /// <summary>
        /// Returns profile information in JSON format. 
        /// </summary>
        public string ToString(Formatting formatting)
        {
            return JsonConvert.SerializeObject(this, formatting, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
        }

        /// <summary>
        /// Parses profile from JSON text data. 
        /// </summary>
        /// <param name="json">JSON data.</param>
        public static Profile ParseProfile(string json)
        {
            return JsonConvert.DeserializeObject<Profile>(json);
        }
    }
}
