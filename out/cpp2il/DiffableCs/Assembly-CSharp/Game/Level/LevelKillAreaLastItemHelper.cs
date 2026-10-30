namespace Game.Level;

public class LevelKillAreaLastItemHelper : MonoBehaviour
{
	[SerializeField]
	private string _label; //Field offset: 0x20
	private LevelKillArea _levelKillArea; //Field offset: 0x28
	public UnityEvent onMatchingItemKilledEvent; //Field offset: 0x30

	public LevelKillAreaLastItemHelper() { }

	private void Awake() { }

	private bool IsKilledItemMatchingLabelHandler() { }

	private void OnDestroy() { }

	private void OnKillItem() { }

}

