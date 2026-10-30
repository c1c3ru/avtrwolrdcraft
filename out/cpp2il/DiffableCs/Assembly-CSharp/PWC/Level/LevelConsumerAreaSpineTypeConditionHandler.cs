namespace PWC.Level;

public class LevelConsumerAreaSpineTypeConditionHandler : LevelConsumerAreaConditionBase
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass9_0
	{
		public SpineType spineType; //Field offset: 0x10

		public <>c__DisplayClass9_0() { }

		internal bool <CanConsumeItem>b__0(SpineTypeCondition x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass9_1
	{
		public SpineType animalSpineType; //Field offset: 0x10

		public <>c__DisplayClass9_1() { }

		internal bool <CanConsumeItem>b__1(SpineTypeCondition x) { }

	}

	[SerializeField]
	private bool _acceptAllAvatars; //Field offset: 0x28
	[SerializeField]
	private bool _acceptAllAnimals; //Field offset: 0x29
	[SerializeField]
	private bool _alsoAcceptPlayables; //Field offset: 0x2A
	[SerializeField]
	private List<SpineTypeCondition> _conditions; //Field offset: 0x30

	public LevelConsumerAreaSpineTypeConditionHandler() { }

	protected virtual void Awake() { }

	protected virtual void CanConsumeItem(LevelItem levelItem, ref bool canConsume) { }

	private LevelItem GetFirstChildItem() { }

	protected virtual void OnDestroy() { }

	private void OnLevelPostInit() { }

	public bool PerformCheck(LevelItem levelItem) { }

}

