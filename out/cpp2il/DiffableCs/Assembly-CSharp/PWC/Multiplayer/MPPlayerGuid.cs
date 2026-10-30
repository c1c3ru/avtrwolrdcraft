namespace PWC.Multiplayer;

public class MPPlayerGuid
{
	public readonly int playerUID; //Field offset: 0x10
	private string _guidPrefix; //Field offset: 0x18
	private int _localCounter; //Field offset: 0x20

	public string GuidPrefix
	{
		 get { } //Length: 8
	}

	public int LocalCounter
	{
		 get { } //Length: 8
	}

	public MPPlayerGuid(int playerUID) { }

	public string get_GuidPrefix() { }

	public int get_LocalCounter() { }

	public string GetNextGUID() { }

	public void SetGuidPrefix(string guidPrefix) { }

	public void SetGuidPrefixAndAppendPlayerUID(string guidPrefix) { }

}

