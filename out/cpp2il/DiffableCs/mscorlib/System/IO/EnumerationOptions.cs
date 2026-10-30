namespace System.IO;

public class EnumerationOptions
{
	[CompilerGenerated]
	private static readonly EnumerationOptions <Compatible>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private static readonly EnumerationOptions <CompatibleRecursive>k__BackingField; //Field offset: 0x8
	[CompilerGenerated]
	private static readonly EnumerationOptions <Default>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private bool <RecurseSubdirectories>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private bool <IgnoreInaccessible>k__BackingField; //Field offset: 0x11
	[CompilerGenerated]
	private FileAttributes <AttributesToSkip>k__BackingField; //Field offset: 0x14
	[CompilerGenerated]
	private MatchType <MatchType>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private MatchCasing <MatchCasing>k__BackingField; //Field offset: 0x1C
	[CompilerGenerated]
	private bool <ReturnSpecialDirectories>k__BackingField; //Field offset: 0x20

	public FileAttributes AttributesToSkip
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	internal static EnumerationOptions Compatible
	{
		[CompilerGenerated]
		internal get { } //Length: 88
	}

	private static EnumerationOptions CompatibleRecursive
	{
		[CompilerGenerated]
		private get { } //Length: 88
	}

	internal static EnumerationOptions Default
	{
		[CompilerGenerated]
		internal get { } //Length: 88
	}

	public bool IgnoreInaccessible
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	public MatchCasing MatchCasing
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	public MatchType MatchType
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public bool RecurseSubdirectories
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	public bool ReturnSpecialDirectories
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	private static EnumerationOptions() { }

	public EnumerationOptions() { }

	internal static EnumerationOptions FromSearchOption(SearchOption searchOption) { }

	[CompilerGenerated]
	public FileAttributes get_AttributesToSkip() { }

	[CompilerGenerated]
	internal static EnumerationOptions get_Compatible() { }

	[CompilerGenerated]
	private static EnumerationOptions get_CompatibleRecursive() { }

	[CompilerGenerated]
	internal static EnumerationOptions get_Default() { }

	[CompilerGenerated]
	public bool get_IgnoreInaccessible() { }

	[CompilerGenerated]
	public MatchCasing get_MatchCasing() { }

	[CompilerGenerated]
	public MatchType get_MatchType() { }

	[CompilerGenerated]
	public bool get_RecurseSubdirectories() { }

	[CompilerGenerated]
	public bool get_ReturnSpecialDirectories() { }

	[CompilerGenerated]
	public void set_AttributesToSkip(FileAttributes value) { }

	[CompilerGenerated]
	public void set_IgnoreInaccessible(bool value) { }

	[CompilerGenerated]
	public void set_MatchType(MatchType value) { }

	[CompilerGenerated]
	public void set_RecurseSubdirectories(bool value) { }

}

