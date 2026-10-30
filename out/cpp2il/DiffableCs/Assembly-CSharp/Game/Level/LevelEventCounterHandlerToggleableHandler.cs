namespace Game.Level;

public class LevelEventCounterHandlerToggleableHandler : MonoBehaviour
{
	[SerializeField]
	private List<UnityEvent> OnCountIncreased; //Field offset: 0x20
	[SerializeField]
	private List<UnityEvent> OnCountDecreased; //Field offset: 0x28
	private LevelEventCounterHandler _levelEventCounterHandler; //Field offset: 0x30

	public LevelEventCounterHandlerToggleableHandler() { }

	private void Awake() { }

	private void DecreaseCounter() { }

	private void IncreaseCounter() { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

}

