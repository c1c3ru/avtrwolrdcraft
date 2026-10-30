namespace PWC.Multiplayer;

public class MPMoveAvatarCollectedData
{
	public string moveAvatarGuid; //Field offset: 0x10
	public int targetPlayerUID; //Field offset: 0x18
	public int avatarId; //Field offset: 0x1C
	public MPAvatarData avatarData; //Field offset: 0x20
	public float creationTime; //Field offset: 0x28
	public MPOneCallGeneratorData oneCallData; //Field offset: 0x30

	public MPMoveAvatarCollectedData() { }

}

