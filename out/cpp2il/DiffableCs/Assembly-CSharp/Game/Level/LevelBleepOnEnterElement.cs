namespace Game.Level;

public class LevelBleepOnEnterElement : LevelConsumerAreaBase, ILevelDragActionTagTarget, ILevelConsumer
{
	[SerializeField]
	private float _beepDuration; //Field offset: 0x54
	[SerializeField]
	private string _soundName; //Field offset: 0x58
	[SerializeField]
	private SpriteRenderer _spriteRenderer; //Field offset: 0x60
	[SerializeField]
	private Sprite _onSprite; //Field offset: 0x68
	[SerializeField]
	private Sprite _offSprite; //Field offset: 0x70
	private int _tweenID; //Field offset: 0x78
	[CompilerGenerated]
	private Action<LevelDragActionByTagItemHandler> OnBleepAction; //Field offset: 0x80

	public event Action<LevelDragActionByTagItemHandler> OnBleepAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public LevelBleepOnEnterElement() { }

	[CompilerGenerated]
	private void <OnEnter>b__9_0() { }

	[CompilerGenerated]
	public void add_OnBleepAction(Action<LevelDragActionByTagItemHandler> value) { }

	public override void OnEnter(LevelDragActionByTagItemHandler handler) { }

	public override void OnExit(LevelDragActionByTagItemHandler handler) { }

	[CompilerGenerated]
	public void remove_OnBleepAction(Action<LevelDragActionByTagItemHandler> value) { }

}

