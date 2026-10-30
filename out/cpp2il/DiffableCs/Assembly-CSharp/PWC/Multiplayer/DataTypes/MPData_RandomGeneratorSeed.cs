namespace PWC.Multiplayer.DataTypes;

public class MPData_RandomGeneratorSeed : MPData_TargetedBase
{
	[JsonProperty("puti")]
	public HashSet<Int32> playerUIDsToInit; //Field offset: 0x30
	[JsonProperty("rSeed")]
	public Nullable<Int32> randomGeneratorSeed; //Field offset: 0x38
	[JsonProperty("hcc")]
	public Nullable<Int32> hostChangesCounter; //Field offset: 0x40
	[JsonProperty("gp")]
	public string guidPrefix; //Field offset: 0x48

	public MPData_RandomGeneratorSeed() { }

	public virtual void HandleReceviedData() { }

}

