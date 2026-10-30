namespace TMPro;

[RequireComponent(typeof(CanvasRenderer))]
public class TMP_SelectionCaret : MaskableGraphic
{

	public TMP_SelectionCaret() { }

	public virtual void Cull(Rect clipRect, bool validRect) { }

	protected virtual void UpdateGeometry() { }

}

