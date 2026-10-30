namespace Game.Level.ContextualAnimation;

public class LevelCAAudienceDropAreaHandler : LevelCADropAreaHandlerBase
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass6_0
	{
		public LevelCAAudienceDropAreaHandler <>4__this; //Field offset: 0x10
		public LevelItem coin; //Field offset: 0x18

		public <>c__DisplayClass6_0() { }

		internal void <OnAnimationEvent>b__0() { }

	}

	[SerializeField]
	private LevelSpawn _coinPrefab; //Field offset: 0x80
	[SerializeField]
	private LevelSpawner _levelSpawner; //Field offset: 0x88
	[SerializeField]
	private LevelDropArea _dropArea; //Field offset: 0x90
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x98

	public LevelCAAudienceDropAreaHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

}

