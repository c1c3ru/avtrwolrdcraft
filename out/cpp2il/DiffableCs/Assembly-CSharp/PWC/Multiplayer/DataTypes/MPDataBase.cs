namespace PWC.Multiplayer.DataTypes;

public abstract class MPDataBase
{
	[JsonProperty("src")]
	public int sourceUID; //Field offset: 0x10
	[JsonProperty("otrd")]
	public MPOneCallGeneratorData oneCallGeneratorData; //Field offset: 0x18
	[JsonProperty("dggp")]
	public string dataGeneratorGuidPrefix; //Field offset: 0x20

	protected MPDataBase() { }

	public void CallHandleReceviedData() { }

	public abstract void HandleReceviedData() { }

	private void PostHandleReceivedData() { }

	private void PreHandleReceivedData() { }

	public override bool ShouldHostHanldeData() { }

}

