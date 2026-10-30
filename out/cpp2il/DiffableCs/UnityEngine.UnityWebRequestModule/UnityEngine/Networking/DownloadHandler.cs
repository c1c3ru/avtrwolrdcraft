namespace UnityEngine.Networking;

[NativeHeader("Modules/UnityWebRequest/Public/DownloadHandler/DownloadHandler.h")]
public class DownloadHandler : IDisposable
{
	[VisibleToOtherModules]
	internal IntPtr m_Ptr; //Field offset: 0x10

	public Byte[] data
	{
		 get { } //Length: 12
	}

	public string error
	{
		 get { } //Length: 60
	}

	public string text
	{
		 get { } //Length: 12
	}

	[VisibleToOtherModules]
	internal DownloadHandler() { }

	[RequiredByNativeCode]
	protected override void CompleteContent() { }

	internal static void CreateNativeArrayForNativeData(ref NativeArray<Byte>& data, Byte* bytes, int length) { }

	public override void Dispose() { }

	internal static void DisposeNativeArray(ref NativeArray<Byte>& data) { }

	protected virtual void Finalize() { }

	public Byte[] get_data() { }

	public string get_error() { }

	public string get_text() { }

	protected static T GetCheckedDownloader(UnityWebRequest www) { }

	private string GetContentType() { }

	protected override Byte[] GetData() { }

	private string GetErrorMsg() { }

	protected override NativeArray<Byte> GetNativeData() { }

	[RequiredByNativeCode]
	protected override float GetProgress() { }

	protected override string GetText() { }

	private Encoding GetTextEncoder() { }

	[NativeThrows]
	[VisibleToOtherModules]
	internal static Byte* InternalGetByteArray(DownloadHandler dh, out int length) { }

	internal static Byte[] InternalGetByteArray(DownloadHandler dh) { }

	internal static NativeArray<Byte> InternalGetNativeArray(DownloadHandler dh, ref NativeArray<Byte>& nativeArray) { }

	[Obsolete("Use ReceiveContentLengthHeader")]
	protected override void ReceiveContentLength(int contentLength) { }

	[RequiredByNativeCode]
	protected override void ReceiveContentLengthHeader(ulong contentLength) { }

	[RequiredByNativeCode]
	protected override bool ReceiveData(Byte[] data, int dataLength) { }

	[NativeMethod(IsThreadSafe = True)]
	private void Release() { }

}

