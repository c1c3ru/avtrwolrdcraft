using System;
using System.Collections.Generic;

namespace AvatarWorld.Core.Avatar
{
    /// <summary>LevelCAConfig exportado de LevelCAItemHandlerData (tools/export_ca_catalog.py). Campos publicos para JsonUtility.</summary>
    [Serializable]
    public class CAConfigEntry
    {
        public string name;
        public string folderNameOverride;
        public bool isNameFullAnimationName;
        public int repetitions;
        public int trackIndex;
        public string alternateIdleAnimation;
        public string preAnimation;
        public bool keepCurrentAnimation;
        public bool isDisableOtherAnimations;
        public bool ensureRequiredTextures;
    }

    [Serializable]
    public class CAHandlerEntry
    {
        public string name;
        public int spineType;
        public string folderName;
        public string boneName;
        public string lockedAnimation;
        public bool isSingleCA;
        public bool dontApplyForceToSit;
        public CAConfigEntry[] configs;

        /// <summary>Nome da animacao da config, pela regra provada de LevelCAConfig.CreateAnimationName.</summary>
        public string AnimationName(int configIndex)
        {
            var c = configs[configIndex];
            bool prefix = ContextualAnimationRules.HasCAPrefix(spineType) ?? false;
            return ContextualAnimationRules.CreateAnimationName(c.isNameFullAnimationName, c.name, c.folderNameOverride, folderName, prefix);
        }
    }

    [Serializable]
    public class CACatalogData
    {
        public CAHandlerEntry[] handlers;
    }

    /// <summary>Consulta ao catalogo de CA por nome e tipo de esqueleto.</summary>
    public sealed class CACatalog
    {
        readonly Dictionary<string, CAHandlerEntry> _byKey = new Dictionary<string, CAHandlerEntry>(StringComparer.Ordinal);
        readonly List<CAHandlerEntry> _all = new List<CAHandlerEntry>();

        public CACatalog(CACatalogData data)
        {
            if (data == null || data.handlers == null) return;
            foreach (var h in data.handlers)
            {
                if (h == null || h.configs == null) continue;
                _all.Add(h);
                string key = Key(h.name, h.spineType);
                if (!_byKey.ContainsKey(key)) _byKey.Add(key, h);   // nomes repetidos: o primeiro vence (ordenado por tipo e nome)
            }
        }

        static string Key(string name, int spineType) { return spineType + "|" + name; }

        public int HandlerCount { get { return _all.Count; } }

        public int ConfigCount
        {
            get { int n = 0; foreach (var h in _all) n += h.configs.Length; return n; }
        }

        public CAHandlerEntry Find(string handlerName, int spineType)
        {
            CAHandlerEntry h;
            return _byKey.TryGetValue(Key(handlerName, spineType), out h) ? h : null;
        }

        public IEnumerable<CAHandlerEntry> ForSpineType(int spineType)
        {
            foreach (var h in _all) if (h.spineType == spineType) yield return h;
        }
    }
}
