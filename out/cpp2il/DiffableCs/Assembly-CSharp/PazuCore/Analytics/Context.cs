namespace PazuCore.Analytics;

public static class Context
{
	[CompilerGenerated]
	private static double <Time>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private static String[] <Current>k__BackingField; //Field offset: 0x8
	public static readonly Dictionary<String, String> OverrideValues; //Field offset: 0x10
	[CompilerGenerated]
	private static Action OnClearAction; //Field offset: 0x18

	public static event Action OnClearAction
	{
		[CompilerGenerated]
		 add { } //Length: 220
		[CompilerGenerated]
		 remove { } //Length: 220
	}

	public private static String[] Current
	{
		[CompilerGenerated]
		 get { } //Length: 88
		[CompilerGenerated]
		private set { } //Length: 96
	}

	public private static double Time
	{
		[CompilerGenerated]
		 get { } //Length: 88
		[CompilerGenerated]
		private set { } //Length: 100
	}

	private static Context() { }

	[CompilerGenerated]
	public static void add_OnClearAction(Action value) { }

	public static void Clear(bool sendContextRemovedEventifExist) { }

	[CompilerGenerated]
	public static String[] get_Current() { }

	[CompilerGenerated]
	public static double get_Time() { }

	[CompilerGenerated]
	public static void remove_OnClearAction(Action value) { }

	public static void Set(String[] context) { }

	[CompilerGenerated]
	private static void set_Current(String[] value) { }

	[CompilerGenerated]
	private static void set_Time(double value) { }

}

