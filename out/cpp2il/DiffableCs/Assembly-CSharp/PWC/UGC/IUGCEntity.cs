namespace PWC.UGC;

public interface IUGCEntity
{
	public static Action<IUGCEntity> OnUGCEntitySelectedAction; //Field offset: 0x0
	public static Action<IUGCEntity> OnUGCEntityDeselectedAction; //Field offset: 0x8

	public MonoBehaviour GetMonoBehaviour() { }

	public Transform GetTransform() { }

	public Vector2 GetWorldPosition() { }

	public Vector2 GetZoomInPosition() { }

	public void OnDeselected() { }

	public void OnSelected() { }

}

