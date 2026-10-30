namespace Game.Level.ContextualAnimation;

public class LevelCAAppliancesContainerItemHandler : LevelCAMakeUpContainerItemHandler
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass2_0
	{
		public LevelCharacter character; //Field offset: 0x10
		public LevelSimpleSpawner spawner; //Field offset: 0x18

		public <>c__DisplayClass2_0() { }

		internal void <OnAnimationEvent>g__OnPostSpawn|0(LevelItem _item) { }

	}

	private readonly List<LevelCAConfig> _configs; //Field offset: 0x90

	public LevelCAAppliancesContainerItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

}

