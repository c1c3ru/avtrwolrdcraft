namespace Unity.Services.Relay.ErrorMitigation;

internal class RetryPolicyProvider : IRetryPolicyProvider
{

	public RetryPolicyProvider() { }

	public override IRetryPolicy<T> ForOperation(Func<Task`1<T>> operation) { }

	public override IRetryPolicy<T> ForOperation(Func<Int32, Task`1<T>> operation) { }

}

