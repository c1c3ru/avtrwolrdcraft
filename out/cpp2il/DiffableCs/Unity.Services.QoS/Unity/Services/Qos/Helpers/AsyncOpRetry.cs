namespace Unity.Services.Qos.Helpers;

internal static class AsyncOpRetry
{

	public static AsyncOpRetry<T> FromCreateAsync(Func<Int32, T> op) { }

}

