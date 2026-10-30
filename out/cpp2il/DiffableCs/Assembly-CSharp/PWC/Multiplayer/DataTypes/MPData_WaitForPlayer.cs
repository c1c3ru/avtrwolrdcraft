namespace PWC.Multiplayer.DataTypes;

public class MPData_WaitForPlayer : MPDataBase
{
	internal enum Type
	{
		None = 0,
		Request = 1,
		Ack = 2,
	}

	[JsonProperty("rguid")]
	public string requestGuid; //Field offset: 0x28
	[JsonProperty("wfptype")]
	public Type waitForPlayerType; //Field offset: 0x30
	[JsonProperty("wfpuid")]
	public int waitForPlayerUID; //Field offset: 0x34
	[JsonProperty("fsn")]
	public string movingFromSceneName; //Field offset: 0x38
	[JsonProperty("tsn")]
	public string movingToSceneName; //Field offset: 0x40

	public MPData_WaitForPlayer() { }

	public virtual void HandleReceviedData() { }

}

