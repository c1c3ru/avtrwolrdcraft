//Type is in global namespace

public class VideoPacksCreator : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <Start>d__32 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public VideoPacksCreator <>4__this; //Field offset: 0x20

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		[DebuggerHidden]
		public <Start>d__32(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <StartAnimations>d__34 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public VideoPacksCreator <>4__this; //Field offset: 0x20
		private float <animTimeTemp>5__2; //Field offset: 0x28
		private int <cameraPropertiesIndex>5__3; //Field offset: 0x2C

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		[DebuggerHidden]
		public <StartAnimations>d__34(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	private const string GREEN_COLOR = "#00FF00"; //Field offset: 0x0
	private const string RED_COLOR = "#FF0011"; //Field offset: 0x0
	private const string YELLOW_COLOR = "#FFFF00"; //Field offset: 0x0
	private int packMusicChannel; //Field offset: 0x20
	[Header("Animation Properties")]
	public float packAnimTime; //Field offset: 0x24
	public float leftThreshold; //Field offset: 0x28
	public float rightThreshold; //Field offset: 0x2C
	public bool animFromLeftToRight; //Field offset: 0x30
	public string mainMusicName; //Field offset: 0x38
	public float mainMusicVolume; //Field offset: 0x40
	public bool isLinearCamera; //Field offset: 0x44
	public List<CameraProperties> cameraProperties; //Field offset: 0x48
	[Header("Default Properties")]
	public float animationStartIndex; //Field offset: 0x50
	public float defaultDelayTime; //Field offset: 0x54
	public float defaultAnimTime; //Field offset: 0x58
	public AnimType defaultAnimType; //Field offset: 0x5C
	public AnimTweenType defaultAnimTweenType; //Field offset: 0x60
	public string defaultSound; //Field offset: 0x68
	[Header("Items/Avatars")]
	public List<ItemAnimProperty> itemsProperty; //Field offset: 0x70
	public List<AvatarProperty> avatarsProperty; //Field offset: 0x78
	public List<SpineObjects> spineObjects; //Field offset: 0x80
	public List<AvatarProperty> avatarsPropertyTemp; //Field offset: 0x88
	[HideInInspector]
	[SerializeField]
	private GameObject _contentCameraGameObject; //Field offset: 0x90
	[HideInInspector]
	[SerializeField]
	private GameObject _cameraPoint; //Field offset: 0x98
	[HideInInspector]
	[SerializeField]
	private GameObject _sun; //Field offset: 0xA0
	[HideInInspector]
	[SerializeField]
	private GameObject _moon; //Field offset: 0xA8
	private Vector3 _startCameraPos; //Field offset: 0xB0
	private Camera _camera; //Field offset: 0xC0
	[Header("Level Info")]
	public float levelWidth; //Field offset: 0xC8
	public float minXPos; //Field offset: 0xCC
	public float maxXPos; //Field offset: 0xD0
	public float cameraZoomInSize; //Field offset: 0xD4

	public VideoPacksCreator() { }

	[CompilerGenerated]
	private void <StartAnimations>b__34_0(float value) { }

	private void ResetAnim() { }

	private void ResetItemsAndAvatars() { }

	[IteratorStateMachine(typeof(<Start>d__32))]
	private IEnumerator Start() { }

	[IteratorStateMachine(typeof(<StartAnimations>d__34))]
	private IEnumerator StartAnimations() { }

	public void SyncAvatars() { }

}

