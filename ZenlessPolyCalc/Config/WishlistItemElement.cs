using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace ZenlessPolyCalc.Config
{
    public sealed class WishlistItemElement : ConfigurationElement
    {
        //public string CharacterName { get; set; } = "";
        //public bool IsWeapon { get; set; } = false;
        //public string ImageUrl { get; set; } = "";
        //public bool IsCustomImageUrl { get; set; } = false;
        //public bool NormalBanner { get; set; } = true;
        //public bool DiscountBanner { get; set; } = false;
        [ConfigurationProperty("ID", IsKey = true, IsRequired = true)]
        public string ID
        {
            get => (string)this["ID"];
            set => this["ID"] = value;
        }
        [ConfigurationProperty("CharacterName", IsKey = false, IsRequired = false, DefaultValue = "")]
        public string CharacterName
        {
            get => (string)this["CharacterName"];
            set => this["CharacterName"] = value;
        }

        [ConfigurationProperty("IsWeapon", IsRequired = false, DefaultValue = false)]
        public bool IsWeapon
        {
            get => (bool)this["IsWeapon"];
            set => this["IsWeapon"] = value;
        }

        [ConfigurationProperty("ImageUrl", IsRequired = false, DefaultValue = "")]
        public string ImageUrl
        {
            get => (string)this["ImageUrl"];
            set => this["ImageUrl"] = value;
        }

        [ConfigurationProperty("NormalBanner", IsRequired = false, DefaultValue = false)]
        public bool NormalBanner
        {
            get => (bool)this["NormalBanner"];
            set => this["NormalBanner"] = value;
        }
        [ConfigurationProperty("DiscountBanner", IsRequired = false, DefaultValue = false)]
        public bool DiscountBanner
        {
            get => (bool)this["DiscountBanner"];
            set => this["DiscountBanner"] = value;
        }
    }
}
