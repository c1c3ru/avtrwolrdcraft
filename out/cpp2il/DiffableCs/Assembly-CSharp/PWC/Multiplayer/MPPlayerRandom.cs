namespace PWC.Multiplayer;

public class MPPlayerRandom
{
	public readonly int playerUID; //Field offset: 0x10
	private int _seed; //Field offset: 0x14
	private Random _random; //Field offset: 0x18

	public MPPlayerRandom(int playerUID, int seed) { }

	public Random GetRandom() { }

	public void Reset(int seed) { }

}

