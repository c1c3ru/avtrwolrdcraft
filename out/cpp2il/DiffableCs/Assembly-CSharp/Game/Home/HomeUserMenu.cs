namespace Game.Home;

public class HomeUserMenu : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action<ClientStateResponse> <>9__11_2; //Field offset: 0x8
		public static Action<Response> <>9__11_1; //Field offset: 0x10
		public static Action <>9__11_0; //Field offset: 0x18

		private static <>c() { }

		public <>c() { }

		internal void <OnLogoutButtonClick>b__11_0() { }

		internal void <OnLogoutButtonClick>b__11_1(Response logoutResponse) { }

		internal void <OnLogoutButtonClick>b__11_2(ClientStateResponse getClientStateResponse) { }

	}

	[SerializeField]
	private Text _lastSaveDateTextComponent; //Field offset: 0x20

	public HomeUserMenu() { }

	[CompilerGenerated]
	internal static string <GetSaveTimeLabel>g__GetPluralIfNeeded|8_0(long value, string wordToTranslate, string languageCode) { }

	[CompilerGenerated]
	private void <SyncLastSaveDate>b__6_0(CPProfileMetadataCloudResponse response) { }

	private void Awake() { }

	private static string GetSaveTimeLabel(long diff) { }

	private void OnApplicationPause(bool pause) { }

	public void OnBackgroundClick() { }

	private void OnDestroy() { }

	private void OnEnable() { }

	private void OnLastSaveDateChanged() { }

	public void OnLogoutButtonClick() { }

	public void Show() { }

	private void SyncLastSaveDate() { }

	private void SyncLastSaveDateText(Nullable<DateTimeOffset> dateTimeOffset) { }

}

