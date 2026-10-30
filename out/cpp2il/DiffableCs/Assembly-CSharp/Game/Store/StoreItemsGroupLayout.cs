namespace Game.Store;

public class StoreItemsGroupLayout : MonoBehaviour
{
	[SerializeField]
	private Transform[] _parents; //Field offset: 0x20

	public StoreItemsGroupLayout() { }

	public void PlaceChildren(List<Transform> children) { }

}

