namespace Ugi.PlayInstallReferrerPlugin;

public class PlayInstallReferrerDetails
{
	[CompilerGenerated]
	private readonly string <InstallReferrer>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private readonly Nullable<Int64> <ReferrerClickTimestampSeconds>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private readonly Nullable<Int64> <InstallBeginTimestampSeconds>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	private readonly Nullable<Int64> <ReferrerClickTimestampServerSeconds>k__BackingField; //Field offset: 0x38
	[CompilerGenerated]
	private readonly Nullable<Int64> <InstallBeginTimestampServerSeconds>k__BackingField; //Field offset: 0x48
	[CompilerGenerated]
	private readonly string <InstallVersion>k__BackingField; //Field offset: 0x58
	[CompilerGenerated]
	private readonly Nullable<Boolean> <GooglePlayInstant>k__BackingField; //Field offset: 0x60
	[CompilerGenerated]
	private readonly PlayInstallReferrerError <Error>k__BackingField; //Field offset: 0x68

	public PlayInstallReferrerError Error
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	public Nullable<Boolean> GooglePlayInstant
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	public Nullable<Int64> InstallBeginTimestampSeconds
	{
		[CompilerGenerated]
		 get { } //Length: 12
	}

	public Nullable<Int64> InstallBeginTimestampServerSeconds
	{
		[CompilerGenerated]
		 get { } //Length: 12
	}

	public string InstallReferrer
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	public string InstallVersion
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	public Nullable<Int64> ReferrerClickTimestampSeconds
	{
		[CompilerGenerated]
		 get { } //Length: 12
	}

	public Nullable<Int64> ReferrerClickTimestampServerSeconds
	{
		[CompilerGenerated]
		 get { } //Length: 12
	}

	internal PlayInstallReferrerDetails(string installReferrer, long referrerClickTimestampSeconds, long installBeginTimestampSeconds, long referrerClickTimestampServerSeconds, long installBeginTimestampServerSeconds, string installVersion, bool googlePlayInstant) { }

	internal PlayInstallReferrerDetails(PlayInstallReferrerError error) { }

	[CompilerGenerated]
	public PlayInstallReferrerError get_Error() { }

	[CompilerGenerated]
	public Nullable<Boolean> get_GooglePlayInstant() { }

	[CompilerGenerated]
	public Nullable<Int64> get_InstallBeginTimestampSeconds() { }

	[CompilerGenerated]
	public Nullable<Int64> get_InstallBeginTimestampServerSeconds() { }

	[CompilerGenerated]
	public string get_InstallReferrer() { }

	[CompilerGenerated]
	public string get_InstallVersion() { }

	[CompilerGenerated]
	public Nullable<Int64> get_ReferrerClickTimestampSeconds() { }

	[CompilerGenerated]
	public Nullable<Int64> get_ReferrerClickTimestampServerSeconds() { }

}

