namespace System.Text.RegularExpressions;

internal sealed class RegexReplacement
{
	private const int Specials = 4; //Field offset: 0x0
	public const int LeftPortion = -1; //Field offset: 0x0
	public const int RightPortion = -2; //Field offset: 0x0
	public const int LastGroup = -3; //Field offset: 0x0
	public const int WholeString = -4; //Field offset: 0x0
	private readonly List<String> _strings; //Field offset: 0x10
	private readonly List<Int32> _rules; //Field offset: 0x18
	[CompilerGenerated]
	private readonly string <Pattern>k__BackingField; //Field offset: 0x20

	public string Pattern
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	public RegexReplacement(string rep, RegexNode concat, Hashtable _caps) { }

	[CompilerGenerated]
	public string get_Pattern() { }

	public static RegexReplacement GetOrCreate(WeakReference<RegexReplacement> replRef, string replacement, Hashtable caps, int capsize, Hashtable capnames, RegexOptions roptions) { }

	public string Replace(Regex regex, string input, int count, int startat) { }

	private void ReplacementImpl(StringBuilder sb, Match match) { }

	private void ReplacementImplRTL(List<String> al, Match match) { }

}

