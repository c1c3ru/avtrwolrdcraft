//Type is in global namespace

public class LevelDefaultDropAreaOnCharacterReleaseItemsSitAreaHandler : MonoBehaviour
{
	private LevelSitArea _sitArea; //Field offset: 0x20
	[SerializeField]
	private LevelDropArea _defaultDropArea; //Field offset: 0x28

	public LevelDefaultDropAreaOnCharacterReleaseItemsSitAreaHandler() { }

	private void Awake() { }

	private void OnAvatarBeginDrop(LevelAvatarRestAreaBase area, ILevelAvatar avatar) { }

	private void OnDestroy() { }

	private bool OverrideOnDrop(LevelItem levelItem, PointerEventData pointerEventData) { }

}

