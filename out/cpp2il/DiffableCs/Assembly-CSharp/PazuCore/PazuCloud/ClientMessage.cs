namespace PazuCore.PazuCloud;

public class ClientMessage
{
	internal class Popup
	{
		public string title; //Field offset: 0x10
		public string description; //Field offset: 0x18
		public string cta; //Field offset: 0x20
		public string ctaUrl; //Field offset: 0x28
		public bool isForcedMessage; //Field offset: 0x30
		public bool showLogo; //Field offset: 0x31
		public bool autoOpenUrl; //Field offset: 0x32
		public string closeUrl; //Field offset: 0x38
		public string ctaInGame; //Field offset: 0x40

		public Popup() { }

		public bool IsValid() { }

	}

	[CompilerGenerated]
	private static Action<String> OnMessageCTAClickWithCTAInGameAction; //Field offset: 0x0
	public readonly Popup popup; //Field offset: 0x10
	public readonly Dictionary<String, String> fields; //Field offset: 0x18
	public readonly bool isLocalMessage; //Field offset: 0x20

	public static event Action<String> OnMessageCTAClickWithCTAInGameAction
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public ClientMessage(Dictionary<String, Object> data) { }

	public ClientMessage(string title, string description, string cta) { }

	[CompilerGenerated]
	private void <TryShowPopup>b__9_0() { }

	[CompilerGenerated]
	private void <TryShowPopup>b__9_1() { }

	[CompilerGenerated]
	private void <TryShowPopup>b__9_2() { }

	[CompilerGenerated]
	public static void add_OnMessageCTAClickWithCTAInGameAction(Action<String> value) { }

	private void OpenCTAUrl(string ctaUrl) { }

	[CompilerGenerated]
	public static void remove_OnMessageCTAClickWithCTAInGameAction(Action<String> value) { }

	public bool TryShowPopup(Action onNoCtaAction = null) { }

}

