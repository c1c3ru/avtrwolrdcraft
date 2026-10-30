namespace System.Xml.Schema;

internal sealed class LeafRangeNode : LeafNode
{
	private decimal min; //Field offset: 0x18
	private decimal max; //Field offset: 0x28
	private BitSet nextIteration; //Field offset: 0x38

	public virtual bool IsRangeNode
	{
		 get { } //Length: 8
	}

	public decimal Max
	{
		 get { } //Length: 12
	}

	public decimal Min
	{
		 get { } //Length: 12
	}

	public BitSet NextIteration
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public LeafRangeNode(decimal min, decimal max) { }

	public LeafRangeNode(int pos, decimal min, decimal max) { }

	public virtual void ExpandTree(InteriorNode parent, SymbolsDictionary symbols, Positions positions) { }

	public virtual bool get_IsRangeNode() { }

	public decimal get_Max() { }

	public decimal get_Min() { }

	public BitSet get_NextIteration() { }

	public void set_NextIteration(BitSet value) { }

}

