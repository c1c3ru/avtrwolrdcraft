namespace PWC.Game;

public class LevelPianoKey : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	private const float KEY_PUSH_DURATION = 0,3; //Field offset: 0x0
	[SerializeField]
	private LevelDropArea _dropArea; //Field offset: 0x20
	[SerializeField]
	private SpriteRenderer _renderer; //Field offset: 0x28
	[SerializeField]
	private Sprite _onSprite; //Field offset: 0x30
	[SerializeField]
	private Sprite _offSprite; //Field offset: 0x38
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x40
	[SerializeField]
	private string _noteSoundName; //Field offset: 0x48
	[CompilerGenerated]
	private Action<Int32> OnKeyClickedAction; //Field offset: 0x50
	private int _keyIndex; //Field offset: 0x58
	private int _pressKeyTweenId; //Field offset: 0x5C
	private bool _isOn; //Field offset: 0x60

	public event Action<Int32> OnKeyClickedAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public int KeyIndex
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public LevelPianoKey() { }

	[CompilerGenerated]
	public void add_OnKeyClickedAction(Action<Int32> value) { }

	private void Awake() { }

	public int get_KeyIndex() { }

	private void OnDestroy() { }

	private void OnItemnDrop(LevelItem item) { }

	private void OnItemPickUp(LevelItem item) { }

	public override void OnPointerClick(PointerEventData eventData) { }

	[CompilerGenerated]
	public void remove_OnKeyClickedAction(Action<Int32> value) { }

	public void set_KeyIndex(int value) { }

	public void TurnOffKey() { }

	public void TurnOnForDuration() { }

	private void TurnOnKey() { }

}

