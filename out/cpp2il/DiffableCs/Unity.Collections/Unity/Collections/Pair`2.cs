namespace Unity.Collections;

internal struct Pair
{
	public Key key; //Field offset: 0x0
	public Value value; //Field offset: 0x0

	public Pair`2(Key k, Value v) { }

	public virtual string ToString() { }

}

