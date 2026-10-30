namespace Game.Level;

public class LevelReleaseItemsOnDoorToggleDropAreaHandler : MonoBehaviour
{
	[SerializeField]
	private LevelDoor _door; //Field offset: 0x20
	[SerializeField]
	private LevelDropArea _dropArea; //Field offset: 0x28
	[SerializeField]
	private LevelAvatarRestAreaBase _characterDropArea; //Field offset: 0x30
	[SerializeField]
	private bool _releaseOnOpen; //Field offset: 0x38
	[SerializeField]
	private bool _releaseOnClose; //Field offset: 0x39
	[SerializeField]
	private LevelAvatarRestAreaBase[] _restAreas; //Field offset: 0x40

	public LevelReleaseItemsOnDoorToggleDropAreaHandler() { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnDoorChangeState(bool isOpen) { }

}

