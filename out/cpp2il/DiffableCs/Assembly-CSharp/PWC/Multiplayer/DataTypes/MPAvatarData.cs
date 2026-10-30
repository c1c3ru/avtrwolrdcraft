namespace PWC.Multiplayer.DataTypes;

public class MPAvatarData
{
	[JsonProperty("aid")]
	public int avatarId; //Field offset: 0x10
	[JsonProperty("sData")]
	public AvatarSpineData spineData; //Field offset: 0x18
	[JsonProperty("lData")]
	public LevelAvatarData levelData; //Field offset: 0x20

	public MPAvatarData(int avatarId, AvatarSpineData spineData, LevelAvatarData levelData) { }

	public void ApplyData() { }

}

