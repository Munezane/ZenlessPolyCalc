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
        public bool IsWeapon { get; set; } = false;
        public string ImageLocation { get; set; } = "";
        public bool NormalBanner { get; set; } = true;
        public bool DiscountBanner { get; set; } = false;
    }
}
