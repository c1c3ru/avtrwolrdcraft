using System;
using System.Collections.Generic;

namespace AvatarWorld.Core.Spine
{
    /// <summary>Entrada do indice de esqueletos (tools/import_spine_original.py). Campos publicos para JsonUtility.</summary>
    [Serializable]
    public class SpineEntry
    {
        public string name;            // nome do esqueleto (sem o sufixo _SkeletonData); variantes repetidas: Nome__arquivo_pathid
        public string folder;          // pasta em Resources/Spine
        public bool renderable;        // tem atlas e texturas; falso = esqueleto so de logica (ossos/animacoes)
        public float scale;            // SkeletonDataAsset.scale do original
        public float defaultMix;       // SkeletonDataAsset.defaultMix do original
        public int pages;              // paginas de atlas exportadas
        public int sceneInstances;     // SkeletonAnimation/SkeletonGraphic que usam este asset nas cenas
        public int animations;         // contagem de animacoes pelo parse independente (tools/skel_dump); -1 = nao casado
        public int bones;              // idem para ossos
        public string sourceFile;      // arquivo serializado de origem no pacote do original
        public string[] notes;
    }

    [Serializable]
    public class SpineIndexData
    {
        public SpineEntry[] skeletons;
    }

    /// <summary>Consulta ao indice de esqueletos por nome.</summary>
    public sealed class SpineIndex
    {
        readonly Dictionary<string, SpineEntry> _byName = new Dictionary<string, SpineEntry>(StringComparer.OrdinalIgnoreCase);

        public SpineIndex(SpineIndexData data)
        {
            if (data == null || data.skeletons == null) return;
            foreach (var e in data.skeletons)
                if (e != null && !string.IsNullOrEmpty(e.name) && !_byName.ContainsKey(e.name)) _byName.Add(e.name, e);
        }

        public int Count { get { return _byName.Count; } }
        public IEnumerable<SpineEntry> All { get { return _byName.Values; } }

        public bool TryGet(string name, out SpineEntry entry)
        {
            entry = null;
            return !string.IsNullOrEmpty(name) && _byName.TryGetValue(name, out entry);
        }
    }
}
