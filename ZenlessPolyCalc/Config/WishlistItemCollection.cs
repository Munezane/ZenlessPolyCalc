using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace ZenlessPolyCalc.Config
{
    // The <items> collection
    public sealed class WishlistItemCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
            => new WishlistItemElement();

        protected override object GetElementKey(ConfigurationElement element)
            => ((WishlistItemElement)element).ID; // must be unique

        protected override string ElementName => "WishListItem";

        public override ConfigurationElementCollectionType CollectionType
            => ConfigurationElementCollectionType.AddRemoveClearMap;

        public WishlistItemElement this[int index]
            => (WishlistItemElement)BaseGet(index);

        public void Add(WishlistItemElement item) => BaseAdd(item);
        public void ClearItems() => BaseClear();
    }
}
