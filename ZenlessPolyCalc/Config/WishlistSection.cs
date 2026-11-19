using System.Configuration;

namespace ZenlessPolyCalc.Config
{
    // The <wishlist> section
    public sealed class WishlistSection : ConfigurationSection
    {
        [ConfigurationProperty("items")]
        public WishlistItemCollection Items
            => (WishlistItemCollection)this["items"];
    }
}
