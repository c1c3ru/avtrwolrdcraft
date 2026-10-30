namespace Game.Level.ContextualAnimation;

public class LevelCAGooFoodFightItemHandler : LevelCAItemHandlerBase
{
	[SerializeField]
	private float _flightSpeed; //Field offset: 0x88
	[SerializeField]
	private SpriteRenderer _spriteRenderer; //Field offset: 0x90
	[SerializeField]
	private Sprite[] _gooStages; //Field offset: 0x98
	private LevelCharacter _currentCharacter; //Field offset: 0xA0
	private LevelCharacter _closestCharacter; //Field offset: 0xA8
	private int _throwTweenID; //Field offset: 0xB0
	private int _colorIndex; //Field offset: 0xB4
	private String[] _catchAnimations; //Field offset: 0xB8
	private Color[] _colors; //Field offset: 0xC0
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xC8

	public LevelCAGooFoodFightItemHandler() { }

	[CompilerGenerated]
	private void <FadeOutGoo>b__20_0() { }

	[CompilerGenerated]
	private void <FadeOutGoo>b__20_1() { }

	[CompilerGenerated]
	private void <ThrowFoodOnCharacter>b__18_0() { }

	[CompilerGenerated]
	private void <ThrowFoodOnFloor>b__19_0() { }

	protected virtual void Awake() { }

	public void FadeOutGoo() { }

	private void FadeOutSprite(float val) { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	private void ThrowFoodOnCharacter() { }

	private void ThrowFoodOnFloor() { }

	private void ThrowGoo() { }

	private bool TryGetClosestCharacter() { }

}

