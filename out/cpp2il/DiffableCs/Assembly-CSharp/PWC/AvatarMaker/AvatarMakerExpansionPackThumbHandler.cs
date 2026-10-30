namespace PWC.AvatarMaker;

public class AvatarMakerExpansionPackThumbHandler
{
	internal enum ThumbSolutionType
	{
		Folded = 0,
		Hanged = 1,
		Thumb = 2,
		Head_Thumb = 3,
		Playable = 4,
		ParentCategory = 5,
	}

	private static Dictionary<SpineType, Dictionary`2<Int32, ThumbSolutionType>> ThumbSolutionPerSlot; //Field offset: 0x0

	private static AvatarMakerExpansionPackThumbHandler() { }

	public AvatarMakerExpansionPackThumbHandler() { }

	public static ThumbSolutionType GetThumbSolution(SpineType spineType, int categoryType) { }

}

