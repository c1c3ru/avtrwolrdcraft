namespace StarsPass;

[IsReadOnly]
public struct StarsProgress
{
	public readonly int totalStars; //Field offset: 0x0
	public readonly int milestoneIndex; //Field offset: 0x4
	public readonly int starsIntoMilestone; //Field offset: 0x8
	public readonly int milestoneRequirement; //Field offset: 0xC
	public readonly bool isMaxed; //Field offset: 0x10

	public float Fraction
	{
		 get { } //Length: 40
	}

	public StarsProgress(int totalStars, int milestoneIndex, int starsIntoMilestone, int milestoneRequirement, bool isMaxed) { }

	public float get_Fraction() { }

}

