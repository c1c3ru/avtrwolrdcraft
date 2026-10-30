namespace Spine.Unity;

[RequireComponent(typeof(CanvasRenderer))]
public class SkeletonSubmeshGraphic : MaskableGraphic
{

	public SkeletonSubmeshGraphic() { }

	protected virtual void OnDisable() { }

	protected virtual void OnEnable() { }

	protected virtual void OnPopulateMesh(VertexHelper vh) { }

	public virtual void SetMaterialDirty() { }

	public virtual void SetVerticesDirty() { }

}

