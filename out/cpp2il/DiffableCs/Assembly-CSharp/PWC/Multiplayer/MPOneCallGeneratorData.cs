namespace PWC.Multiplayer;

public class MPOneCallGeneratorData
{
	[JsonProperty("sd")]
	public Nullable<Int32> seed; //Field offset: 0x10
	[JsonProperty("gp")]
	public string guidPrefix; //Field offset: 0x18

	public MPOneCallGeneratorData() { }

}

