namespace Game.Level;

public class LevelBeardColorBrush : LevelHairColorSpray
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass1_0
	{
		public LevelCharacter target; //Field offset: 0x10
		public LevelBeardColorBrush <>4__this; //Field offset: 0x18

		public <>c__DisplayClass1_0() { }

		internal void <OnTargetEnter>b__0() { }

	}


	public LevelBeardColorBrush() { }

	public virtual void ColorTarget(LevelCharacter target) { }

	protected virtual void InitColorSprites() { }

	protected virtual void OnTargetEnter(ILevelConsumer consumer) { }

	protected virtual void OnTargetExit(ILevelConsumer consumer) { }

}

