namespace Game.Level;

public class LevelSecretAvatarInWorldPositionListener : MonoBehaviour
{
	[SerializeField]
	private List<Int32> _avatarIDs; //Field offset: 0x20
	[SerializeField]
	private Vector2 _xRangeInScene; //Field offset: 0x28
	[SerializeField]
	private UnityEvent _onConditionMetEvent; //Field offset: 0x30
	[SerializeField]
	private UnityEvent _onConditionNotMetEvent; //Field offset: 0x38
	private List<Int32> _currentAvatarsInRange; //Field offset: 0x40

	public LevelSecretAvatarInWorldPositionListener() { }

	private void Awake() { }

	private bool IsInRange(LevelItem levelItem) { }

	private void OnDestroy() { }

	private void OnItemBeginDrag(LevelItem levelItem) { }

	private void OnItemEndDrag(LevelItem levelItem) { }

	private void OnItemEndLand(LevelItem levelItem, LevelDropArea dropArea) { }

	private void OnPostInit() { }

	private void SingleAvatarCheck(ILevelAvatar levelAvatar) { }

}

