namespace Game.Level.Arcade.RhythmGame;

public class LevelTapButtonRhythmGame : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	[CompilerGenerated]
	private static Action OnButtonTap; //Field offset: 0x0
	[CompilerGenerated]
	private static Action OnButtonTapFail; //Field offset: 0x8
	[SerializeField]
	private LevelLineRhythmGame _line; //Field offset: 0x20
	[SerializeField]
	private SpriteRenderer _spriteRenderer; //Field offset: 0x28
	private int _tweenID; //Field offset: 0x30

	public static event Action OnButtonTap
	{
		[CompilerGenerated]
		 add { } //Length: 184
		[CompilerGenerated]
		 remove { } //Length: 184
	}

	public static event Action OnButtonTapFail
	{
		[CompilerGenerated]
		 add { } //Length: 188
		[CompilerGenerated]
		 remove { } //Length: 188
	}

	public LevelTapButtonRhythmGame() { }

	[CompilerGenerated]
	private void <OnPointerClick>b__9_0() { }

	[CompilerGenerated]
	public static void add_OnButtonTap(Action value) { }

	[CompilerGenerated]
	public static void add_OnButtonTapFail(Action value) { }

	public override void OnPointerClick(PointerEventData eventData) { }

	[CompilerGenerated]
	public static void remove_OnButtonTap(Action value) { }

	[CompilerGenerated]
	public static void remove_OnButtonTapFail(Action value) { }

}

