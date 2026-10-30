namespace UnityEngine.ResourceManagement;

public class WebRequestQueueOperation
{
	private bool m_Completed; //Field offset: 0x10
	public UnityWebRequestAsyncOperation Result; //Field offset: 0x18
	public Action<UnityWebRequestAsyncOperation> OnComplete; //Field offset: 0x20
	internal UnityWebRequest m_WebRequest; //Field offset: 0x28

	public bool IsDone
	{
		 get { } //Length: 32
	}

	public internal UnityWebRequest WebRequest
	{
		 get { } //Length: 8
		internal set { } //Length: 8
	}

	public WebRequestQueueOperation(UnityWebRequest request) { }

	internal void Complete(UnityWebRequestAsyncOperation asyncOp) { }

	public bool get_IsDone() { }

	public UnityWebRequest get_WebRequest() { }

	internal void set_WebRequest(UnityWebRequest value) { }

}

