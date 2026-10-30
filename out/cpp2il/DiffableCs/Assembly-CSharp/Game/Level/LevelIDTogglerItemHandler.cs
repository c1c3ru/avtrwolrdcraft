namespace Game.Level;

public class LevelIDTogglerItemHandler : MonoBehaviour
{
	[SerializeField]
	private int _newCharacterID; //Field offset: 0x20
	[SerializeField]
	private int _previousID; //Field offset: 0x24
	[SerializeField]
	private LevelItem _levelItem; //Field offset: 0x28
	[SerializeField]
	private string _firstToggleAnimationName; //Field offset: 0x30
	[SerializeField]
	private string _secondToggleAnimationName; //Field offset: 0x38
	[SerializeField]
	private UnityEvent _onPlacedOnCharacterEvent; //Field offset: 0x40

	public LevelIDTogglerItemHandler() { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnPlacedOnCharacter(ILevelAvatar avatar, ItemOnAvatarType itemOnCharacter) { }

	private void OnRemovedFromCharacter(ILevelAvatar avatar) { }

}

