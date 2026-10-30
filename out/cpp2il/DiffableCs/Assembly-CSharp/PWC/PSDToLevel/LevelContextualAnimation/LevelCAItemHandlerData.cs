namespace PWC.PSDToLevel.LevelContextualAnimation;

[CreateAssetMenu(menuName = "PazuWorld/Level/CA/Default CA Data")]
public class LevelCAItemHandlerData : ScriptableObject
{
	public List<LevelCAConfig> LevelCAConfigs; //Field offset: 0x18
	public string BoneName; //Field offset: 0x20
	public bool EnsureHandAtAddedToTarget; //Field offset: 0x28
	public string FolderName; //Field offset: 0x30
	public SpineType CharacterSpineType; //Field offset: 0x38
	public string SkinName; //Field offset: 0x40
	public string LockedAnimation; //Field offset: 0x48
	public string OverrideThumbPath; //Field offset: 0x50
	public bool DontApplyForceToSit; //Field offset: 0x58
	public string ForcedToSitOverride; //Field offset: 0x60
	public bool IsSingleCA; //Field offset: 0x68
	public bool IsAllowedInWaterArea; //Field offset: 0x69
	public bool CanHoldItemsWithLockedAnimation; //Field offset: 0x6A
	public List<Int32> OverrideToForceToSitIndexs; //Field offset: 0x70
	public string OverrideBoneName; //Field offset: 0x78
	public List<Int32> OverrideBoneNameIndexes; //Field offset: 0x80
	public LevelTagType HoldItemWithOtherBoneWithTag; //Field offset: 0x88
	public CACategoryType CACategoryType; //Field offset: 0x8C
	public int Priority; //Field offset: 0x90

	public LevelCAItemHandlerData() { }

}

