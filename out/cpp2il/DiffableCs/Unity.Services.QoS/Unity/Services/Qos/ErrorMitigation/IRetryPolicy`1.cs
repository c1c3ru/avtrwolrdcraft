namespace Unity.Services.Qos.ErrorMitigation;

internal interface IRetryPolicy
{

	public IRetryPolicy<T> HandleException() { }

	public IRetryPolicy<T> HandleException(Func<TException, Boolean> condition) { }

	public Task<T> RunAsync(RetryPolicyConfig retryPolicyConfig = null) { }

	public IRetryPolicy<T> UptoMaximumRetries(uint amount) { }

	public IRetryPolicy<T> WithDelayScale(float scale) { }

	public IRetryPolicy<T> WithJitterMagnitude(float magnitude) { }

	public IRetryPolicy<T> WithMaxDelayTime(float time) { }

	public IRetryPolicy<T> WithRetryCondition(Func<T, Task`1<Boolean>> shouldRetry) { }

}

