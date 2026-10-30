namespace Google.Play.Core.Internal;

public class PlayCoreOnFailureListener : AndroidJavaProxy
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action<String, Int32> <>9__3_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <.ctor>b__3_0(string <p0>, int <p1>) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass4_0
	{
		public PlayCoreOnFailureListener <>4__this; //Field offset: 0x10
		public string message; //Field offset: 0x18
		public int errorCode; //Field offset: 0x20

		public <>c__DisplayClass4_0() { }

		internal void <onFailure>b__0() { }

	}

	[CompilerGenerated]
	private Action<String, Int32> OnTaskFailed; //Field offset: 0x20

	public event Action<String, Int32> OnTaskFailed
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public PlayCoreOnFailureListener() { }

	[CompilerGenerated]
	public void add_OnTaskFailed(Action<String, Int32> value) { }

	public void onFailure(AndroidJavaObject exception) { }

	[CompilerGenerated]
	public void remove_OnTaskFailed(Action<String, Int32> value) { }

}

