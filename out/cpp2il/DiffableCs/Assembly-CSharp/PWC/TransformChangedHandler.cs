namespace PWC;

public class TransformChangedHandler : MonoBehaviour
{
	public Action OnTransformChangedAction; //Field offset: 0x20

	public TransformChangedHandler() { }

	public void Check() { }

	public static TransformChangedHandler Ensure(GameObject gameObject) { }

}

