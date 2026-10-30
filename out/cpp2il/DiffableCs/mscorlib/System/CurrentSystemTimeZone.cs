namespace System;

[Obsolete("System.CurrentSystemTimeZone has been deprecated.  Please investigate the use of System.TimeZoneInfo.Local instead.")]
internal class CurrentSystemTimeZone : TimeZone
{
	private long m_ticksOffset; //Field offset: 0x10
	private string m_standardName; //Field offset: 0x18
	private string m_daylightName; //Field offset: 0x20
	private readonly Hashtable m_CachedDaylightChanges; //Field offset: 0x28

	internal CurrentSystemTimeZone() { }

	public static bool GetTimeZoneData(int year, out Int64[] data, out String[] names, out bool daylight_inverted) { }

}

