namespace PWC.Level;

public abstract class LevelAvatarRestAreaBase : LevelConsumerAreaBase, IItemsHolderArea, IRequirePDSceneObject
{
	[SerializeField]
	private bool _shouldForceSnap; //Field offset: 0x51
	[SerializeField]
	private bool _isTwoDirections; //Field offset: 0x52
	[ConditionalField("_isTwoDirections", False, True, (array) null)]
	[SerializeField]
	protected bool _isFlipped; //Field offset: 0x53
	[SerializeField]
	private bool _preventItemsHolding; //Field offset: 0x54
	[CompilerGenerated]
	private Action<LevelAvatarRestAreaBase, ILevelAvatar> OnAvatarBeginDropAction; //Field offset: 0x58
	[CompilerGenerated]
	private Action<LevelAvatarRestAreaBase, ILevelAvatar> OnAvatarEndDropAction; //Field offset: 0x60
	[CompilerGenerated]
	private Action<LevelAvatarRestAreaBase, ILevelAvatar> OnAvatarPickUpAction; //Field offset: 0x68
	[CompilerGenerated]
	private Action<LevelItem> OnItemsHolderItemEndDropAction; //Field offset: 0x70

	public event Action<LevelAvatarRestAreaBase, ILevelAvatar> OnAvatarBeginDropAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event Action<LevelAvatarRestAreaBase, ILevelAvatar> OnAvatarEndDropAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event Action<LevelAvatarRestAreaBase, ILevelAvatar> OnAvatarPickUpAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public override event Action<LevelItem> OnItemsHolderItemEndDropAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public bool IsFlipped
	{
		 get { } //Length: 8
	}

	public bool IsTwoDirections
	{
		 get { } //Length: 8
	}

	public bool PreventItemsHolding
	{
		 get { } //Length: 8
	}

	public bool ShouldForceSnap
	{
		 get { } //Length: 8
	}

	protected LevelAvatarRestAreaBase() { }

	[CompilerGenerated]
	private bool <ReleaseItemsOnAreasOfTheSameOwnerIfAny>b__33_0(LevelItem levelItem) { }

	[CompilerGenerated]
	public void add_OnAvatarBeginDropAction(Action<LevelAvatarRestAreaBase, ILevelAvatar> value) { }

	[CompilerGenerated]
	public void add_OnAvatarEndDropAction(Action<LevelAvatarRestAreaBase, ILevelAvatar> value) { }

	[CompilerGenerated]
	public void add_OnAvatarPickUpAction(Action<LevelAvatarRestAreaBase, ILevelAvatar> value) { }

	[CompilerGenerated]
	public override void add_OnItemsHolderItemEndDropAction(Action<LevelItem> value) { }

	public virtual bool CanConsumeItem(LevelItem levelItem) { }

	public bool get_IsFlipped() { }

	public bool get_IsTwoDirections() { }

	public bool get_PreventItemsHolding() { }

	public bool get_ShouldForceSnap() { }

	public abstract ILevelAvatar GetFirstAvatar() { }

	public abstract bool HasItemsOnSelf() { }

	public override bool IsAvailableForAvatar() { }

	public override void OnAvatarBeginDrop(ILevelAvatar avatar) { }

	public override void OnAvatarEndDrop(ILevelAvatar avatar) { }

	public override void OnAvatarPickUp(ILevelAvatar avatar) { }

	private override void PWC.Level.IItemsHolderArea.ReleaseItems() { }

	public override void ReleaseAvatars() { }

	public void ReleaseItemsOnAreasOfTheSameOwnerIfAny() { }

	[CompilerGenerated]
	public void remove_OnAvatarBeginDropAction(Action<LevelAvatarRestAreaBase, ILevelAvatar> value) { }

	[CompilerGenerated]
	public void remove_OnAvatarEndDropAction(Action<LevelAvatarRestAreaBase, ILevelAvatar> value) { }

	[CompilerGenerated]
	public void remove_OnAvatarPickUpAction(Action<LevelAvatarRestAreaBase, ILevelAvatar> value) { }

	[CompilerGenerated]
	public override void remove_OnItemsHolderItemEndDropAction(Action<LevelItem> value) { }

}

