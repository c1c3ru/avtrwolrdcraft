using AvatarWorld.Core.Avatar;
using UnityEngine;

namespace AvatarWorld.Runtime
{
    /// <summary>Carrega Resources/ContextualAnimations/ca-catalog.json (gerado por tools/export_ca_catalog.py) uma unica vez.</summary>
    public static class CACatalogLoader
    {
        const string ResourcePath = "ContextualAnimations/ca-catalog";
        static CACatalog _cached;

        public static CACatalog Load()
        {
            if (_cached != null) return _cached;
            var text = Resources.Load<TextAsset>(ResourcePath);
            if (text == null)
            {
                Debug.LogError("CACatalogLoader: " + ResourcePath + " nao encontrado");
                return null;
            }
            _cached = new CACatalog(JsonUtility.FromJson<CACatalogData>(text.text));
            return _cached;
        }

        /// <summary>Para testes: descarta o cache.</summary>
        public static void Reset() { _cached = null; }
    }
}
