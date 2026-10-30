namespace PazuCore.MediaGeneric;

public class VideoComponent : MonoBehaviour
{
	public static readonly List<VideoComponent> List; //Field offset: 0x0
	[SerializeField]
	private RawImage _videoImage; //Field offset: 0x20
	[SerializeField]
	private VideoPlayer _videoPlayer; //Field offset: 0x28
	private Action<Boolean> _onFinish; //Field offset: 0x30
	private bool _isInProgress; //Field offset: 0x38
	private bool _shouldPlayWhenPrepared; //Field offset: 0x39

	public VideoPlayer MyVideoPlayer
	{
		 get { } //Length: 8
	}

	private static VideoComponent() { }

	public VideoComponent() { }

	[CompilerGenerated]
	private void <OnBeforeSetVideo>b__12_0(VideoPlayer videoPlayer) { }

	[CompilerGenerated]
	private void <OnBeforeSetVideo>b__12_1(VideoPlayer videoPlayer, string errorMessage) { }

	private void Awake() { }

	public VideoPlayer get_MyVideoPlayer() { }

	private void OnBeforeSetVideo() { }

	private void OnDestroy() { }

	public void SetVideo(string videoUrl, bool shouldPlayWhenPrepared = true, Action<Boolean> onFinish = null) { }

	public void SetVideo(VideoClip videoClip, bool shouldPlayWhenPrepared = true, Action<Boolean> onFinish = null) { }

}

