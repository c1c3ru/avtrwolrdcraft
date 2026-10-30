namespace Game.Level.ContextualAnimation;

public class LevelCAPlayFountainDropAreaHandler : LevelCADropAreaHandlerBase
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass5_0
	{
		public PDPrefab footPrint; //Field offset: 0x10

		public <>c__DisplayClass5_0() { }

		internal void <SpawnSplash>b__0() { }

	}

	internal enum WaterFountainType
	{
		Fountain = 0,
		Puddle = 1,
	}

	[SerializeField]
	private WaterFountainType _waterFountainType; //Field offset: 0x80
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x88

	public LevelCAPlayFountainDropAreaHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	private PDPrefab GetPrefab(string name, Vector2 position) { }

	public virtual SpineType GetSpineType() { }

	public virtual bool IsValidForTarget(ICATarget target) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	private void SpawnSplash(ICATarget target) { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

