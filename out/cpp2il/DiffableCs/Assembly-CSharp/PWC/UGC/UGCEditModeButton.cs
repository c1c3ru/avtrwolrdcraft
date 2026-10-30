namespace PWC.UGC;

public class UGCEditModeButton : ButtonBase
{
	[SerializeField]
	private Sprite _onSprite; //Field offset: 0x20
	[SerializeField]
	private Sprite _offSprite; //Field offset: 0x28
	[SerializeField]
	private Image _image; //Field offset: 0x30

	public UGCEditModeButton() { }

	protected virtual void Awake() { }

	private void ChangeButtonState(bool isTrue) { }

	protected virtual void OnClick() { }

	private void OnDestroy() { }

	private void OnUGCEditModeChange(bool isTrue) { }

}

