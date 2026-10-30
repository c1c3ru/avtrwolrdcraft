namespace PWC.Level.ContextualAnimation;

public abstract class LevelCASpineSkinHandlerBase : LevelCAHandlerBase
{
	private SpineType _spineType; //Field offset: 0x80
	private string _skinName; //Field offset: 0x88
	[CompilerGenerated]
	private bool <IsDestroyed>k__BackingField; //Field offset: 0x90

	public bool IsDestroyed
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	protected LevelCASpineSkinHandlerBase() { }

	[CompilerGenerated]
	public bool get_IsDestroyed() { }

	public virtual CACategoryType GetCategoryType() { }

	protected string GetSkinName() { }

	public virtual SpineType GetSpineType() { }

	public void Init(SpineType spineType, string skinName) { }

	public virtual bool IsValidForTarget(ICATarget target) { }

	[CompilerGenerated]
	public void set_IsDestroyed(bool value) { }

	public bool TryGetClothingPrefab(out PDPrefab pdPrefab) { }

}

