namespace PWC.AvatarSpeech;

public class AvatarSpeechUITextItem : GameUIElement
{
	[SerializeField]
	private Text _textComponent; //Field offset: 0x28
	private AvatarSpeechUIMenu _menu; //Field offset: 0x30
	private Item _config; //Field offset: 0x38

	public AvatarSpeechUITextItem() { }

	private void Awake() { }

	public void Init(AvatarSpeechUIMenu menu, Item config, float scrollRectWidth) { }

	private void OnClick() { }

}

