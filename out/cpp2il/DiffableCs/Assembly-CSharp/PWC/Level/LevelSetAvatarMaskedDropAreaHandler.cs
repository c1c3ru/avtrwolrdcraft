namespace PWC.Level;

public class LevelSetAvatarMaskedDropAreaHandler : MonoBehaviour
{
	[SerializeField]
	private bool _isVisibleInsideMask; //Field offset: 0x20
	private LevelDropArea _dropArea; //Field offset: 0x28

	public LevelSetAvatarMaskedDropAreaHandler() { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnItemBeginDrop(LevelItem levelItem) { }

	private void OnItemDropInterrupt(LevelItem levelItem) { }

	private void OnItemPickUp(LevelItem levelItem) { }

	private void OnLevelPostInit() { }

	public void SetCharacterMasked(ILevelAvatar avatar, bool value) { }

}

