namespace PWC.Level.Maker;

public class LevelMakerToggleEditModeButton : ButtonBase
{
	[SerializeField]
	private Image _image; //Field offset: 0x20
	[SerializeField]
	private Sprite _offSprite; //Field offset: 0x28
	[SerializeField]
	private Sprite _onSprite; //Field offset: 0x30
	private int _tweenId; //Field offset: 0x38

	public LevelMakerToggleEditModeButton() { }

	protected virtual void Awake() { }

	protected virtual void OnClick() { }

	private void OnDestroy() { }

	private void OnMakerModeChanged(bool isMakerMode) { }

}

