namespace Game.Level.ContextualAnimation;

[DisallowMultipleComponent]
public class LevelCASnowSurfaceToddlerHandler : LevelCAByWeatherCharacterHandlerBase
{
	[CompilerGenerated]
	private struct <>c__DisplayClass10_0
	{
		public TrackEntry trackEntry; //Field offset: 0x0
		public LevelCASnowSurfaceToddlerHandler <>4__this; //Field offset: 0x8
		public LevelToddler toddler; //Field offset: 0x10

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass9_0
	{
		public PDPrefab footPrint; //Field offset: 0x10
		public Action <>9__1; //Field offset: 0x18

		public <>c__DisplayClass9_0() { }

		internal void <AddFootPrint>b__0() { }

		internal void <AddFootPrint>b__1() { }

	}

	private int _soundIndex; //Field offset: 0x84
	private LevelItem _levelItem; //Field offset: 0x88
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x90

	public LevelCASnowSurfaceToddlerHandler() { }

	[CompilerGenerated]
	private void <OnAnimationEvent>g__PlayAnimationSpeciecParticles|10_0(ref <>c__DisplayClass10_0 unnamed_param_0) { }

	private void AddFootPrint(LevelToddler levelToddler, string standingPrefab, string sittingPrefab) { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	private PDPrefab GetPrefab(string name, Vector2 position) { }

	public virtual SpineType GetSpineType() { }

	public virtual bool IsRelevantForTarget(ICATarget target) { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	public void OnContact(LevelToddler levelToddler, Event spineEvent) { }

	public void OnPickup(DragDropItemBase arg1, PointerEventData arg2) { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

