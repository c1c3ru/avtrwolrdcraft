namespace PazuCore.PazuCoreAddressables.AFC;

public class AFCAudio : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass17_0
	{
		public AFCAudio <>4__this; //Field offset: 0x10
		public string url; //Field offset: 0x18
		public Action onFinish; //Field offset: 0x20
		public Action<AudioClip> <>9__2; //Field offset: 0x28

		public <>c__DisplayClass17_0() { }

		internal void <GetAudioClip>b__0(string assetName) { }

		internal void <GetAudioClip>b__1() { }

		internal void <GetAudioClip>b__2(AudioClip audioClip) { }

	}

	internal enum CallType
	{
		None = 0,
		OnEnable = 1,
		Start = 2,
	}

	public const string USE_LOCAL = "USE_LOCAL"; //Field offset: 0x0
	[SerializeField]
	private string _key; //Field offset: 0x20
	[SerializeField]
	private string _localAudioName; //Field offset: 0x28
	[SerializeField]
	private CallType _callType; //Field offset: 0x30
	[SerializeField]
	private UnityEvent _onPlayEvent; //Field offset: 0x38
	private AudioSource _audioSource; //Field offset: 0x40
	[CompilerGenerated]
	private bool <UseLocalAudio>k__BackingField; //Field offset: 0x48

	public bool UseLocalAudio
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	public AFCAudio() { }

	[CompilerGenerated]
	private void <Start>b__12_0() { }

	private void Awake() { }

	[CompilerGenerated]
	public bool get_UseLocalAudio() { }

	private void GetAudioClip(Action onFinish) { }

	private void OnDisable() { }

	private void OnEnable() { }

	private void PlayAudio() { }

	[CompilerGenerated]
	public void set_UseLocalAudio(bool value) { }

	private void Start() { }

	public void TryPlayAudio() { }

}

