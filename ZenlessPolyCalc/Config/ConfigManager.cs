using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
#nullable disable
namespace ZenlessPolyCalc.Config
{
    public class ConfigManager
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
        private const string WishlistItemsSectionName = "WishlistItems";
        public List<WishlistItem> WishlistItems = new List<WishlistItem>();

        public void SaveConfig()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            AppSettingsSection app = config.AppSettings;

            KeyValueConfigurationElement kvpCurrentPolychromes = app.Settings["CurrentPolychromes"];
            KeyValueConfigurationElement kvpCurrentTapes = app.Settings["CurrentTapes"];
            KeyValueConfigurationElement kvpRemainingEventPolychromes = app.Settings["RemainingEventPolychromes"];
            KeyValueConfigurationElement kvpAssumeShiyuARank = app.Settings["AssumeShiyuARank"];
            KeyValueConfigurationElement kvpPatchEndDate= app.Settings["PatchEndDate"];




            ConfigurationSection WishlistSection = config.GetSection("WishlistItems");
           // var items = WishlistSection["items"];



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
            WishlistItems = LoadWishlistItems();
        }

        public void AddWishlistItem(WishlistItem wishlistItem)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var section = config.GetSection(WishlistItemsSectionName) as WishlistSection;
            if (section == null)
            {
                section = new WishlistSection();
                config.Sections.Add(WishlistItemsSectionName, section);
            }
            if (string.IsNullOrWhiteSpace(wishlistItem.ID))
            {
                wishlistItem.ID = Guid.NewGuid().ToString();
            }
            WishlistItemElement existingItem = section.Items.Cast<WishlistItemElement>().Where(x => x.ID == wishlistItem.ID).FirstOrDefault();
            bool addNew = false;
            if (existingItem == null)
            {
                existingItem = new WishlistItemElement();
                existingItem.ID = wishlistItem.ID;
                addNew = true;
            }
            existingItem.CharacterName = wishlistItem.CharacterName;
            existingItem.NormalBanner = wishlistItem.NormalBanner;
            existingItem.IsWeapon = wishlistItem.IsWeapon;
            existingItem.DiscountBanner = wishlistItem.DiscountBanner;
            existingItem.ImageUrl = wishlistItem.ImageLocation;
            if (addNew)
            {
                section.Items.Add(existingItem);
            }
            section.SectionInformation.ForceSave = true;
            config.Save(ConfigurationSaveMode.Modified);

            // Make subsequent GetSection calls see the new values
            ConfigurationManager.RefreshSection(WishlistItemsSectionName);
            //update the in memory list!
            WishlistItems = LoadWishlistItems();
        }

        public void SaveWishlistItems(List<WishlistItem> wishListItems)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var section = config.GetSection(WishlistItemsSectionName) as WishlistSection;
            if (section == null)
            {
                section = new WishlistSection();
                config.Sections.Add(WishlistItemsSectionName, section);
            }

            section.Items.ClearItems();

            foreach (var item in wishListItems)
            {
                section.Items.Add(new WishlistItemElement
                {
                    ID = item.ID,
                    CharacterName = item.CharacterName,
                    NormalBanner = item.NormalBanner,
                    IsWeapon = item.IsWeapon,
                    DiscountBanner = item.DiscountBanner,
                    ImageUrl = item.ImageLocation
                });
            }

            section.SectionInformation.ForceSave = true;
            config.Save(ConfigurationSaveMode.Modified);

            // Make subsequent GetSection calls see the new values
            ConfigurationManager.RefreshSection(WishlistItemsSectionName);
        }
        public static List<WishlistItem> LoadWishlistItems()
        {
            var section = ConfigurationManager.GetSection(WishlistItemsSectionName) as WishlistSection;
            if (section == null)
                return new List<WishlistItem>();

            return section.Items
                .Cast<WishlistItemElement>()
                .Select(e => new WishlistItem
                {
                    ID = e.ID,
                    CharacterName = e.CharacterName,
                    NormalBanner = e.NormalBanner,
                    IsWeapon = e.IsWeapon,
                    DiscountBanner = e.DiscountBanner,
                    ImageLocation = e.ImageUrl
                })
                .ToList();
        }
    }
}
