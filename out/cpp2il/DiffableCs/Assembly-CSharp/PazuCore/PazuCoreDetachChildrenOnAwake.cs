namespace PazuCore;

public class PazuCoreDetachChildrenOnAwake : MonoBehaviour
{
	[SerializeField]
	private bool _destroyAfterDetach; //Field offset: 0x20
	[SerializeField]
	private bool _setParentToOwnParent; //Field offset: 0x21

	public PazuCoreDetachChildrenOnAwake() { }

	private void Awake() { }

}

