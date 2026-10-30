namespace BWYW;

public class DailyTaskBase
{
	[SerializeField]
	private string _title; //Field offset: 0x10
	[SerializeField]
	private string _description; //Field offset: 0x18
	[SerializeField]
	private Sprite _sprite; //Field offset: 0x20
	[SerializeField]
	private int _xp; //Field offset: 0x28
	[SerializeField]
	private int _targetCount; //Field offset: 0x2C
	[SerializeField]
	private Sprite _locationSprite; //Field offset: 0x30
	[SerializeReference]
	private List<BWYWConditionBase> _conditions; //Field offset: 0x38

	public List<BWYWConditionBase> Conditions
	{
		 get { } //Length: 8
	}

	public string Description
	{
		 get { } //Length: 8
	}

	public Sprite LocationSprite
	{
		 get { } //Length: 8
	}

	public Sprite Sprite
	{
		 get { } //Length: 8
	}

	public int TargetCount
	{
		 get { } //Length: 8
	}

	public string Title
	{
		 get { } //Length: 8
	}

	public int Xp
	{
		 get { } //Length: 8
	}

	public DailyTaskBase() { }

	public List<BWYWConditionBase> get_Conditions() { }

	public string get_Description() { }

	public Sprite get_LocationSprite() { }

	public Sprite get_Sprite() { }

	public int get_TargetCount() { }

	public string get_Title() { }

	public int get_Xp() { }

}

