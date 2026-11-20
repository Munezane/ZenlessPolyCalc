using System;
using System.Collections.Generic;
using System.Text;
#nullable disable
namespace ZenlessPolyCalc
{
    public class WishlistItem
    {
        public string ID { get; set; } //needed for config stuff 
        public string CharacterName { get; set; } = "";
        public bool IsWeapon { get; set; } = false; //160 pulls for weapon, 180 for character
        public string ImageLocation { get; set; } = "";
        public bool NormalBanner { get; set; } = true;//180 pulls needed to guarrantee (if you won your last 50/50)
        public bool DiscountBanner { get; set; } = false; //88 pulls to guarrantee first copy of this (or 78 for weapons)
    }
}
