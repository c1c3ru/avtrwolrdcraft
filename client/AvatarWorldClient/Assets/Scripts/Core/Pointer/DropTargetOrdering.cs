using System;
using System.Collections.Generic;

namespace AvatarWorld.Core.Pointer
{
    /// <summary>Dados de um alvo de soltura que o comparador do original consulta (ILevelConsumer).</summary>
    public struct DropCandidate
    {
        /// <summary>GetEntity() != null (slot 0 da interface).</summary>
        public bool HasEntity;
        /// <summary>GetSortPriority() (slot 2).</summary>
        public int SortPriority;
        /// <summary>GetSortingElement() nao e nulo (slot 4, checagem de UnityEngine.Object).</summary>
        public bool HasSortingElement;
        /// <summary>SortingElement.GetSortingOrderForY(), valido quando HasSortingElement.</summary>
        public long SortingOrderForY;
    }

    /// <summary>
    /// Prioridade entre alvos de soltura sobrepostos, como o original
    /// (docs/loops/results/L02.md; tools/recon_drop_priority.py).
    /// - LevelDropArea.SortDropAreas (0x227f574) ordena a lista estatica com LevelConsumers.CompareConsumers (0x22c3fd4).
    /// - LevelItem.GetMostRelevantDropAreaUnderPosition devolve a primeira area da lista ja ordenada que passa em
    ///   IsDroppableUnderItem: a prioridade e so a ordem da lista.
    /// Ordem (maior primeiro, rhs.CompareTo(lhs)): 1) sem entidade em ambos -> prioridade; 2) com entidade antes de sem;
    /// 3) ambos com entidade: com SortingElement antes de sem; 4) ambos com: maior SortingOrderForY primeiro, empate -> prioridade.
    /// Nao provado: o desempate final de List.Sort (instavel no original; empates totais ficam em ordem nao definida).
    /// </summary>
    public static class DropTargetOrdering
    {
        public static int Compare(DropCandidate lhs, DropCandidate rhs)
        {
            if (!lhs.HasEntity && !rhs.HasEntity) return rhs.SortPriority.CompareTo(lhs.SortPriority);
            if (lhs.HasEntity && !rhs.HasEntity) return -1;
            if (!lhs.HasEntity && rhs.HasEntity) return 1;

            if (!lhs.HasSortingElement && !rhs.HasSortingElement) return rhs.SortPriority.CompareTo(lhs.SortPriority);
            if (lhs.HasSortingElement && !rhs.HasSortingElement) return -1;
            if (!lhs.HasSortingElement && rhs.HasSortingElement) return 1;

            if (lhs.SortingOrderForY == rhs.SortingOrderForY) return rhs.SortPriority.CompareTo(lhs.SortPriority);
            return rhs.SortingOrderForY.CompareTo(lhs.SortingOrderForY);
        }

        /// <summary>Ordena como SortDropAreas e devolve o primeiro elegivel (GetMostRelevantDropAreaUnderPosition).</summary>
        public static bool TryPickMostRelevant<T>(IList<T> candidates, Func<T, DropCandidate> describe,
                                                  Func<T, bool> isDroppable, out T picked)
        {
            var ordered = new List<T>(candidates);
            ordered.Sort((a, b) => Compare(describe(a), describe(b)));
            foreach (var candidate in ordered)
            {
                if (isDroppable(candidate)) { picked = candidate; return true; }
            }
            picked = default(T);
            return false;
        }
    }
}
