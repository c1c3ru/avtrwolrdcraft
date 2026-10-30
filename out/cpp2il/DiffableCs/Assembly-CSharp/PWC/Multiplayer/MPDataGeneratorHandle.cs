namespace PWC.Multiplayer;

public class MPDataGeneratorHandle
{
	private readonly MPOneCallGeneratorData _data; //Field offset: 0x10
	private MPPlayerGuid _playerGuid; //Field offset: 0x18
	private MPPlayerRandom _playerRandom; //Field offset: 0x20

	public MPDataGeneratorHandle(MPOneCallGeneratorData data) { }

	public MPOneCallGeneratorData GetData() { }

	public MPPlayerGuid GetGuidGenerator() { }

	public MPPlayerRandom GetRandomGenerator() { }

	public bool HasOneCallGeneratorData() { }

}

