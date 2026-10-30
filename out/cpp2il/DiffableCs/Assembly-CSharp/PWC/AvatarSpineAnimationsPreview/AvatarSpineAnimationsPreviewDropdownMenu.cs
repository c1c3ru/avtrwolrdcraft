namespace PWC.AvatarSpineAnimationsPreview;

public class AvatarSpineAnimationsPreviewDropdownMenu : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<Animation, String> <>9__9_0; //Field offset: 0x8
		public static Func<String, String> <>9__9_1; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal string <Setanimations>b__9_0(Animation x) { }

		internal string <Setanimations>b__9_1(string x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass8_0
	{
		public string value; //Field offset: 0x10

		public <>c__DisplayClass8_0() { }

		internal bool <OnInputValueChanged>b__0(OptionData x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass9_0
	{
		public List<String> animationNames; //Field offset: 0x10

		public <>c__DisplayClass9_0() { }

		internal bool <Setanimations>b__2(OptionData option) { }

	}

	[SerializeField]
	private Dropdown _dropdown; //Field offset: 0x20
	[SerializeField]
	private InputField _inputField; //Field offset: 0x28
	[SerializeField]
	private Scrollbar _scrollbar; //Field offset: 0x30
	private List<OptionData> _optionDataList; //Field offset: 0x38
	private TrackEntry _trackEntry; //Field offset: 0x40

	public AvatarSpineAnimationsPreviewDropdownMenu() { }

	[CompilerGenerated]
	private void <Init>b__6_0(int <p0>) { }

	private void DropdownValueChanged(Dropdown change) { }

	public void Init() { }

	private void OnInputValueChanged(string value) { }

	private void OnScrollBarValueChanged(float value) { }

	public void Setanimations(SkeletonAnimation skeletonAnimation) { }

	private void Update() { }

}

