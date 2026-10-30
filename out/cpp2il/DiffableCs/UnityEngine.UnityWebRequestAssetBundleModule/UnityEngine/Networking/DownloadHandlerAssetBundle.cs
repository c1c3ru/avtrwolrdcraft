namespace UnityEngine.Networking;

[NativeHeader("Modules/UnityWebRequestAssetBundle/Public/DownloadHandlerAssetBundle.h")]
public sealed class DownloadHandlerAssetBundle : DownloadHandler
{

	public AssetBundle assetBundle
	{
		 get { } //Length: 60
	}

	public bool autoLoadAssetBundle
	{
		 get { } //Length: 60
		[NativeThrows]
		 set { } //Length: 68
	}

	public bool isDownloadComplete
	{
		 get { } //Length: 60
	}

	public DownloadHandlerAssetBundle(string url, uint crc) { }

	public DownloadHandlerAssetBundle(string url, CachedAssetBundle cachedBundle, uint crc) { }

	private static IntPtr Create(DownloadHandlerAssetBundle obj, string url, uint crc) { }

	private static IntPtr CreateCached(DownloadHandlerAssetBundle obj, string url, string name, Hash128 hash, uint crc) { }

	private static IntPtr CreateCached_Injected(DownloadHandlerAssetBundle obj, string url, string name, ref Hash128 hash, uint crc) { }

	public AssetBundle get_assetBundle() { }

	public bool get_autoLoadAssetBundle() { }

	public bool get_isDownloadComplete() { }

	public static AssetBundle GetContent(UnityWebRequest www) { }

	protected virtual Byte[] GetData() { }

	protected virtual string GetText() { }

	private void InternalCreateAssetBundle(string url, uint crc) { }

	private void InternalCreateAssetBundleCached(string url, string name, Hash128 hash, uint crc) { }

	[NativeThrows]
	public void set_autoLoadAssetBundle(bool value) { }

}

