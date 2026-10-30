namespace Game.Level.ContextualAnimation;

public class LevelCASpringboardDropAreaHandler : LevelCADropAreaHandlerBase
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass12_0
	{
		public LevelCAConfig config; //Field offset: 0x10
		public LevelCharacter character; //Field offset: 0x18
		public LevelCASpringboardDropAreaHandler <>4__this; //Field offset: 0x20
		public int animationNumber; //Field offset: 0x28
		public Action <>9__3; //Field offset: 0x30

		public <>c__DisplayClass12_0() { }

		internal bool <OnAnimationPostBegin>b__0(LevelCAConfig x) { }

		internal void <OnAnimationPostBegin>b__1(TrackEntry _1) { }

		internal void <OnAnimationPostBegin>b__3() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass12_1
	{
		public Vector2 startPosition; //Field offset: 0x10
		public Vector2 endPosition; //Field offset: 0x18
		public string animationNamebase; //Field offset: 0x20
		public <>c__DisplayClass12_0 CS$<>8__locals1; //Field offset: 0x28

		public <>c__DisplayClass12_1() { }

		internal void <OnAnimationPostBegin>b__2(float t) { }

		internal void <OnAnimationPostBegin>b__4(TrackEntry _2) { }

	}

	[SerializeField]
	private LevelDropArea _dropArea; //Field offset: 0x80
	[SerializeField]
	private SkeletonAnimation _springBoard; //Field offset: 0x88
	[SerializeField]
	private ParticleSystem _particleSystemPrefab; //Field offset: 0x90
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x98
	[SerializeField]
	private string _boardSoundName; //Field offset: 0xA0
	[SerializeField]
	private string _splashSoundName; //Field offset: 0xA8
	[SerializeField]
	private bool _isManualLandingPoint; //Field offset: 0xB0
	[ConditionalField("_isManualLandingPoint", True, True, (array) null)]
	[SerializeField]
	private float _distance; //Field offset: 0xB4
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xB8

	public LevelCASpringboardDropAreaHandler() { }

	protected virtual void Awake() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	private void InitWaterDropArea() { }

	public virtual void OnAnimationPostBegin(ICATarget target, LevelCAConfig config, TrackEntry trackEntry) { }

	public virtual bool ShouldReturnToIdleAnimationAtEndOfAnimation() { }

}

