namespace PazuCore;

public class NonDrawingMaskableGraphic : MaskableGraphic
{

	public NonDrawingMaskableGraphic() { }

	protected virtual void OnPopulateMesh(VertexHelper vh) { }

	public virtual void SetMaterialDirty() { }

	public virtual void SetVerticesDirty() { }

}

