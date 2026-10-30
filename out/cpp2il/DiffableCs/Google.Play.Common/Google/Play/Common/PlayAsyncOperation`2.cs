namespace Google.Play.Common;

public abstract class PlayAsyncOperation : CustomYieldInstruction
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c<TResult, TError> <>9; //Field offset: 0x0
		public static Action<PlayAsyncOperation`2<TResult, TError>> <>9__18_0; //Field offset: 0x0

		private static <>c() { }

		public <>c() { }

		internal void <.ctor>b__18_0(PlayAsyncOperation<TResult, TError> <p0>) { }

	}

	[CompilerGenerated]
	private bool <IsDone>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private TError <Error>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private Action<PlayAsyncOperation`2<TResult, TError>> Completed; //Field offset: 0x0

	public override event Action<PlayAsyncOperation`2<TResult, TError>> Completed
	{
		[CompilerGenerated]
		 add { } //Length: 172
		[CompilerGenerated]
		 remove { } //Length: 172
	}

	public TError Error
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public bool IsDone
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	public abstract bool IsSuccessful
	{
		 get { } //Length: 0
	}

	public virtual bool keepWaiting
	{
		 get { } //Length: 16
	}

	protected PlayAsyncOperation`2() { }

	[CompilerGenerated]
	public override void add_Completed(Action<PlayAsyncOperation`2<TResult, TError>> value) { }

	[CompilerGenerated]
	public TError get_Error() { }

	[CompilerGenerated]
	public bool get_IsDone() { }

	public abstract bool get_IsSuccessful() { }

	public virtual bool get_keepWaiting() { }

	public TResult GetResult() { }

	protected abstract TResult GetResultImpl() { }

	protected void InvokeCompletedEvent() { }

	[CompilerGenerated]
	public override void remove_Completed(Action<PlayAsyncOperation`2<TResult, TError>> value) { }

	[CompilerGenerated]
	protected void set_Error(TError value) { }

	[CompilerGenerated]
	protected void set_IsDone(bool value) { }

}

