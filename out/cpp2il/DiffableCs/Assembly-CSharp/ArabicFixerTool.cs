//Type is in global namespace

internal class ArabicFixerTool
{
	internal static bool showTashkeel; //Field offset: 0x0
	internal static bool combineTashkeel; //Field offset: 0x1
	internal static bool useHinduNumbers; //Field offset: 0x2

	private static ArabicFixerTool() { }

	public ArabicFixerTool() { }

	internal static string FixLine(string str) { }

	internal static bool IsFinishingLetter(Char[] letters, int index) { }

	internal static bool IsIgnoredCharacter(char ch) { }

	internal static bool IsLeadingLetter(Char[] letters, int index) { }

	internal static bool IsMiddleLetter(Char[] letters, int index) { }

	internal static string RemoveTashkeel(string str, out List<TashkeelLocation>& tashkeelLocation) { }

	internal static Char[] ReturnTashkeel(Char[] letters, List<TashkeelLocation> tashkeelLocation) { }

}

