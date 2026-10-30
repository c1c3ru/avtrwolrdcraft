namespace Game.Level.ContextualAnimation;

public class LevelCASnowDropAreaHandler : LevelCADropAreaHandlerBase
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass5_0
	{
		public PDPrefab footPrint; //Field offset: 0x10

		public <>c__DisplayClass5_0() { }

		internal void <OnItemPickUp>b__0() { }

	}

	private const string PICKUP_SNOWBALL_ANIMATION_NAME = "Pickup_Snowball"; //Field offset: 0x0
	private LevelDropArea _dropArea; //Field offset: 0x80
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x88

	public LevelCASnowDropAreaHandler() { }

	protected virtual void Awake() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	private PDPrefab GetPrefab(string name, Vector2 position) { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	protected virtual void OnDestroy() { }

	private void OnItemPickUp(LevelItem item) { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

