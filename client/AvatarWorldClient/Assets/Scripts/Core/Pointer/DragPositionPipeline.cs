using System;

namespace AvatarWorld.Core.Pointer
{
    public struct DragPoint
    {
        public float X, Y;
        public DragPoint(float x, float y) { X = x; Y = y; }
    }

    /// <summary>
    /// Ordem por quadro da corrotina de arraste, extraida de &lt;SyncPosition&gt;d__75.MoveNext (0x206c7d0):
    /// GetDragPositionForThisFramePreModifications (slot 25) -> GetDragPositionForThisFramePostModifications (slot 26)
    /// -> OnSyncPosition (slot 27), que recebe a posicao ja modificada (docs/RECON_INPUT_CONTRACT.md).
    /// Fora do contrato (nao provado): o que cada Pre/Post faz em cada item, o uso de OverrideSyncPositionAction e o primeiro
    /// uso do slot 27 em 0x206c85c.
    /// </summary>
    public static class DragPositionPipeline
    {
        /// <summary>Posicao final do quadro: Post(Pre(raw)). Etapa nula = identidade.</summary>
        public static DragPoint Compute(DragPoint raw, Func<DragPoint, DragPoint> pre, Func<DragPoint, DragPoint> post)
        {
            var p = pre != null ? pre(raw) : raw;
            return post != null ? post(p) : p;
        }

        /// <summary>Um quadro: calcula a posicao e entrega a OnSyncPosition. Retorna a posicao entregue.</summary>
        public static DragPoint RunFrame(DragPoint raw, Func<DragPoint, DragPoint> pre, Func<DragPoint, DragPoint> post, Action<DragPoint> onSyncPosition)
        {
            var result = Compute(raw, pre, post);
            if (onSyncPosition != null) onSyncPosition(result);
            return result;
        }
    }
}
