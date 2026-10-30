namespace PWC.Level;

public class LevelDropAreaSoundOnItemEndDropHandler : MonoBehaviour
{
	[SerializeField]
	protected string _soundName; //Field offset: 0x20
	[Range(0, 1)]
	[SerializeField]
	protected float _volume; //Field offset: 0x28
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x30
	[SerializeField]
	private bool _isLoop; //Field offset: 0x38
	private LevelDropArea _dropArea; //Field offset: 0x40
	private LevelAvatarRestAreaBase _restArea; //Field offset: 0x48

	public LevelDropAreaSoundOnItemEndDropHandler() { }

	private void Awake() { }

	private void OnAvatarEndDrop(LevelAvatarRestAreaBase _, ILevelAvatar avatar) { }

	private void OnAvatarPickUp(LevelAvatarRestAreaBase _, ILevelAvatar avatar) { }

	private void OnDestroy() { }

	private void OnItemEndDrop(LevelItem _) { }

	private void OnItemPickUp(LevelItem _) { }

}

