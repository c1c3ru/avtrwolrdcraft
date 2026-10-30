namespace UnityEngine.Networking;

[NativeHeader("Modules/UnityWebRequestTexture/Public/DownloadHandlerTexture.h")]
public sealed class DownloadHandlerTexture : DownloadHandler
{
	private NativeArray<Byte> m_NativeData; //Field offset: 0x18
	private bool mNonReadable; //Field offset: 0x28

	public Texture2D texture
	{
		 get { } //Length: 60
	}

	public DownloadHandlerTexture(bool readable) { }

	private static IntPtr Create(DownloadHandlerTexture obj, bool readable) { }

	public virtual void Dispose() { }

	public Texture2D get_texture() { }

	protected virtual NativeArray<Byte> GetNativeData() { }

	private void InternalCreateTexture(bool readable) { }

	[NativeThrows]
	private Texture2D InternalGetTextureNative() { }

}

