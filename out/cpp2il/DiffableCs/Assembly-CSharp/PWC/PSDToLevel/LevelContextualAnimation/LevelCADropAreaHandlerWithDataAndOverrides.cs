namespace PWC.PSDToLevel.LevelContextualAnimation;

public class LevelCADropAreaHandlerWithDataAndOverrides : LevelCADropAreaHandlerWithData
{
	[Header("Override Elements. Leave any empty to avoid overriding")]
	[SerializeField]
	[Space]
	private List<LevelCAConfig> _overrideLevelCAConfigs; //Field offset: 0x98
	[SerializeField]
	private string _overrideFolderName; //Field offset: 0xA0
	[SerializeField]
	private SpineType _overrideCharacterSpineType; //Field offset: 0xA8
	[SerializeField]
	private string _overrideLockedAnimation; //Field offset: 0xB0
	[SerializeField]
	private bool _useTextureReferenceForThumbPath; //Field offset: 0xB8
	[ConditionalField("_useTextureReferenceForThumbPath", False, True, (array) null)]
	[SerializeField]
	private string _overrideThumbPath; //Field offset: 0xC0
	[ConditionalField("_useTextureReferenceForThumbPath", True, True, (array) null)]
	[SerializeField]
	private PDTexture2DReference _overrideThumbPathReference; //Field offset: 0xC8
	[SerializeField]
	private OverrideSittingCA _overrideIsSittingCA; //Field offset: 0xD0
	[SerializeField]
	private OverrideSingleCAInMenu _overrideSingleCAInMenu; //Field offset: 0xD4

	public LevelCADropAreaHandlerWithDataAndOverrides() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual string GetLockedAnimationName() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool IsForceToSitWhenPossible() { }

	public virtual bool IsSingleCAInMenu() { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

