namespace PWC.AWCloud;

public static class AWCloudUserLinkMethods
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass1_0
	{
		public Action<Boolean> onFinish; //Field offset: 0x10

		public <>c__DisplayClass1_0() { }

		internal void <Link>b__0(Response response) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass2_0
	{
		public string op; //Field offset: 0x10
		public Action<Response> onResponse; //Field offset: 0x18

		public <>c__DisplayClass2_0() { }

		internal void <SendEmail>b__0(string responseText) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass3_0
	{
		public string op; //Field offset: 0x10
		public LinkType linkType; //Field offset: 0x18
		public Action<Boolean> onFinish; //Field offset: 0x20
		public Action <>9__1; //Field offset: 0x28

		public <>c__DisplayClass3_0() { }

		internal void <VerifyEmail>b__0(string responseText) { }

		internal void <VerifyEmail>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <SyncUserPostLogin>d__4 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public Action onFinish; //Field offset: 0x20

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		[DebuggerHidden]
		public <SyncUserPostLogin>d__4(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	internal enum LinkType
	{
		None = 0,
		SignUp = 1,
		SignIn = 2,
	}


	private static string GetOpName(LinkType linkType) { }

	private static bool IsEmailValid(string email) { }

	public static void Link(LinkType linkType, string email, Action<Boolean> onFinish) { }

	private static void SendEmail(LinkType linkType, string email, Action<Response> onResponse) { }

	[IteratorStateMachine(typeof(<SyncUserPostLogin>d__4))]
	private static IEnumerator SyncUserPostLogin(Action onFinish) { }

	public static void VerifyEmail(LinkType linkType, string email, string code, Action<Boolean> onFinish) { }

}

