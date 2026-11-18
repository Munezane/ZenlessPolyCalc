using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
#nullable disable
namespace ZenlessPolyCalc
{
    internal class ConfigManager
    {
        public ConfigManager() {
            LoadConfig();
        }
        public int CurrentPolychromes { get; set; } = 0;
        public int CurrentTapes { get; set; } = 0;
        public int RemainingEventPolychromes { get; set; } = 0;
        public bool AssumeShiyuARank { get; set; } = false;
        public DateTime PatchEndDate { get; set; } = DateTime.Now.Date;
        private const string PatchEndDateFormat = "yyyy-MM-dd";//we don't care about time

        public void SaveConfig()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            AppSettingsSection app = config.AppSettings;

            KeyValueConfigurationElement kvpCurrentPolychromes = app.Settings["CurrentPolychromes"];
            KeyValueConfigurationElement kvpCurrentTapes = app.Settings["CurrentTapes"];
            KeyValueConfigurationElement kvpRemainingEventPolychromes = app.Settings["RemainingEventPolychromes"];
            KeyValueConfigurationElement kvpAssumeShiyuARank = app.Settings["AssumeShiyuARank"];
            KeyValueConfigurationElement kvpPatchEndDate= app.Settings["PatchEndDate"];

            kvpCurrentPolychromes.Value = CurrentPolychromes.ToString();
            kvpCurrentTapes.Value = CurrentTapes.ToString();
            kvpRemainingEventPolychromes.Value = RemainingEventPolychromes.ToString();
            kvpAssumeShiyuARank.Value = AssumeShiyuARank.ToString();
            kvpPatchEndDate.Value = PatchEndDate.ToString(PatchEndDateFormat); 
            config.Save(ConfigurationSaveMode.Modified);
        }
        private void CreateMissingConfigEntries(Configuration config, AppSettingsSection app = null)
        {
            if (app == null)
            {
                app = config.AppSettings;
            }
          
            KeyValueConfigurationElement kvpCurrentPolychromes = app.Settings["CurrentPolychromes"];
            KeyValueConfigurationElement kvpCurrentTapes = app.Settings["CurrentTapes"];
            KeyValueConfigurationElement kvpRemainingEventPolychromes = app.Settings["RemainingEventPolychromes"];
            KeyValueConfigurationElement kvpAssumeShiyuARank = app.Settings["AssumeShiyuARank"];
            KeyValueConfigurationElement kvpPatchEndDate = app.Settings["PatchEndDate"];
            //save default values if config file is empty, just to make actual loading more uniform
            bool blnNeedSaveConfig = false;
            if (kvpCurrentPolychromes == null)
            {
                app.Settings.Add("CurrentPolychromes", CurrentPolychromes.ToString());
                blnNeedSaveConfig = true;
            }
            if (kvpCurrentTapes == null)
            {
                app.Settings.Add("CurrentTapes", CurrentTapes.ToString());
                blnNeedSaveConfig = true;
            }
            if (kvpRemainingEventPolychromes == null)
            {
                app.Settings.Add("RemainingEventPolychromes", RemainingEventPolychromes.ToString());
                blnNeedSaveConfig = true;
            }
            if (kvpAssumeShiyuARank == null)
            {
                app.Settings.Add("AssumeShiyuARank", AssumeShiyuARank.ToString());
                blnNeedSaveConfig = true;
            }
            if (kvpPatchEndDate == null)
            {
                app.Settings.Add("PatchEndDate", PatchEndDate.ToString(PatchEndDateFormat));
                blnNeedSaveConfig = true;
            }
            if (blnNeedSaveConfig)
            {
                config.Save(ConfigurationSaveMode.Modified);
            }
        }
        public void LoadConfig()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            AppSettingsSection app = config.AppSettings;
            CreateMissingConfigEntries(config);
            //load values from config
            string savedCurrentPolychromes = app.Settings["CurrentPolychromes"]?.Value;
            if (!string.IsNullOrWhiteSpace(savedCurrentPolychromes))
            {
                CurrentPolychromes = int.Parse(savedCurrentPolychromes);
            }
            string savedCurrentTapes = app.Settings["CurrentTapes"]?.Value;
            if (!string.IsNullOrWhiteSpace(savedCurrentTapes))
            {
                CurrentTapes = int.Parse(savedCurrentTapes);
            }
            string savedRemainingEventPolychromes = app.Settings["RemainingEventPolychromes"]?.Value;
            if (!string.IsNullOrWhiteSpace(savedRemainingEventPolychromes))
            {
                RemainingEventPolychromes = int.Parse(savedRemainingEventPolychromes);
            }
            string savedAssumeShiyuARank = app.Settings["AssumeShiyuARank"]?.Value;
            if (!string.IsNullOrWhiteSpace(savedAssumeShiyuARank))
            {
                AssumeShiyuARank = bool.Parse(savedAssumeShiyuARank);
            }
            string savedPatchEndDate = app.Settings["PatchEndDate"]?.Value;
            if (!string.IsNullOrWhiteSpace(savedPatchEndDate))
            {
                PatchEndDate = DateTime.Parse(savedPatchEndDate, new DateTimeFormat(PatchEndDateFormat).FormatProvider);
            }
        }
    }
}
