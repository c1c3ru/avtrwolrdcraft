//Type is in global namespace

public class OnGivenToSpecificAvatarItemHandler : MonoBehaviour
{
	[SerializeField]
	private bool _allAvatars; //Field offset: 0x20
	[SerializeField]
	private List<Int32> _avatarIDs; //Field offset: 0x28
	[SerializeField]
	private LevelItem _levelItem; //Field offset: 0x30
	[SerializeField]
	private UnityEvent _onGivenToAvatar; //Field offset: 0x38
	[SerializeField]
	private UnityEvent _onTakenFromAvatar; //Field offset: 0x40
	[ConditionalField("_playAnimation", True, True, (array) null)]
	[SerializeField]
	private string _animationName; //Field offset: 0x48
	[SerializeField]
	private bool _playAnimation; //Field offset: 0x50

	public OnGivenToSpecificAvatarItemHandler() { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnGiveToAvatar(ILevelAvatar avatar, ItemOnAvatarType type) { }

	private void OnTakenFromAvatar(ILevelAvatar avatar) { }

}

