namespace UnityEngine.ResourceManagement.ResourceProviders;

[DisplayName("Binary Data Provider")]
internal class BinaryDataProvider : ResourceProviderBase
{
	public class InternalOp
	{
		private BinaryDataProvider m_Provider; //Field offset: 0x10
		private UnityWebRequestAsyncOperation m_RequestOperation; //Field offset: 0x18
		private WebRequestQueueOperation m_RequestQueueOperation; //Field offset: 0x20
		private ProvideHandle m_PI; //Field offset: 0x28
		private bool m_IgnoreFailures; //Field offset: 0x40
		private bool m_Complete; //Field offset: 0x41
		private int m_Timeout; //Field offset: 0x44

		public InternalOp() { }

		[CompilerGenerated]
		private void <SendWebRequest>b__13_0(UnityWebRequestAsyncOperation asyncOperation) { }

		protected void CompleteOperation(Byte[] data, Exception exception) { }

		private object ConvertBytes(Byte[] data) { }

		private float GetPercentComplete() { }

		private void RequestOperation_completed(AsyncOperation op) { }

		protected override void SendWebRequest(string path) { }

		public void Start(ProvideHandle provideHandle, BinaryDataProvider rawProvider) { }

		private bool WaitForCompletionHandler() { }

	}

	[CompilerGenerated]
	private bool <IgnoreFailures>k__BackingField; //Field offset: 0x1C

	public bool IgnoreFailures
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	public BinaryDataProvider() { }

	public override object Convert(Type type, Byte[] data) { }

	[CompilerGenerated]
	public bool get_IgnoreFailures() { }

	public virtual void Provide(ProvideHandle provideHandle) { }

	[CompilerGenerated]
	public void set_IgnoreFailures(bool value) { }

}

