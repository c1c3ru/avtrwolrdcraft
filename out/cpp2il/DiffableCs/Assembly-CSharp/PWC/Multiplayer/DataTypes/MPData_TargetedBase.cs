namespace PWC.Multiplayer.DataTypes;

public abstract class MPData_TargetedBase : MPDataBase
{
	[JsonProperty("tpuids")]
	public HashSet<Int32> targetPlayerUIDs; //Field offset: 0x28

	protected MPData_TargetedBase() { }

	public virtual bool ShouldHostHanldeData() { }

}

