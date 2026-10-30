namespace Google.Play.Common.Internal;

public abstract class PlayAsyncOperationImpl : PlayAsyncOperation<TResult, TError>
{
	private TResult _result; //Field offset: 0x0

	public virtual event Action<PlayAsyncOperation`2<TResult, TError>> Completed
	{
		 add { } //Length: 76
		 remove { } //Length: 32
	}

	protected PlayAsyncOperationImpl`2() { }

	public virtual void add_Completed(Action<PlayAsyncOperation`2<TResult, TError>> value) { }

	protected virtual TResult GetResultImpl() { }

	public virtual void remove_Completed(Action<PlayAsyncOperation`2<TResult, TError>> value) { }

	public void SetError(TError errorCode) { }

	public void SetResult(TResult result) { }

}

