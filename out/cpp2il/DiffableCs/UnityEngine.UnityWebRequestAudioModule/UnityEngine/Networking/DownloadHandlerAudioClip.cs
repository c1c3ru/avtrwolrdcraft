namespace UnityEngine.Networking;

[NativeHeader("Modules/UnityWebRequestAudio/Public/DownloadHandlerAudioClip.h")]
public sealed class DownloadHandlerAudioClip : DownloadHandler
{
	private NativeArray<Byte> m_NativeData; //Field offset: 0x18

	[NativeThrows]
	public AudioClip audioClip
	{
		 get { } //Length: 60
	}

	public DownloadHandlerAudioClip(string url, AudioType audioType) { }

	private static IntPtr Create(DownloadHandlerAudioClip obj, string url, AudioType audioType) { }

	public virtual void Dispose() { }

	public AudioClip get_audioClip() { }

	public static AudioClip GetContent(UnityWebRequest www) { }

	protected virtual NativeArray<Byte> GetNativeData() { }

	protected virtual string GetText() { }

	private void InternalCreateAudioClip(string url, AudioType audioType) { }

}

