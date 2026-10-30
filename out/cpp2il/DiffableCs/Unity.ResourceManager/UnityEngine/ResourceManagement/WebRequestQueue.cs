namespace UnityEngine.ResourceManagement;

public static class WebRequestQueue
{
	internal static int s_MaxRequest; //Field offset: 0x0
	internal static Queue<WebRequestQueueOperation> s_QueuedOperations; //Field offset: 0x8
	internal static List<UnityWebRequestAsyncOperation> s_ActiveRequests; //Field offset: 0x10

	private static WebRequestQueue() { }

	private static void BeginWebRequest(WebRequestQueueOperation queueOperation) { }

	internal static void DequeueRequest(UnityWebRequestAsyncOperation operation) { }

	private static void OnWebAsyncOpComplete(AsyncOperation operation) { }

	private static void OnWebAsyncOpComplete(UnityWebRequestAsyncOperation operation) { }

	public static WebRequestQueueOperation QueueRequest(UnityWebRequest request) { }

	public static void SetMaxConcurrentRequests(int maxRequests) { }

	public static void WaitForRequestToBeActive(WebRequestQueueOperation request, int millisecondsTimeout) { }

}

