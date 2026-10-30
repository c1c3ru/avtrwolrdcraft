namespace Game;

public class ActiveOnInventoryFlag : MonoBehaviour
{
	[SerializeField]
	private GameObject _gameObject; //Field offset: 0x20
	[SerializeField]
	private InventoryFlagType _inventoryFlagType; //Field offset: 0x28

	public ActiveOnInventoryFlag() { }

	private void Awake() { }

	private void Sync() { }

}

