namespace PWC.LevelPhone;

public class PhoneBackground : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass14_0
	{
		public Color currentTopColor; //Field offset: 0x10
		public Color desiredTopColor; //Field offset: 0x20
		public PhoneBackground <>4__this; //Field offset: 0x30
		public Color currentBottomColor; //Field offset: 0x38
		public Color desiredBottomColor; //Field offset: 0x48

		public <>c__DisplayClass14_0() { }

		internal void <SetColor>b__0(float value) { }

	}

	[CompilerGenerated]
	private static PhoneBackground <Instance>k__BackingField; //Field offset: 0x0
	[SerializeField]
	private Material _material; //Field offset: 0x20
	[SerializeField]
	private SerializableDictionaryBase<ApplicationType, ApplicationBackgroundData> _backgroundColors; //Field offset: 0x28
	private int _tweenID; //Field offset: 0x30
	private Color _lastTopColor; //Field offset: 0x34
	private Color _lastBottomColor; //Field offset: 0x44

	public private static PhoneBackground Instance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 88
	}

	public PhoneBackground() { }

	private void Awake() { }

	public void ForceColor(Color topColor, Color bottomColor) { }

	public void ForceReturnToLastColors() { }

	[CompilerGenerated]
	public static PhoneBackground get_Instance() { }

	private void OnApplicationClick(Application application) { }

	private void OnApplicationContentClose(bool _) { }

	private void OnDestroy() { }

	[CompilerGenerated]
	private static void set_Instance(PhoneBackground value) { }

	private void SetColor(ApplicationType applicationType) { }

	private void SetColor(Color desiredTopColor, Color desiredBottomColor) { }

}

