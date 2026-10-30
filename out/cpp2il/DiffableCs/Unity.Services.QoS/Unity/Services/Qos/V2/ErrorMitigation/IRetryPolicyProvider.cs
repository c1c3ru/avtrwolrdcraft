namespace Unity.Services.Qos.V2.ErrorMitigation;

internal interface IRetryPolicyProvider
{

	public IRetryPolicy<T> ForOperation(Func<Int32, Task`1<T>> operation) { }

	public IRetryPolicy<T> ForOperation(Func<Task`1<T>> operation) { }

}

