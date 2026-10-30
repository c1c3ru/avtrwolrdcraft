namespace System;

[TypeForwardedFrom("System.Core, Version=2.0.5.0, Culture=Neutral, PublicKeyToken=7cec85d7bea7798e")]
public sealed class TimeZoneInfo : IEquatable<TimeZoneInfo>, ISerializable, IDeserializationCallback
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<Char, Boolean> <>9__34_1; //Field offset: 0x8
		public static Func<Char, Boolean> <>9__34_0; //Field offset: 0x10
		public static Func<Char, Boolean> <>9__35_0; //Field offset: 0x18
		public static Func<Char, Boolean> <>9__37_0; //Field offset: 0x20
		public static Func<Char, Boolean> <>9__38_0; //Field offset: 0x28
		public static Comparison<AdjustmentRule> <>9__161_0; //Field offset: 0x30

		private static <>c() { }

		public <>c() { }

		internal int <CreateLocalUnity>b__161_0(AdjustmentRule rule1, AdjustmentRule rule2) { }

		internal bool <TZif_ParsePosixDate>b__37_0(char c) { }

		internal bool <TZif_ParsePosixName>b__34_0(char c) { }

		internal bool <TZif_ParsePosixName>b__34_1(char c) { }

		internal bool <TZif_ParsePosixOffset>b__35_0(char c) { }

		internal bool <TZif_ParsePosixTime>b__38_0(char c) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass16_0
	{
		public string localtimeFilePath; //Field offset: 0x10
		public string posixrulesFilePath; //Field offset: 0x18
		public Byte[] buffer; //Field offset: 0x20
		public Byte[] rawData; //Field offset: 0x28
		public string id; //Field offset: 0x30
		public string timeZoneDirectory; //Field offset: 0x38

		public <>c__DisplayClass16_0() { }

		internal bool <FindTimeZoneId>b__0(string filePath) { }

	}

	internal sealed class AdjustmentRule : IEquatable<AdjustmentRule>, ISerializable, IDeserializationCallback
	{
		private readonly DateTime _dateStart; //Field offset: 0x10
		private readonly DateTime _dateEnd; //Field offset: 0x18
		private readonly TimeSpan _daylightDelta; //Field offset: 0x20
		private readonly TransitionTime _daylightTransitionStart; //Field offset: 0x28
		private readonly TransitionTime _daylightTransitionEnd; //Field offset: 0x40
		private readonly TimeSpan _baseUtcOffsetDelta; //Field offset: 0x58
		private readonly bool _noDaylightTransitions; //Field offset: 0x60

		internal TimeSpan BaseUtcOffsetDelta
		{
			internal get { } //Length: 8
		}

		public DateTime DateEnd
		{
			 get { } //Length: 8
		}

		public DateTime DateStart
		{
			 get { } //Length: 8
		}

		public TimeSpan DaylightDelta
		{
			 get { } //Length: 8
		}

		public TransitionTime DaylightTransitionEnd
		{
			 get { } //Length: 20
		}

		public TransitionTime DaylightTransitionStart
		{
			 get { } //Length: 20
		}

		internal bool HasDaylightSaving
		{
			internal get { } //Length: 360
		}

		internal bool NoDaylightTransitions
		{
			internal get { } //Length: 8
		}

		internal AdjustmentRule() { }

		private AdjustmentRule(DateTime dateStart, DateTime dateEnd, TimeSpan daylightDelta, TransitionTime daylightTransitionStart, TransitionTime daylightTransitionEnd, TimeSpan baseUtcOffsetDelta, bool noDaylightTransitions) { }

		private AdjustmentRule(SerializationInfo info, StreamingContext context) { }

		internal static AdjustmentRule CreateAdjustmentRule(DateTime dateStart, DateTime dateEnd, TimeSpan daylightDelta, TransitionTime daylightTransitionStart, TransitionTime daylightTransitionEnd, TimeSpan baseUtcOffsetDelta, bool noDaylightTransitions) { }

		public static AdjustmentRule CreateAdjustmentRule(DateTime dateStart, DateTime dateEnd, TimeSpan daylightDelta, TransitionTime daylightTransitionStart, TransitionTime daylightTransitionEnd) { }

		public override bool Equals(AdjustmentRule other) { }

		internal TimeSpan get_BaseUtcOffsetDelta() { }

		public DateTime get_DateEnd() { }

		public DateTime get_DateStart() { }

		public TimeSpan get_DaylightDelta() { }

		public TransitionTime get_DaylightTransitionEnd() { }

		public TransitionTime get_DaylightTransitionStart() { }

		internal bool get_HasDaylightSaving() { }

		internal bool get_NoDaylightTransitions() { }

		public virtual int GetHashCode() { }

		internal bool IsEndDateMarkerForEndOfYear() { }

		internal bool IsStartDateMarkerForBeginningOfYear() { }

		private override void System.Runtime.Serialization.IDeserializationCallback.OnDeserialization(object sender) { }

		private override void System.Runtime.Serialization.ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) { }

		private static void ValidateAdjustmentRule(DateTime dateStart, DateTime dateEnd, TimeSpan daylightDelta, TransitionTime daylightTransitionStart, TransitionTime daylightTransitionEnd, bool noDaylightTransitions) { }

	}

	private sealed class CachedData
	{
		private TimeZoneInfo _localTimeZone; //Field offset: 0x10

		public TimeZoneInfo Local
		{
			 get { } //Length: 56
		}

		public CachedData() { }

		private TimeZoneInfo CreateLocal() { }

		public TimeZoneInfo get_Local() { }

		public DateTimeKind GetCorrespondingKind(TimeZoneInfo timeZone) { }

	}

	[IsReadOnly]
	internal struct TransitionTime : IEquatable<TransitionTime>, ISerializable, IDeserializationCallback
	{
		private readonly DateTime _timeOfDay; //Field offset: 0x0
		private readonly byte _month; //Field offset: 0x8
		private readonly byte _week; //Field offset: 0x9
		private readonly byte _day; //Field offset: 0xA
		private readonly DayOfWeek _dayOfWeek; //Field offset: 0xC
		private readonly bool _isFixedDateRule; //Field offset: 0x10

		public int Day
		{
			 get { } //Length: 8
		}

		public DayOfWeek DayOfWeek
		{
			 get { } //Length: 8
		}

		public bool IsFixedDateRule
		{
			 get { } //Length: 8
		}

		public int Month
		{
			 get { } //Length: 8
		}

		public DateTime TimeOfDay
		{
			 get { } //Length: 8
		}

		public int Week
		{
			 get { } //Length: 8
		}

		private TransitionTime(SerializationInfo info, StreamingContext context) { }

		private TransitionTime(DateTime timeOfDay, int month, int week, int day, DayOfWeek dayOfWeek, bool isFixedDateRule) { }

		public static TransitionTime CreateFixedDateRule(DateTime timeOfDay, int month, int day) { }

		public static TransitionTime CreateFloatingDateRule(DateTime timeOfDay, int month, int week, DayOfWeek dayOfWeek) { }

		public virtual bool Equals(object obj) { }

		public override bool Equals(TransitionTime other) { }

		public int get_Day() { }

		public DayOfWeek get_DayOfWeek() { }

		public bool get_IsFixedDateRule() { }

		public int get_Month() { }

		public DateTime get_TimeOfDay() { }

		public int get_Week() { }

		public virtual int GetHashCode() { }

		public static bool op_Inequality(TransitionTime t1, TransitionTime t2) { }

		private override void System.Runtime.Serialization.IDeserializationCallback.OnDeserialization(object sender) { }

		private override void System.Runtime.Serialization.ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) { }

		private static void ValidateTransitionTime(DateTime timeOfDay, int month, int week, int day, DayOfWeek dayOfWeek) { }

	}

	private struct TZifHead
	{
		public readonly uint Magic; //Field offset: 0x0
		public readonly TZVersion Version; //Field offset: 0x4
		public readonly uint IsGmtCount; //Field offset: 0x8
		public readonly uint IsStdCount; //Field offset: 0xC
		public readonly uint LeapCount; //Field offset: 0x10
		public readonly uint TimeCount; //Field offset: 0x14
		public readonly uint TypeCount; //Field offset: 0x18
		public readonly uint CharCount; //Field offset: 0x1C

		public TZifHead(Byte[] data, int index) { }

	}

	private struct TZifType
	{
		public readonly TimeSpan UtcOffset; //Field offset: 0x0
		public readonly bool IsDst; //Field offset: 0x8
		public readonly byte AbbreviationIndex; //Field offset: 0x9

		public TZifType(Byte[] data, int index) { }

	}

	private enum TZVersion
	{
		V1 = 0,
		V2 = 1,
		V3 = 2,
	}

	private static readonly TimeZoneInfo s_utcTimeZone; //Field offset: 0x0
	private static CachedData s_cachedData; //Field offset: 0x8
	private static readonly DateTime s_maxDateOnly; //Field offset: 0x10
	private static readonly DateTime s_minDateOnly; //Field offset: 0x18
	private static readonly TimeSpan MaxOffset; //Field offset: 0x20
	private static readonly TimeSpan MinOffset; //Field offset: 0x28
	private readonly string _id; //Field offset: 0x10
	private readonly string _displayName; //Field offset: 0x18
	private readonly string _standardDisplayName; //Field offset: 0x20
	private readonly string _daylightDisplayName; //Field offset: 0x28
	private readonly TimeSpan _baseUtcOffset; //Field offset: 0x30
	private readonly bool _supportsDaylightSavingTime; //Field offset: 0x38
	private readonly AdjustmentRule[] _adjustmentRules; //Field offset: 0x40

	public TimeSpan BaseUtcOffset
	{
		 get { } //Length: 8
	}

	public string DaylightName
	{
		 get { } //Length: 84
	}

	public string DisplayName
	{
		 get { } //Length: 84
	}

	public static TimeZoneInfo Local
	{
		 get { } //Length: 128
	}

	public string StandardName
	{
		 get { } //Length: 84
	}

	public static TimeZoneInfo Utc
	{
		 get { } //Length: 88
	}

	private static TimeZoneInfo() { }

	private TimeZoneInfo(Byte[] data, string id, bool dstDisabled) { }

	private TimeZoneInfo(SerializationInfo info, StreamingContext context) { }

	private TimeZoneInfo(string id, TimeSpan baseUtcOffset, string displayName, string standardDisplayName, string daylightDisplayName, AdjustmentRule[] adjustmentRules, bool disableDaylightSavingTime) { }

	internal TimeZoneInfo() { }

	private static bool CheckIsDst(DateTime startTime, DateTime time, DateTime endTime, bool ignoreYearAdjustment, AdjustmentRule rule) { }

	private int CompareAdjustmentRuleToDateTime(AdjustmentRule rule, AdjustmentRule previousRule, DateTime dateTime, DateTime dateOnly, bool dateTimeisUtc) { }

	private static bool CompareTimeZoneFile(string filePath, Byte[] buffer, Byte[] rawData) { }

	private DateTime ConvertFromUtc(DateTime dateTime, TimeSpan daylightDelta, TimeSpan baseUtcOffsetDelta) { }

	internal static DateTime ConvertTime(DateTime dateTime, TimeZoneInfo sourceTimeZone, TimeZoneInfo destinationTimeZone, TimeZoneInfoOptions flags) { }

	private static DateTime ConvertTime(DateTime dateTime, TimeZoneInfo sourceTimeZone, TimeZoneInfo destinationTimeZone, TimeZoneInfoOptions flags, CachedData cachedData) { }

	internal static DateTime ConvertTimeToUtc(DateTime dateTime, TimeZoneInfoOptions flags) { }

	private DateTime ConvertToFromUtc(DateTime dateTime, TimeSpan daylightDelta, TimeSpan baseUtcOffsetDelta, bool convertToUtc) { }

	private DateTime ConvertToUtc(DateTime dateTime, TimeSpan daylightDelta, TimeSpan baseUtcOffsetDelta) { }

	private static DateTime ConvertUtcToTimeZone(long ticks, TimeZoneInfo destinationTimeZone, out bool isAmbiguousLocalDst) { }

	private static List<AdjustmentRule> CreateAdjustmentRule(int year, out Int64[] data, out String[] names) { }

	public static TimeZoneInfo CreateCustomTimeZone(string id, TimeSpan baseUtcOffset, string displayName, string standardDisplayName, string daylightDisplayName, AdjustmentRule[] adjustmentRules, bool disableDaylightSavingTime) { }

	public static TimeZoneInfo CreateCustomTimeZone(string id, TimeSpan baseUtcOffset, string displayName, string standardDisplayName) { }

	private static TimeZoneInfo CreateLocalUnity() { }

	private static void EnumerateFilesRecursively(string path, Predicate<String> condition) { }

	public virtual bool Equals(object obj) { }

	public override bool Equals(TimeZoneInfo other) { }

	private static string FindTimeZoneId(Byte[] rawData) { }

	private static string FindTimeZoneIdUsingReadLink(string tzFilePath) { }

	public TimeSpan get_BaseUtcOffset() { }

	public string get_DaylightName() { }

	public string get_DisplayName() { }

	public static TimeZoneInfo get_Local() { }

	public string get_StandardName() { }

	public static TimeZoneInfo get_Utc() { }

	private AdjustmentRule GetAdjustmentRuleForTime(DateTime dateTime, bool dateTimeisUtc, out Nullable<Int32>& ruleIndex) { }

	private AdjustmentRule GetAdjustmentRuleForTime(DateTime dateTime, out Nullable<Int32>& ruleIndex) { }

	internal static TimeSpan GetDateTimeNowUtcOffsetFromUtc(DateTime time, out bool isAmbiguousLocalDst) { }

	private TimeSpan GetDaylightSavingsEndOffsetFromUtc(TimeSpan baseUtcOffset, AdjustmentRule rule) { }

	private TimeSpan GetDaylightSavingsStartOffsetFromUtc(TimeSpan baseUtcOffset, AdjustmentRule rule, Nullable<Int32> ruleIndex) { }

	private DaylightTimeStruct GetDaylightTime(int year, AdjustmentRule rule, Nullable<Int32> ruleIndex) { }

	private static string GetDirectoryEntryFullPath(ref DirectoryEntry dirent, string currentPath) { }

	public virtual int GetHashCode() { }

	private static bool GetIsAmbiguousTime(DateTime time, AdjustmentRule rule, DaylightTimeStruct daylightTime) { }

	private static bool GetIsDaylightSavings(DateTime time, AdjustmentRule rule, DaylightTimeStruct daylightTime, TimeZoneInfoOptions flags) { }

	private static bool GetIsDaylightSavingsFromUtc(DateTime time, int year, TimeSpan utc, AdjustmentRule rule, Nullable<Int32> ruleIndex, out bool isAmbiguousLocalDst, TimeZoneInfo zone) { }

	private static bool GetIsInvalidTime(DateTime time, AdjustmentRule rule, DaylightTimeStruct daylightTime) { }

	private static TimeZoneInfo GetLocalTimeZone(CachedData cachedData) { }

	private static TimeZoneInfo GetLocalTimeZoneFromTzFile() { }

	internal static TimeSpan GetLocalUtcOffset(DateTime dateTime, TimeZoneInfoOptions flags) { }

	private AdjustmentRule GetPreviousAdjustmentRule(AdjustmentRule rule, Nullable<Int32> ruleIndex) { }

	private static string GetTimeZoneDirectory() { }

	private static string GetTimeZoneDirectoryUnity() { }

	private static TimeZoneInfo GetTimeZoneFromTzData(Byte[] rawData, string id) { }

	private static string GetTzEnvironmentVariable() { }

	private static TimeSpan GetUtcOffset(TimeSpan baseUtcOffset, AdjustmentRule adjustmentRule) { }

	private static TimeSpan GetUtcOffset(DateTime time, TimeZoneInfo zone, TimeZoneInfoOptions flags) { }

	private TimeSpan GetUtcOffset(DateTime dateTime, TimeZoneInfoOptions flags, CachedData cachedData) { }

	public TimeSpan GetUtcOffset(DateTime dateTime) { }

	internal TimeSpan GetUtcOffset(DateTime dateTime, TimeZoneInfoOptions flags) { }

	private static TimeSpan GetUtcOffsetFromUtc(DateTime time, TimeZoneInfo zone) { }

	internal static TimeSpan GetUtcOffsetFromUtc(DateTime time, TimeZoneInfo zone, out bool isDaylightSavings, out bool isAmbiguousLocalDst) { }

	private static TimeSpan GetUtcOffsetFromUtc(DateTime time, TimeZoneInfo zone, out bool isDaylightSavings) { }

	public bool HasSameRules(TimeZoneInfo other) { }

	private static bool IsValidAdjustmentRuleOffest(TimeSpan baseUtcOffset, AdjustmentRule adjustmentRule) { }

	private static void NormalizeAdjustmentRuleOffset(TimeSpan baseUtcOffset, ref AdjustmentRule adjustmentRule) { }

	private static DateTime ParseTimeOfDay(string time) { }

	private override void System.Runtime.Serialization.IDeserializationCallback.OnDeserialization(object sender) { }

	private override void System.Runtime.Serialization.ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) { }

	public virtual string ToString() { }

	internal static DateTime TransitionTimeToDateTime(int year, TransitionTime transitionTime) { }

	private static bool TryGetLocalTzFile(out Byte[] rawData, out string id) { }

	private static bool TryLoadTzFile(string tzFilePath, ref Byte[] rawData, ref string id) { }

	private static TimeSpan TZif_CalculateTransitionOffsetFromBase(TimeSpan transitionOffset, TimeSpan timeZoneBaseUtcOffset) { }

	private static AdjustmentRule TZif_CreateAdjustmentRuleForPosixFormat(string posixFormat, DateTime startTransitionDate, TimeSpan timeZoneBaseUtcOffset) { }

	private static Nullable<TransitionTime> TZif_CreateTransitionTimeFromPosixRule(string date, string time) { }

	private static void TZif_GenerateAdjustmentRule(ref int index, TimeSpan timeZoneBaseUtcOffset, List<AdjustmentRule> rulesList, DateTime[] dts, Byte[] typeOfLocalTime, TZifType[] transitionTypes, Boolean[] StandardTime, Boolean[] GmtTime, string futureTransitionsPosixFormat) { }

	private static void TZif_GenerateAdjustmentRules(out AdjustmentRule[] rules, TimeSpan baseUtcOffset, DateTime[] dts, Byte[] typeOfLocalTime, TZifType[] transitionType, Boolean[] StandardTime, Boolean[] GmtTime, string futureTransitionsPosixFormat) { }

	private static TZifType TZif_GetEarlyDateTransitionType(TZifType[] transitionTypes) { }

	private static string TZif_GetZoneAbbreviation(string zoneAbbreviations, int index) { }

	private static void TZif_ParseJulianDay(string date, out int month, out int day) { }

	private static bool TZif_ParseMDateRule(string dateRule, out int month, out int week, out DayOfWeek dayOfWeek) { }

	private static Nullable<TimeSpan> TZif_ParseOffsetString(string offset) { }

	private static string TZif_ParsePosixDate(string posixFormat, ref int index) { }

	private static void TZif_ParsePosixDateTime(string posixFormat, ref int index, out string date, out string time) { }

	private static bool TZif_ParsePosixFormat(string posixFormat, out string standardName, out string standardOffset, out string daylightSavingsName, out string daylightSavingsOffset, out string start, out string startTime, out string end, out string endTime) { }

	private static string TZif_ParsePosixName(string posixFormat, ref int index) { }

	private static string TZif_ParsePosixOffset(string posixFormat, ref int index) { }

	private static string TZif_ParsePosixString(string posixFormat, ref int index, Func<Char, Boolean> breakCondition) { }

	private static string TZif_ParsePosixTime(string posixFormat, ref int index) { }

	private static void TZif_ParseRaw(Byte[] data, out TZifHead t, out DateTime[] dts, out Byte[] typeOfLocalTime, out TZifType[] transitionType, out string zoneAbbreviations, out Boolean[] StandardTime, out Boolean[] GmtTime, out string futureTransitionsPosixFormat) { }

	private static int TZif_ToInt32(Byte[] value, int startIndex) { }

	private static long TZif_ToInt64(Byte[] value, int startIndex) { }

	private static long TZif_ToUnixTime(Byte[] value, int startIndex, TZVersion version) { }

	private static DateTime TZif_UnixTimeToDateTime(long unixTime) { }

	internal static bool UtcOffsetOutOfRange(TimeSpan offset) { }

	private static void ValidateTimeZoneInfo(string id, TimeSpan baseUtcOffset, AdjustmentRule[] adjustmentRules, out bool adjustmentRulesSupportDst) { }

}

