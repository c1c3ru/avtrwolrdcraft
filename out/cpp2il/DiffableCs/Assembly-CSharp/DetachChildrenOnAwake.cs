//Type is in global namespace

public class DetachChildrenOnAwake : MonoBehaviour
{
	[SerializeField]
	private bool _destroyAfterDetach; //Field offset: 0x20
	[SerializeField]
	private bool _setParentToOwnParent; //Field offset: 0x21

	public DetachChildrenOnAwake() { }

	private void Awake() { }

}

