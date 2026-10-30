//Type is in global namespace

[AddComponentMenu("Event/Physics 2D Raycaster All Renderers")]
[RequireComponent(typeof(Camera))]
public class Physics2DRaycasterAllRenderers : PhysicsRaycaster
{
	private RaycastHit2D[] m_Hits; //Field offset: 0x48

	protected Physics2DRaycasterAllRenderers() { }

	public virtual void Raycast(PointerEventData eventData, List<RaycastResult> resultAppendList) { }

}

