namespace PWC.AvatarSpeech;

public class AvatarSpeechUITextBubble : MonoBehaviour
{
	[SerializeField]
	private RectTransform _background; //Field offset: 0x20
	[SerializeField]
	private Text _text; //Field offset: 0x28
	private int _tweenId; //Field offset: 0x30
	private LevelItem _levelItem; //Field offset: 0x38

	public AvatarSpeechUITextBubble() { }

	[CompilerGenerated]
	private void <Show>b__8_0() { }

	private void EnsureNotFlipped() { }

	public void Init(LevelItem levelItem) { }

	private void OnDestroy() { }

	private void OnSyncIsFlippedState(LevelItem levelItem, bool isFlipped) { }

	public void Show(Item config, float duration) { }

}

