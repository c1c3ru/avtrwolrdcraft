namespace PWC;

public static class AWGameSettings
{
	private const string MUTE_MUSIC_KEY = "AW_Mute_Music"; //Field offset: 0x0
	private const string MUTE_SFX_KEY = "AW_Mute_SFX"; //Field offset: 0x0
	private const string LANGUAGE_CODE_KEY = "AW_Language_Code"; //Field offset: 0x0
	[CompilerGenerated]
	private static bool <IsMusicMute>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private static bool <IsSFXMute>k__BackingField; //Field offset: 0x1
	[CompilerGenerated]
	private static string <LanguageCode>k__BackingField; //Field offset: 0x8

	public private static bool IsMusicMute
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 80
	}

	public private static bool IsSFXMute
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 80
	}

	public private static string LanguageCode
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 80
	}

	[CompilerGenerated]
	public static bool get_IsMusicMute() { }

	[CompilerGenerated]
	public static bool get_IsSFXMute() { }

	[CompilerGenerated]
	public static string get_LanguageCode() { }

	public static void LoadData() { }

	[CompilerGenerated]
	private static void set_IsMusicMute(bool value) { }

	[CompilerGenerated]
	private static void set_IsSFXMute(bool value) { }

	[CompilerGenerated]
	private static void set_LanguageCode(string value) { }

	public static void SetLanguageCode(string languageCode) { }

	public static void SetMusicMute(bool isMute) { }

	public static void SetSFXMute(bool isMute) { }

	private static void SyncGameWithMusicMuteState() { }

	private static void SyncGameWithSFXMuteState() { }

}

