namespace Game.Level;

public class LevelAvatarRestAreaEventListener : MonoBehaviour
{
	[SerializeField]
	private UnityEvent _onAvatarEndDrop; //Field offset: 0x20
	[SerializeField]
	private UnityEvent _onAvatarPickUp; //Field offset: 0x28
	private LevelAvatarRestAreaBase _avatarRestArea; //Field offset: 0x30

	public LevelAvatarRestAreaEventListener() { }

	private void Awake() { }

	private void OnAvatarEndDrop(LevelAvatarRestAreaBase restArea, ILevelAvatar avatar) { }

	private void OnAvatarPickUp(LevelAvatarRestAreaBase restArea, ILevelAvatar avatar) { }

	private void OnDestroy() { }

}

