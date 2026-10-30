namespace Game.Level.ContextualAnimation;

public class LevelCAAisleDropAreaHandler : LevelCADropAreaHandlerBase
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass10_0
	{
		public LevelCharacter character; //Field offset: 0x10

		public <>c__DisplayClass10_0() { }

		internal void <OnAnimationBegin>b__0() { }

	}

	[SerializeField]
	private float _endOfAisleX; //Field offset: 0x80
	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0x88
	private float _walkingSpeed; //Field offset: 0x90
	private bool _isInit; //Field offset: 0x94
	private Dictionary<Int32, Int32> _tweenIDByCharacterID; //Field offset: 0x98
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xA0

	public LevelCAAisleDropAreaHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	private void Init() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	protected virtual void OnLevelPostInit() { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

}

