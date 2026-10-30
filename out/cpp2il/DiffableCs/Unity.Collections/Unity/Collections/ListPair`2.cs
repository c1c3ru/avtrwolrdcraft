namespace Unity.Collections;

internal struct ListPair
{
	public Key key; //Field offset: 0x0
	public Value value; //Field offset: 0x0

	public ListPair`2(Key k, Value v) { }

	public virtual string ToString() { }

}

