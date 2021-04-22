using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Newtonsoft.Json;

namespace EkdObjViewer.Utils
{
    public static class ConfigLoader
    {
        private static readonly string ConfigFileName = "config.json";

        public static Config Load()
        {
            Config config;
            if(File.Exists(ConfigFileName))
            {
                var json = File.ReadAllText(ConfigFileName);
                config = JsonConvert.DeserializeObject<Config>(json);
            }
            else
            {
                config = new Config();
                Save(config);
            }
            return config;
        }

        public static void Save(Config config)
        {
            var json = JsonConvert.SerializeObject(config, Formatting.Indented);
            File.WriteAllText(ConfigFileName, json);
        }
    }
}
