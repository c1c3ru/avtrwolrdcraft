namespace Game.Level;

public class LevelItemKilledEventHandler : MonoBehaviour
{
	[SerializeField]
	private LevelItem _levelItem; //Field offset: 0x20
	[SerializeField]
	private UnityEvent _onItemKilled; //Field offset: 0x28

	public LevelItemKilledEventHandler() { }

	private void Awake() { }

	private void HandleKilled() { }

	private void OnDestroy() { }

}

