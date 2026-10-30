namespace StarsPass;

public class MilestoneData
{
	public string key; //Field offset: 0x10
	public int milestoneStarsRequirement; //Field offset: 0x18
	public int deltaStarsRequirement; //Field offset: 0x1C
	public Int32[] packsIndexes; //Field offset: 0x20
	public int currencyAmount; //Field offset: 0x28
	public bool claimed; //Field offset: 0x2C

	public MilestoneData() { }

}

