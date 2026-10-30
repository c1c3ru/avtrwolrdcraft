namespace PazuCore.AF.Library;

public class LibraryVideoComponent : MonoBehaviour
{
	public static readonly List<LibraryVideoComponent> List; //Field offset: 0x0
	[SerializeField]
	private RawImage _videoImage; //Field offset: 0x20
	[SerializeField]
	private VideoPlayer _videoPlayer; //Field offset: 0x28
	private bool _didCallSetVideoOnce; //Field offset: 0x30
	private bool _isVideoPaused; //Field offset: 0x31
	private bool _isVideoInsideScreenArea; //Field offset: 0x32
	public Action OnVideoStartPlayingAction; //Field offset: 0x38
	public Action OnVideoLoopPointReachedAction; //Field offset: 0x40

	public VideoPlayer MyVideoPlayer
	{
		 get { } //Length: 8
	}

	private static LibraryVideoComponent() { }

	public LibraryVideoComponent() { }

	[CompilerGenerated]
	private void <OnBeforeSetVideo>b__16_0(VideoPlayer x) { }

	private void Awake() { }

	public VideoPlayer get_MyVideoPlayer() { }

	private void OnBeforeSetVideo() { }

	private void OnCullStateChanged(bool state) { }

	private void OnDestroy() { }

	private void OnLoopPointReached(VideoPlayer videoPlayer) { }

	public void PauseVideo() { }

	public void SetVideo(string videoUrl) { }

	public void SetVideo(VideoClip videoClip) { }

	public void TryPlayVideo() { }

}

