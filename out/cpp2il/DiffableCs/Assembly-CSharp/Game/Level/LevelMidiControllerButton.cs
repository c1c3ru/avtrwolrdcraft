namespace Game.Level;

public class LevelMidiControllerButton : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	[SerializeField]
	private SpriteRenderer _spriteRenderer; //Field offset: 0x20
	[SerializeField]
	private Sprite _onState; //Field offset: 0x28
	[SerializeField]
	private Sprite _offState; //Field offset: 0x30
	[SerializeField]
	private LevelMidiController _controller; //Field offset: 0x38
	[SerializeField]
	private string _clipName; //Field offset: 0x40
	[CompilerGenerated]
	private bool <IsPressed>k__BackingField; //Field offset: 0x48

	public string ClipName
	{
		 get { } //Length: 8
	}

	public private bool IsPressed
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 12
	}

	public LevelMidiControllerButton() { }

	public string get_ClipName() { }

	[CompilerGenerated]
	public bool get_IsPressed() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	[CompilerGenerated]
	private void set_IsPressed(bool value) { }

	public void SetState(bool pressed) { }

}

