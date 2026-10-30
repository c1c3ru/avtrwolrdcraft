namespace Game.Level.ContextualAnimation;

public class LevelCASimpleItemCraftingHandler : LevelCAItemCraftingHandlerBase
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass4_0
	{
		public LevelCASimpleItemCraftingHandler <>4__this; //Field offset: 0x10
		public LevelCharacter character; //Field offset: 0x18
		public LevelCAConfig config; //Field offset: 0x20

		public <>c__DisplayClass4_0() { }

		internal void <OnAnimationBegin>b__0() { }

	}

	[SerializeField]
	private string _animationName; //Field offset: 0xD8
	[Header("Events")]
	[Space]
	public UnityEvent<LevelCharacter, LevelCAConfig> _onStartingCraftingAnimation; //Field offset: 0xE0
	public UnityEvent<LevelCharacter, LevelCAConfig> _onFinishedCraftingAnimation; //Field offset: 0xE8

	public LevelCASimpleItemCraftingHandler() { }

	protected virtual string GetAnimationNameForAllConfigItems() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

}

