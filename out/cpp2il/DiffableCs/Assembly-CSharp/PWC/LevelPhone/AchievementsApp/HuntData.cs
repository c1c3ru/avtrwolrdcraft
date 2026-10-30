namespace PWC.LevelPhone.AchievementsApp;

[CreateAssetMenu(fileName = "HuntData", menuName = "PazuWorld/Achievements/Hunt Data")]
public class HuntData : ScriptableObject
{
	[Header("Designer Fields")]
	public string huntGUID; //Field offset: 0x18
	public string huntName; //Field offset: 0x20
	public AchievementData[] achievements; //Field offset: 0x28
	public BigPrizeData bigPrize; //Field offset: 0x30
	public LevelType[] levelsToReset; //Field offset: 0x38
	[Header("Developer Fields")]
	public LevelType levelType; //Field offset: 0x40
	[FormerlySerializedAs("thumbBackground")]
	public Sprite banner; //Field offset: 0x48
	[FormerlySerializedAs("solvedBackground")]
	public Sprite solvedThumb; //Field offset: 0x50
	public Sprite trophyIcon; //Field offset: 0x58
	[FormerlySerializedAs("huntHeaderIcon")]
	public Sprite huntLogo; //Field offset: 0x60
	public long createdTimestamp; //Field offset: 0x68
	public Action<HuntData> OnAllAchievementsSolved; //Field offset: 0x70
	private Dictionary<Int32, AchievementData> _achievementsDictionary; //Field offset: 0x78

	public DateTime CreatedDate
	{
		 get { } //Length: 132
	}

	public HuntData() { }

	public DateTime get_CreatedDate() { }

	public AchievementData GetDataBySecretID(int id) { }

	public Dictionary<Int32, AchievementData> GetDictionary() { }

	public bool IsAllAchievementsSolved() { }

}

