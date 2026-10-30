namespace PWC.Level;

public abstract class LevelConsumerAreaBase : LevelAreaBase, ILevelConsumer
{
	internal sealed class CanComsumeItemDelegate : MulticastDelegate
	{

		public CanComsumeItemDelegate(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(LevelItem levelItem, ref bool canConsume, AsyncCallback callback, object object) { }

		public override void EndInvoke(ref bool canConsume, IAsyncResult result) { }

		public override void Invoke(LevelItem levelItem, ref bool canConsume) { }

	}

	[SerializeField]
	private int _sortPriority; //Field offset: 0x38
	private SortingElement _sortingElement; //Field offset: 0x40
	[CompilerGenerated]
	private CanComsumeItemDelegate CanConsumeItemAction; //Field offset: 0x48
	[CompilerGenerated]
	private bool <IsReleasingItems>k__BackingField; //Field offset: 0x50

	public event CanComsumeItemDelegate CanConsumeItemAction
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public private bool IsReleasingItems
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 12
	}

	protected LevelConsumerAreaBase() { }

	[CompilerGenerated]
	public void add_CanConsumeItemAction(CanComsumeItemDelegate value) { }

	protected virtual void Awake() { }

	public override bool CanConsumeItem(LevelItem levelItem) { }

	[CompilerGenerated]
	public bool get_IsReleasingItems() { }

	public LevelItem GetFirstChildItem() { }

	public List<LevelItem> GetImmediateChildrenItems() { }

	protected virtual void OnDisable() { }

	protected virtual void OnEnable() { }

	private override ILevelEntity PWC.Level.ILevelConsumer.GetEntity() { }

	private override GameShape PWC.Level.ILevelConsumer.GetGameShape() { }

	private override SortingElement PWC.Level.ILevelConsumer.GetSortingElement() { }

	private override int PWC.Level.ILevelConsumer.GetSortPriority() { }

	private override Transform PWC.Level.ILevelConsumer.GetTransform() { }

	public override void ReleaseItems(Predicate<LevelItem> predicate = null) { }

	[CompilerGenerated]
	public void remove_CanConsumeItemAction(CanComsumeItemDelegate value) { }

	[CompilerGenerated]
	private void set_IsReleasingItems(bool value) { }

	public override bool TryLevelItemDropInteraction(LevelItem levelItem, out MPEventIdentifierData mpData) { }

}

