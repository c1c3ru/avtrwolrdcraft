namespace PazuCore;

public class RTLUtils
{
	internal enum CharType
	{
		Undecided = 0,
		LTR = 1,
		RTL = 2,
	}

	internal class RTLData
	{
		public bool lines; //Field offset: 0x10
		public bool removeLines; //Field offset: 0x11
		public bool align; //Field offset: 0x12
		public bool forceRTL; //Field offset: 0x13
		public bool forceLTR; //Field offset: 0x14
		public int fixedLineSize; //Field offset: 0x18
		public float fixedFontSize; //Field offset: 0x1C

		public RTLData() { }

	}

	private static bool ltrAnchor; //Field offset: 0x0
	private static bool currentLetterLtr; //Field offset: 0x1
	private static Stack<Char> reverseLetters; //Field offset: 0x8
	public static bool mod; //Field offset: 0x10

	private static RTLUtils() { }

	public RTLUtils() { }

	public static void Aligned(bool anchor, MaskableGraphic textObj) { }

	private static bool Anchor(string text) { }

	public static void FixAlignment(MaskableGraphic textObj, bool ltrAnchor) { }

	private static CharType GetCharType(char c) { }

	public static string GetRTLText(string text, RTLData rtlData = null, MaskableGraphic textObj = null) { }

	private static bool IsBrackets(char c) { }

	private static bool IsRTL(int index, Char[] nextCs, int add) { }

	private static string MakeLines(string text, MaskableGraphic textObj, int fixedSize, float fixedFontSize) { }

	private static char ReverseBrackets(char c) { }

	private static string Rtl(string text, RTLData rtlData = null, MaskableGraphic textObj = null) { }

	public static void SetRTLText(string text, RTLData rtlData = null, MaskableGraphic textObj = null) { }

	private static string WorkOnLetter(bool enter, char c) { }

}

