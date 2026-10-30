namespace PWC.Level;

public class LevelInventoryFlagRequiredObject : MonoBehaviour
{
	[SerializeField]
	private InventoryFlagType _inventoryFlagsType; //Field offset: 0x20

	public LevelInventoryFlagRequiredObject() { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnLevelPrePostInit() { }

}

