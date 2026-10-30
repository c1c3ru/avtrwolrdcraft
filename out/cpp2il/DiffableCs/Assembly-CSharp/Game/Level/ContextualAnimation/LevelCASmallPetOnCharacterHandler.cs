namespace Game.Level.ContextualAnimation;

public class LevelCASmallPetOnCharacterHandler : LevelCAPetOnCharacterHandlerBase
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Predicate<LevelCAConfig> <>9__3_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal bool <Awake>b__3_0(LevelCAConfig c) { }

	}

	private const string HOLDING_PET_ANIMATION_NAME = "General/Sitting_Idle"; //Field offset: 0x0
	[SerializeField]
	private AnimalType _petType; //Field offset: 0x9C
	private List<LevelCAConfig> _configs; //Field offset: 0xA0

	public LevelCASmallPetOnCharacterHandler() { }

	protected virtual void Awake() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	protected virtual string GetBoneName() { }

	public virtual string GetFolderName() { }

	public virtual string GetLockedAnimationName() { }

	protected virtual Nullable<Vector2> GetPivotOnBone() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool IsValidForTarget(ICATarget target) { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	protected virtual void OnReadyPostLoad() { }

	public virtual bool TryOverrideConfigThumb(int configIndex, out Sprite sprite) { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

