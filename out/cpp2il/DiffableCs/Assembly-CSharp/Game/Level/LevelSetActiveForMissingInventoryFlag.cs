namespace Game.Level;

public class LevelSetActiveForMissingInventoryFlag : MonoBehaviour
{
	[SerializeField]
	private GameObject _gameObject; //Field offset: 0x20
	[SerializeField]
	private List<InventoryFlagType> _missingFlagTypes; //Field offset: 0x28
	[SerializeField]
	private bool _setActiveOnMissingFlagsClaim; //Field offset: 0x30

	public LevelSetActiveForMissingInventoryFlag() { }

	private void Awake() { }

	private void OnBeforeSetBoundsCall() { }

	private void OnDestroy() { }

}

