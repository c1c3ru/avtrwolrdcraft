namespace WebSocketSharp.Server;

internal class WebSocketServiceHost : WebSocketServiceHost
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c<TBehavior> <>9; //Field offset: 0x0
		public static Func<TBehavior> <>9__4_0; //Field offset: 0x0

		private static <>c() { }

		public <>c() { }

		internal TBehavior <createSessionCreator>b__4_0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass4_0
	{
		public Action<TBehavior> initializer; //Field offset: 0x0

		public <>c__DisplayClass4_0() { }

		internal TBehavior <createSessionCreator>b__1() { }

	}

	private Func<TBehavior> _creator; //Field offset: 0x0

	public virtual Type BehaviorType
	{
		 get { } //Length: 100
	}

	internal WebSocketServiceHost`1(string path, Action<TBehavior> initializer, Logger log) { }

	protected virtual WebSocketBehavior CreateSession() { }

	private static Func<TBehavior> createSessionCreator(Action<TBehavior> initializer) { }

	public virtual Type get_BehaviorType() { }

}

