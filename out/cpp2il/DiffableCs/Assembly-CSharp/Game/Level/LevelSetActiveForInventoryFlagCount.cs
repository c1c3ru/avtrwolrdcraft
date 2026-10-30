namespace Game.Level;

public class LevelSetActiveForInventoryFlagCount : MonoBehaviour
{
	private enum CompareType
	{
		Equal = 0,
		NotEqual = 1,
		Greater = 2,
		GreaterEqual = 3,
		Less = 4,
		LessEqual = 5,
	}

	[SerializeField]
	private GameObject _gameObject; //Field offset: 0x20
	[SerializeField]
	private List<InventoryFlagType> _affectingFlagTypes; //Field offset: 0x28
	[SerializeField]
	private bool _setActiveStateOnCount; //Field offset: 0x30
	[SerializeField]
	private CompareType _compareType; //Field offset: 0x34
	[SerializeField]
	private int _flagsCount; //Field offset: 0x38
	[SerializeField]
	private UnityEvent _onRequirementFullfiled; //Field offset: 0x40

	public LevelSetActiveForInventoryFlagCount() { }

	private void Awake() { }

	private bool IsRequirementFullfiled(int currentCount) { }

	private void OnBeforeSetBoundsCall() { }

	private void OnDestroy() { }

}

