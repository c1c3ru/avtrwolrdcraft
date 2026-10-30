namespace PWC;

public class ChangeWorldButton : GameUIElement
{
	[SerializeField]
	private LevelWorldType _worldType; //Field offset: 0x24
	[SerializeField]
	private Image _image; //Field offset: 0x28
	[SerializeField]
	private Sprite _selected; //Field offset: 0x30
	[SerializeField]
	private Sprite _notSelected; //Field offset: 0x38

	public LevelWorldType WorldType
	{
		 get { } //Length: 8
	}

	public ChangeWorldButton() { }

	private void Animate(bool value, bool isImmediate = false) { }

	private void Awake() { }

	public LevelWorldType get_WorldType() { }

	public void OnButtonClick() { }

	private void OnCancelRecording() { }

	private void OnCountdown() { }

	private void OnDestroy() { }

	private void OnStopRecording() { }

	private void Start() { }

}

