using System;

namespace AvatarWorld.Runtime
{
    /// <summary>Formato de Resources/Store/items.json (tools/build_item_catalog.py): g = guid, n = nome, c = categoria.</summary>
    [Serializable]
    public sealed class ItemCatalogFile
    {
        public Entry[] items;

        [Serializable]
        public sealed class Entry { public string g, n, c; }
    }
}
