namespace Game.Level.ContextualAnimation;

public class LevelCALegCastSpineSkinHandler : LevelCAShoesSpineSkinHandler
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Predicate<LevelCAConfig> <>9__5_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal bool <GetAnimations>b__5_0(LevelCAConfig config) { }

	}

	private const string REACTIONS_DATA_PATH = "Level/AnimationsReactions/Character/CharacterLegCastAnimationsReactionsData"; //Field offset: 0x0
	private bool isAddedBaseAnimations; //Field offset: 0xA0
	private LevelReactionOfAvatarsOnCAAnimationHandler _radiusEventHandler; //Field offset: 0xA8
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xB0
	private List<Int32> _castNumbers; //Field offset: 0xB8

	public LevelCALegCastSpineSkinHandler() { }

	protected virtual void Awake() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public void OnReactionEnd(ILevelAvatar avatar) { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

}

