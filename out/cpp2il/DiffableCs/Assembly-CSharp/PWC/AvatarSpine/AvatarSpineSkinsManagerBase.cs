namespace PWC.AvatarSpine;

public abstract class AvatarSpineSkinsManagerBase : AWSpineSkinsManagerBase
{
	[CompilerGenerated]
	private static Action<Int32, String> OnAddSkinStaticAction; //Field offset: 0x0
	[CompilerGenerated]
	private static Action<Int32, String> OnRemoveSkinStaticAction; //Field offset: 0x8
	[CompilerGenerated]
	private static Action<Int32, String, Color[]> OnColorSkinStaticAction; //Field offset: 0x10
	protected int _avatarID; //Field offset: 0xA4
	protected AvatarSpineConfig _config; //Field offset: 0xA8
	[CompilerGenerated]
	private AvatarSizeType <SizeType>k__BackingField; //Field offset: 0xB0
	[CompilerGenerated]
	private bool <IsMaskedInUI>k__BackingField; //Field offset: 0xB4

	public static event Action<Int32, String> OnAddSkinStaticAction
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public static event Action<Int32, String, Color[]> OnColorSkinStaticAction
	{
		[CompilerGenerated]
		 add { } //Length: 208
		[CompilerGenerated]
		 remove { } //Length: 208
	}

	public static event Action<Int32, String> OnRemoveSkinStaticAction
	{
		[CompilerGenerated]
		 add { } //Length: 208
		[CompilerGenerated]
		 remove { } //Length: 208
	}

	public bool IsMaskedInUI
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	public AvatarSizeType SizeType
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	protected AvatarSpineSkinsManagerBase() { }

	[CompilerGenerated]
	private void <SetInitialSkins>g__SetDefaultSkins|24_0() { }

	[CompilerGenerated]
	public static void add_OnAddSkinStaticAction(Action<Int32, String> value) { }

	[CompilerGenerated]
	public static void add_OnColorSkinStaticAction(Action<Int32, String, Color[]> value) { }

	[CompilerGenerated]
	public static void add_OnRemoveSkinStaticAction(Action<Int32, String> value) { }

	public virtual bool AddSkin(int categoryType, string skinName, Action<String> onSkinRemoveAction = null, bool isRecursiveCall = false) { }

	public virtual void ColorSkin(int categoryType, Color[] colors) { }

	[CompilerGenerated]
	public bool get_IsMaskedInUI() { }

	[CompilerGenerated]
	public AvatarSizeType get_SizeType() { }

	public int GetAvatarID() { }

	protected override AvatarSpineConfig GetConfig() { }

	protected override SpineType GetDefaultSpineType() { }

	public abstract HashSet<Int32> GetRequiredCategoryTypes() { }

	public override float GetSizeScaleFactor() { }

	public AvatarSpineData GetSpineData() { }

	public void Init(int avatarID) { }

	protected override void OnLoadInitialSkin(SkinData skinData) { }

	[CompilerGenerated]
	public static void remove_OnAddSkinStaticAction(Action<Int32, String> value) { }

	[CompilerGenerated]
	public static void remove_OnColorSkinStaticAction(Action<Int32, String, Color[]> value) { }

	[CompilerGenerated]
	public static void remove_OnRemoveSkinStaticAction(Action<Int32, String> value) { }

	public virtual bool RemoveSkin(int categoryType, bool initiateChainEvent, Action<String> onRemoveAction = null) { }

	public override void SaveData() { }

	protected override void SaveDataImplement(int id, List<SkinData> skinsData, AvatarSizeType sizeType, AvatarSpineConfig config, SpineType spineType) { }

	[CompilerGenerated]
	public void set_IsMaskedInUI(bool value) { }

	[CompilerGenerated]
	protected void set_SizeType(AvatarSizeType value) { }

	protected void SetInitialSkins() { }

	public void SetSizeType(AvatarSizeType sizeType) { }

	protected override bool TryGetAvatarSpineData(out AvatarSpineData data) { }

}

