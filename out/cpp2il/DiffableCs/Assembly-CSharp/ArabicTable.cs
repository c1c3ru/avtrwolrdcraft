//Type is in global namespace

internal class ArabicTable
{
	private static List<ArabicMapping> mapList; //Field offset: 0x0
	private static ArabicTable arabicMapper; //Field offset: 0x8

	internal static ArabicTable ArabicMapper
	{
		internal get { } //Length: 124
	}

	private ArabicTable() { }

	internal int Convert(int toBeConverted) { }

	internal static ArabicTable get_ArabicMapper() { }

}

