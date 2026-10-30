namespace PWC.Multiplayer.DataTypes;

public class MPEventIdentifierData
{
	public int index; //Field offset: 0x10
	public string key; //Field offset: 0x18
	public object args; //Field offset: 0x20

	public MPEventIdentifierData(int index, string key = null, object args = null) { }

}

