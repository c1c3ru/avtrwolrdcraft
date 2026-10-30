namespace PWC.LevelPhone;

public class PhoneSeparator : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass12_0
	{
		public Color currentTopColor; //Field offset: 0x10
		public Color desiredTopColor; //Field offset: 0x20
		public PhoneSeparator <>4__this; //Field offset: 0x30

		public <>c__DisplayClass12_0() { }

		internal void <SetColor>b__0(float value) { }

	}

	[CompilerGenerated]
	private static PhoneSeparator <Instance>k__BackingField; //Field offset: 0x0
	[SerializeField]
	private Image _image; //Field offset: 0x20
	[SerializeField]
	private SerializableDictionaryBase<ApplicationType, Color> _seperatorColors; //Field offset: 0x28
	private int _tweenID; //Field offset: 0x30

	public private static PhoneSeparator Instance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 88
	}

	public PhoneSeparator() { }

	private void Awake() { }

	[CompilerGenerated]
	public static PhoneSeparator get_Instance() { }

	private void OnApplicationClick(Application application) { }

	private void OnApplicationContentClose(bool _) { }

	private void OnDestroy() { }

	[CompilerGenerated]
	private static void set_Instance(PhoneSeparator value) { }

	private void SetColor(ApplicationType applicationType) { }

	private void SetColor(Color desiredTopColor) { }

}

