namespace Ugi.PlayInstallReferrerPlugin;

public class PlayInstallReferrerAndroid
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass6_0
	{
		public string referrerUrl; //Field offset: 0x10
		public AndroidJavaObject currentActivity; //Field offset: 0x18

		public <>c__DisplayClass6_0() { }

		internal void <TrackInstallReferrer>b__0() { }

	}

	private class InstallReferrerStateListener : AndroidJavaProxy
	{
		[CompilerGenerated]
		private sealed class <>c
		{
			public static readonly <>c <>9; //Field offset: 0x0
			public static Func<KeyValuePair`2<Int32, String>, Boolean> <>9__2_0; //Field offset: 0x8
			public static AndroidJavaRunnable <>9__2_5; //Field offset: 0x10
			public static Func<KeyValuePair`2<Int32, String>, Boolean> <>9__2_1; //Field offset: 0x18
			public static Func<KeyValuePair`2<Int32, String>, Boolean> <>9__2_2; //Field offset: 0x20
			public static Func<KeyValuePair`2<Int32, String>, Boolean> <>9__2_3; //Field offset: 0x28
			public static Func<KeyValuePair`2<Int32, String>, Boolean> <>9__2_4; //Field offset: 0x30

			private static <>c() { }

			public <>c() { }

			internal bool <onInstallReferrerSetupFinished>b__2_0(KeyValuePair<Int32, String> x) { }

			internal bool <onInstallReferrerSetupFinished>b__2_1(KeyValuePair<Int32, String> x) { }

			internal bool <onInstallReferrerSetupFinished>b__2_2(KeyValuePair<Int32, String> x) { }

			internal bool <onInstallReferrerSetupFinished>b__2_3(KeyValuePair<Int32, String> x) { }

			internal bool <onInstallReferrerSetupFinished>b__2_4(KeyValuePair<Int32, String> x) { }

			internal void <onInstallReferrerSetupFinished>b__2_5() { }

		}

		private Action<PlayInstallReferrerDetails> callback; //Field offset: 0x20

		public InstallReferrerStateListener(Action<PlayInstallReferrerDetails> pCallback) { }

		public void onInstallReferrerServiceDisconnected() { }

		public void onInstallReferrerSetupFinished(int responseCode) { }

	}

	private static InstallReferrerStateListener installReferrerStateProxy; //Field offset: 0x0
	private static AndroidJavaObject ajoInstallReferrerClient; //Field offset: 0x8
	private static Dictionary<Int32, String> installReferrerResponseCodes; //Field offset: 0x10

	public PlayInstallReferrerAndroid() { }

	private static AndroidJavaObject GetInstallReferrerClient() { }

	public static void GetInstallReferrerInfo(Action<PlayInstallReferrerDetails> callback) { }

	private static void TrackInstallReferrer(string referrerUrl) { }

}

