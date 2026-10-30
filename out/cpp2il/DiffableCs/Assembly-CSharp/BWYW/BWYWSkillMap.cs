namespace BWYW;

public class BWYWSkillMap : ScriptableObject
{
	[SerializeField]
	private List<DailyTasksData> _dailyTasks; //Field offset: 0x18
	[SerializeField]
	private string _title; //Field offset: 0x20
	[SerializeField]
	private int _characterId; //Field offset: 0x28
	[SerializeField]
	private Sprite _titleSprite; //Field offset: 0x30
	[SerializeField]
	private Sprite _skillSprite; //Field offset: 0x38
	[SerializeField]
	private Sprite _bGSprite; //Field offset: 0x40
	[SerializeField]
	private Sprite _finalTaskSprite; //Field offset: 0x48

	public Sprite BGSprite
	{
		 get { } //Length: 8
	}

	public int CharacterId
	{
		 get { } //Length: 8
	}

	public Sprite FinalTaskSprite
	{
		 get { } //Length: 8
	}

	public Sprite SkillSprite
	{
		 get { } //Length: 8
	}

	public string Title
	{
		 get { } //Length: 8
	}

	public Sprite TitleSprite
	{
		 get { } //Length: 8
	}

	public BWYWSkillMap() { }

	public Sprite get_BGSprite() { }

	public int get_CharacterId() { }

	public Sprite get_FinalTaskSprite() { }

	public Sprite get_SkillSprite() { }

	public string get_Title() { }

	public Sprite get_TitleSprite() { }

	public DailyTasksData GetDay(int day) { }

	public int GetNumOfDays() { }

}

