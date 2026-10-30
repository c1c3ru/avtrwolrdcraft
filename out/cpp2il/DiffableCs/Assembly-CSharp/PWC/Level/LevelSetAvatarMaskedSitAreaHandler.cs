namespace PWC.Level;

public class LevelSetAvatarMaskedSitAreaHandler : MonoBehaviour
{
	[SerializeField]
	private bool _isVisibleInsideMask; //Field offset: 0x20
	private LevelSitArea _sitArea; //Field offset: 0x28

	public LevelSetAvatarMaskedSitAreaHandler() { }

	private void Awake() { }

	private void OnAvatarEndDrop(LevelAvatarRestAreaBase area, ILevelAvatar avatar) { }

	private void OnAvatarPickUp(LevelAvatarRestAreaBase area, ILevelAvatar avatar) { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	public void SetAvatarMasked(ILevelAvatar avatar, bool value) { }

}

