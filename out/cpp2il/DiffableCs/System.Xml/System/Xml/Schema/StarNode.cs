namespace System.Xml.Schema;

internal sealed class StarNode : InteriorNode
{

	public virtual bool IsNullable
	{
		 get { } //Length: 8
	}

	public StarNode() { }

	public virtual void ConstructPos(BitSet firstpos, BitSet lastpos, BitSet[] followpos) { }

	public virtual bool get_IsNullable() { }

}

