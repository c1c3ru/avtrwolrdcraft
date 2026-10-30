namespace Google.Play.Core.Internal;

public class TaskOnSuccessListener : AndroidJavaProxy
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c<TAndroidJava> <>9; //Field offset: 0x0
		public static Action<TAndroidJava> <>9__3_0; //Field offset: 0x0

		private static <>c() { }

		public <>c() { }

		internal void <.ctor>b__3_0(TAndroidJava <p0>) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass4_0
	{
		public TaskOnSuccessListener<TAndroidJava> <>4__this; //Field offset: 0x0
		public TAndroidJava result; //Field offset: 0x0

		public <>c__DisplayClass4_0() { }

		internal void <onSuccess>b__0() { }

	}

	[CompilerGenerated]
	private Action<TAndroidJava> OnTaskSucceeded; //Field offset: 0x0

	public event Action<TAndroidJava> OnTaskSucceeded
	{
		[CompilerGenerated]
		 add { } //Length: 172
		[CompilerGenerated]
		 remove { } //Length: 172
	}

	public TaskOnSuccessListener`1() { }

	[CompilerGenerated]
	public void add_OnTaskSucceeded(Action<TAndroidJava> value) { }

	public void onSuccess(TAndroidJava result) { }

	[CompilerGenerated]
	public void remove_OnTaskSucceeded(Action<TAndroidJava> value) { }

}

