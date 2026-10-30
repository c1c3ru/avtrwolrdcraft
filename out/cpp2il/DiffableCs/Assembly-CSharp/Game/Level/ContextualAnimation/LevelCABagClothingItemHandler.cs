namespace Game.Level.ContextualAnimation;

public class LevelCABagClothingItemHandler : LevelCAItemHandlerBase
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Predicate<LevelCAConfig> <>9__4_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal bool <Awake>b__4_0(LevelCAConfig config) { }

	}

	private const string PUT_BAG_ANIMATION_NAME = "Put_On_Body_Bag"; //Field offset: 0x0
	private LevelClothingItem _clothingItem; //Field offset: 0x88
	private bool _isDuringEvent; //Field offset: 0x90
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x98

	public LevelCABagClothingItemHandler() { }

	protected virtual void Awake() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

