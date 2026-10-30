namespace PWC.Level;

public class ClothesDropDataMap : ScriptableObject
{
	internal class TimeToClothesDropData
	{
		public int day; //Field offset: 0x10
		public int month; //Field offset: 0x14
		public int year; //Field offset: 0x18
		private long unixTime; //Field offset: 0x20
		public PDTextBulkData data; //Field offset: 0x28

		public long UnixTime
		{
			 get { } //Length: 8
			 set { } //Length: 8
		}

		public TimeToClothesDropData() { }

		public long get_UnixTime() { }

		public DateTime GetDateFromUnixTime(out int day, out int month, out int year) { }

		public long GetUnixTimeFromDate() { }

		public void set_UnixTime(long value) { }

	}

	[SerializeField]
	private List<TimeToClothesDropData> _timeToClothesData; //Field offset: 0x18
	[SerializeField]
	private Sprite _widgetIconSprite; //Field offset: 0x20
	private bool _isUnixValuesCalculated; //Field offset: 0x28

	public ClothesDropDataMap() { }

	private void EnsureUnixValues() { }

	private void GetAllUnixTimes() { }

	public PDTextBulkData GetDropDataForTime(long time, out long dropEndTime, out long dropStartTime) { }

	public PDTextBulkData GetDropDataFromName(string name) { }

	public Sprite GetWidgetIconSprite() { }

}

