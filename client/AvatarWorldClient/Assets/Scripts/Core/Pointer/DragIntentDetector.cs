namespace AvatarWorld.Core.Pointer
{
    public enum DragPhase { Idle = 0, Pressed = 1, Dragging = 2 }

    /// <summary>Resultado de soltar o ponteiro.</summary>
    public enum PointerReleaseResult { None = 0, Click = 1, EndDrag = 2 }

    /// <summary>
    /// Decide arraste contra clique como o original (docs/RECON_INPUT_CONTRACT.md).
    /// - Limiar: MPPointerInputModule.ShouldStartDrag (0x20cb0ec): sem useDragThreshold inicia sempre; com ele,
    ///   (dx^2 + dy^2) >= threshold^2. O EventSystem das 249 cenas serializa m_DragThreshold = 10 (pixels de tela).
    /// - Clique: DragDropItemBase.OnPointerClick (0x206c244) nao age se o ponteiro ja virou arraste (eventData+0x145,
    ///   inferido como PointerEventData.dragging) nem se o item esta com o flag this+0x39 ligado (significado nao determinado;
    ///   aqui exposto como ClickSuppressed).
    /// Inferido, nao provado: o threshold passado ao ShouldStartDrag e o m_DragThreshold do EventSystem.
    /// </summary>
    public sealed class DragIntentDetector
    {
        public const float DefaultThresholdPixels = 10f;

        readonly float _threshold;
        readonly bool _useDragThreshold;
        float _startX, _startY;

        public DragIntentDetector(float thresholdPixels = DefaultThresholdPixels, bool useDragThreshold = true)
        {
            _threshold = thresholdPixels;
            _useDragThreshold = useDragThreshold;
        }

        public DragPhase Phase { get; private set; }

        /// <summary>Equivale ao flag this+0x39 do item: quando ligado o clique e ignorado.</summary>
        public bool ClickSuppressed { get; set; }

        /// <summary>Posicao do ponteiro quando foi pressionado (this+0x80 no original).</summary>
        public float StartX { get { return _startX; } }
        public float StartY { get { return _startY; } }

        /// <summary>Mesmo teste de ShouldStartDrag.</summary>
        public static bool ShouldStartDrag(bool useDragThreshold, float ax, float ay, float bx, float by, float threshold)
        {
            if (!useDragThreshold) return true;
            float dx = ax - bx, dy = ay - by;
            return dx * dx + dy * dy >= threshold * threshold;
        }

        public void PointerDown(float x, float y)
        {
            _startX = x; _startY = y;
            Phase = DragPhase.Pressed;
        }

        /// <summary>Retorna true no quadro em que o arraste comeca (OnBeginDrag).</summary>
        public bool PointerMove(float x, float y)
        {
            if (Phase != DragPhase.Pressed) return false;
            if (!ShouldStartDrag(_useDragThreshold, x, y, _startX, _startY, _threshold)) return false;
            Phase = DragPhase.Dragging;
            return true;
        }

        public PointerReleaseResult PointerUp()
        {
            var phase = Phase;
            Phase = DragPhase.Idle;
            if (phase == DragPhase.Dragging) return PointerReleaseResult.EndDrag;
            if (phase == DragPhase.Pressed && !ClickSuppressed) return PointerReleaseResult.Click;
            return PointerReleaseResult.None;
        }
    }
}
