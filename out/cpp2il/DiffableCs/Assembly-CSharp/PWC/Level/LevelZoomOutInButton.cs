namespace PWC.Level;

public class LevelZoomOutInButton : ButtonBase
{
	[SerializeField]
	private Image _image; //Field offset: 0x20
	[SerializeField]
	private Sprite _zoomInButtonSprite; //Field offset: 0x28
	[SerializeField]
	private Sprite _zoomOutButtonSprite; //Field offset: 0x30

	public LevelZoomOutInButton() { }

	protected virtual void Awake() { }

	protected virtual void OnClick() { }

	private void OnDestroy() { }

	private void OnLevelPostInitAction() { }

	private void OnSplitLevelModeChange(bool isSplitLevelOn) { }

	private void SyncButtonSprite(bool isZoomNotDefault) { }

}

