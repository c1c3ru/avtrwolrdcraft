namespace Game.Level;

public class LevelBasketballHoopArea : LevelSingleCenteredItemDropArea
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass3_0
	{
		public LevelItem levelItem; //Field offset: 0x10

		public <>c__DisplayClass3_0() { }

		internal void <TryLevelItemDropInteraction>b__0() { }

	}

	[SerializeField]
	private LevelDropArea _dropAreaToFallOn; //Field offset: 0xD8
	[SerializeField]
	private Transform _front; //Field offset: 0xE0
	[SerializeField]
	private SkeletonAnimation _frontSkeletonAnimation; //Field offset: 0xE8

	public LevelBasketballHoopArea() { }

	[CompilerGenerated]
	private void <OnItemEndDrop>b__5_0() { }

	[CompilerGenerated]
	private void <OnItemEndDrop>b__5_1() { }

	public virtual bool CanConsumeItem(LevelItem levelItem) { }

	public virtual void OnItemEndDrop(LevelItem levelItem) { }

	public virtual bool TryLevelItemDropInteraction(LevelItem levelItem, out MPEventIdentifierData mpData) { }

}

