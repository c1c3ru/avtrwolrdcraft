namespace PWC.LevelPhone;

public class PhoneContentIcon : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass14_0
	{
		public PhoneContentIcon <>4__this; //Field offset: 0x10
		public Sprite sprite; //Field offset: 0x18

		public <>c__DisplayClass14_0() { }

		internal void <SetIcon>b__0() { }

		internal void <SetIcon>b__2() { }

		internal void <SetIcon>g__SetIconInternal|1(Sprite internalSprite) { }

	}

	private const float ANIMATION_TIME = 0,15; //Field offset: 0x0
	[CompilerGenerated]
	private static PhoneContentIcon <Instance>k__BackingField; //Field offset: 0x0
	[SerializeField]
	private Image _image; //Field offset: 0x20
	[SerializeField]
	private SerializableDictionaryBase<ApplicationType, Sprite> _applicationsIcons; //Field offset: 0x28
	private bool _isDisplayingIcon; //Field offset: 0x30
	private bool _skipNextApplicationIcon; //Field offset: 0x31
	private int _tweenID; //Field offset: 0x34

	public private static PhoneContentIcon Instance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 88
	}

	public PhoneContentIcon() { }

	[CompilerGenerated]
	private void <HideIcon>b__15_0() { }

	private void Awake() { }

	[CompilerGenerated]
	public static PhoneContentIcon get_Instance() { }

	public void HideIcon() { }

	private void OnApplicationClick(Application application) { }

	private void OnApplicationContentClose(bool _) { }

	private void OnDestroy() { }

	[CompilerGenerated]
	private static void set_Instance(PhoneContentIcon value) { }

	public void SetIcon(Sprite sprite) { }

	public void SkipNextApplicationIcon() { }

}

