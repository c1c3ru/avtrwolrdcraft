namespace PWC.AWCloud;

public class AWCloudUserLinkWindow : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action <>9__21_3; //Field offset: 0x8
		public static Action <>9__21_4; //Field offset: 0x10
		public static Action<Boolean> <>9__21_1; //Field offset: 0x18
		public static Action <>9__21_6; //Field offset: 0x20
		public static Action <>9__21_7; //Field offset: 0x28
		public static Action <>9__21_8; //Field offset: 0x30
		public static Action <>9__21_9; //Field offset: 0x38
		public static Action<Boolean, Boolean> <>9__21_5; //Field offset: 0x40
		public static Action <>9__21_2; //Field offset: 0x48

		private static <>c() { }

		public <>c() { }

		internal void <OnVerifyButtonClick>b__21_1(bool isSuccess) { }

		internal void <OnVerifyButtonClick>b__21_2() { }

		internal void <OnVerifyButtonClick>b__21_3() { }

		internal void <OnVerifyButtonClick>b__21_4() { }

		internal void <OnVerifyButtonClick>b__21_5(bool isSuccess, bool didUseCache) { }

		internal void <OnVerifyButtonClick>b__21_6() { }

		internal void <OnVerifyButtonClick>b__21_7() { }

		internal void <OnVerifyButtonClick>b__21_8() { }

		internal void <OnVerifyButtonClick>b__21_9() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass19_0
	{
		public AWCloudUserLinkWindow <>4__this; //Field offset: 0x10
		public string email; //Field offset: 0x18
		public LinkType linkType; //Field offset: 0x20

		public <>c__DisplayClass19_0() { }

		internal void <OnLinkButtonClick>b__0(bool isSuccess) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass21_0
	{
		public AWCloudUserLinkWindow <>4__this; //Field offset: 0x10
		public LinkType linkType; //Field offset: 0x18

		public <>c__DisplayClass21_0() { }

		internal void <OnVerifyButtonClick>b__0(bool isSuccess) { }

	}

	public static Action OnLoadCtaClick; //Field offset: 0x0
	public static Action OnLoadCancelClick; //Field offset: 0x8
	[SerializeField]
	private InputField _emailInputField; //Field offset: 0x20
	[SerializeField]
	private InputField _codeInputField; //Field offset: 0x28
	[SerializeField]
	private GameObject _firstPanel; //Field offset: 0x30
	[SerializeField]
	private GameObject _verifyEmailPanel; //Field offset: 0x38
	[SerializeField]
	private InputField _emailValidationInputField; //Field offset: 0x40
	[SerializeField]
	private TextMeshProUGUI _selectedEMailText; //Field offset: 0x48
	[SerializeField]
	private GameObject _indicatorStage1; //Field offset: 0x50
	[SerializeField]
	private GameObject _indicatorStage2; //Field offset: 0x58
	[SerializeField]
	private GameObject _indicatorStage3; //Field offset: 0x60
	[SerializeField]
	private GameObject _statusIndicators; //Field offset: 0x68
	[SerializeField]
	private Button _verifyCodeButton; //Field offset: 0x70
	private LinkType _linkType; //Field offset: 0x78

	public AWCloudUserLinkWindow() { }

	private void Awake() { }

	public void OnCloseButtonClick() { }

	private void OnCodeInputFieldValueChanged(string value) { }

	private void OnDestroy() { }

	private void OnLinkButtonClick(LinkType linkType) { }

	public void OnPrivacyPolicyButtonClick() { }

	public void OnSignInButtonClick() { }

	public void OnSignUpButtonClick() { }

	public void OnTermsOfUseButtonClick() { }

	public void OnVerifyButtonClick() { }

}

