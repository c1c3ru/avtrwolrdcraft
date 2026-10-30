namespace Game.Level.Arcade;

public class LevelArcadeNFC : LevelConsumerAreaBase, ILevelDragActionTagTarget, ILevelConsumer
{
	[SerializeField]
	private GameObject _game; //Field offset: 0x58
	[SerializeField]
	private SpriteRenderer _spriteRenderer; //Field offset: 0x60
	[SerializeField]
	private Sprite _spriteOn; //Field offset: 0x68
	[SerializeField]
	private Sprite _spriteOff; //Field offset: 0x70
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x78
	[SerializeField]
	private string _soundName; //Field offset: 0x80
	private IArcadePlayable _playable; //Field offset: 0x88

	public LevelArcadeNFC() { }

	[CompilerGenerated]
	private void <OnEnter>b__9_0() { }

	protected virtual void Awake() { }

	public virtual bool CanConsumeItem(LevelItem levelItem) { }

	public override void OnEnter(LevelDragActionByTagItemHandler handler) { }

	public override void OnExit(LevelDragActionByTagItemHandler handler) { }

	public virtual bool TryLevelItemDropInteraction(LevelItem levelItem, out MPEventIdentifierData mpData) { }

}

