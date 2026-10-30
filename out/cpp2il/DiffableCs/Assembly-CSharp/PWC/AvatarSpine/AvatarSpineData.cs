namespace PWC.AvatarSpine;

public class AvatarSpineData
{
	public int ID; //Field offset: 0x10
	public List<SkinData> SkinsData; //Field offset: 0x18
	public AvatarSizeType SizeType; //Field offset: 0x20
	public AvatarSpineConfig Config; //Field offset: 0x28
	public SpineType SpineType; //Field offset: 0x30
	public int BuildNumber; //Field offset: 0x34

	public AvatarSpineData(int id, List<SkinData> skinsData, AvatarSizeType sizeType, AvatarSpineConfig config, SpineType spineType, int buildNumber) { }

}

