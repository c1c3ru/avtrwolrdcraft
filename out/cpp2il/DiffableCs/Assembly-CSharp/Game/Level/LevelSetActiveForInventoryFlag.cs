namespace Game.Level;

[RequireComponent(typeof(LevelSetActiveForMissingInventoryFlag))]
public class LevelSetActiveForInventoryFlag : MonoBehaviour
{
	[SerializeField]
	private GameObject _gameObject; //Field offset: 0x20
	[SerializeField]
	private List<InventoryFlagType> _requiredFlagTypes; //Field offset: 0x28
	[SerializeField]
	private bool _setActiveOnFlagClaim; //Field offset: 0x30

	public LevelSetActiveForInventoryFlag() { }

	private void Awake() { }

	private void OnBeforeSetBoundsCall() { }

	private void OnDestroy() { }

}

