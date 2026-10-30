namespace PWC.Level;

public class LevelDropActionArea : LevelConsumerAreaBase
{
	private Predicate<LevelItem> _filter; //Field offset: 0x58
	[CompilerGenerated]
	private bool <IsPointOnlyInteractionTest>k__BackingField; //Field offset: 0x60
	[CompilerGenerated]
	private bool <IsStrictInteractionTest>k__BackingField; //Field offset: 0x61
	[CompilerGenerated]
	private Action<LevelDropActionArea, LevelItem> OnItemEndLandAction; //Field offset: 0x68
	[CompilerGenerated]
	private Action<LevelDropActionArea, List`1<LevelItem>> OnOwnerItemEndLandAction; //Field offset: 0x70

	public event Action<LevelDropActionArea, LevelItem> OnItemEndLandAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event Action<LevelDropActionArea, List`1<LevelItem>> OnOwnerItemEndLandAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public bool IsPointOnlyInteractionTest
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	public bool IsStrictInteractionTest
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	public LevelDropActionArea() { }

	[CompilerGenerated]
	public void add_OnItemEndLandAction(Action<LevelDropActionArea, LevelItem> value) { }

	[CompilerGenerated]
	public void add_OnOwnerItemEndLandAction(Action<LevelDropActionArea, List`1<LevelItem>> value) { }

	protected virtual void Awake() { }

	public virtual bool CanConsumeItem(LevelItem levelItem) { }

	protected override bool FilterItem(LevelItem levelItem) { }

	[CompilerGenerated]
	public bool get_IsPointOnlyInteractionTest() { }

	[CompilerGenerated]
	public bool get_IsStrictInteractionTest() { }

	public List<LevelItem> GetPassedTestItems(List<LevelItem> levelItems) { }

	protected virtual void OnDestroy() { }

	private void OnItemEndLand(LevelItem levelItem, LevelDropArea dropArea) { }

	protected override void OnItemEndLand(LevelItem levelItem) { }

	protected override void OnOwnerItemEndLand(List<LevelItem> levelItems) { }

	public bool PerformItemTest(LevelItem levelItem) { }

	[CompilerGenerated]
	public void remove_OnItemEndLandAction(Action<LevelDropActionArea, LevelItem> value) { }

	[CompilerGenerated]
	public void remove_OnOwnerItemEndLandAction(Action<LevelDropActionArea, List`1<LevelItem>> value) { }

	[CompilerGenerated]
	public void set_IsPointOnlyInteractionTest(bool value) { }

	[CompilerGenerated]
	public void set_IsStrictInteractionTest(bool value) { }

	public void SetFilter(Predicate<LevelItem> filter) { }

	protected override bool ShouldListenToItemEndLandEvents() { }

	protected override bool ShouldPerformTestOnOwnerEndLand() { }

}

